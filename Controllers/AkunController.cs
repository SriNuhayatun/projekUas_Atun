using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekUas_Atun.Helper;
using projekUas_Atun.Models;
using projekUas_Atun.Views.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace projekUas_Atun.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _email;
        private static int _OTP;
        public AkunController(AppDbContext context, EmailService e)
        {
            _context = context;
            _email = e;
        }
        public IActionResult Daftar()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Daftar(User datanya)
        //{
        //    int OTP = BanyakBantuan.BuatOTP();

        //    _email.KirimEmail(datanya.Email, "Konfirmasi Daftar", "<h1 style='color:green'>Ini Dari Saya</h1>" + OTP);

        //    var deklarRole = _context.Tb_Roles.Where(x => x.Id == "1").FirstOrDefault();
        //    datanya.Roles = deklarRole;
        //    _context.Add(datanya);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Masuk");
        //}
        [HttpPost]
        public IActionResult Daftar(User parameter, int otp)
        {
            if (otp == _OTP)
            {
                Roles cariRoles = _context.Tb_Roles.FirstOrDefault(x => x.Id == "2");

                parameter.Roles = cariRoles;

                _context.Tb_User.Add(parameter);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(parameter);
        }
        [HttpPost]
        public object KirimEmailOTP(string emailTujuan)
        {
            var cariEmail = _context.Tb_User.FirstOrDefault(x => x.Email == emailTujuan);
            if (cariEmail != null) return new { result = false, message = "Email " + emailTujuan + " sudah terdaftar" };

            BanyakBantuan _bantu = new BanyakBantuan();
            _OTP = _bantu.BuatOTP();
            string subjeknya = "Konfirmasi email untuk daftar akun";
            string isiEmailnya =
                "<h1>Berikut OTP anda <i style='color: red;'>"
                + _OTP.ToString()
                + "</i></h1>"
                + "<a href='mailto:dotnetlanjutan@gmail.com?subject=Bantuan&body=Halo'>Bantuan</a>";

            // dari services/EmailService.cs
            bool cek = _email.KirimEmail(emailTujuan, subjeknya, isiEmailnya); // return nya true atau false

            // cek jika true
            if (cek) return new { result = true, message = "Email berhasil dikirimkan ke " + emailTujuan };

            // jika false
            return new { result = false, message = "Email " + emailTujuan + " tidak ditemukan" };
        }

        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Masuk(User datanya)
        {
            var cariusername = _context.Tb_User.Where(bebas =>
                                               bebas.Username == datanya.Username
             ).FirstOrDefault();
            if (cariusername != null)
            {
                var cekpassword = _context.Tb_User.Where(bebas =>
                                                bebas.Username == datanya.Username
                                                &&
                                                bebas.Password == datanya.Password
                                               )
                .Include(bebas2 => bebas2.Roles).FirstOrDefault();

                if (cekpassword != null)
                {

                    var daftar = new List<Claim>
                    {
                        new Claim("Username",cariusername.Username),
                        new Claim("Role",cariusername.Roles.Id)
                    };
                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(daftar, "Cookie", "Username", "Role")
                        )
                   );

                    if (cariusername.Roles.Id == "1")
                    {
                        return Redirect("/Admin/Home");
                    }
                    else if (cariusername.Roles.Id == "2")
                    {
                        return Redirect("/User/Home");
                    }
                    return RedirectToAction(controllerName: "Home", actionName: "Index");
                }
                ViewBag.pesan = "password salah";
                return View(datanya);
            }
            ViewBag.pesan = "Username salah";
            return View(datanya);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
