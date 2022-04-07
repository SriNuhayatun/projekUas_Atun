using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class PeminjamanController : Controller
    {
        private readonly AppDbContext _context;
        public PeminjamanController(AppDbContext c)
        {
            _context = c;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatePeminjaman()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePeminjaman(string id, Db_Peminjaman dj)
        {
            if (ModelState.IsValid)
            {
                var ambilData = _context.Tb_Member.Where(x => x.Id_Member == id).FirstOrDefault();

                var peminjaman = new Peminjaman()
                {
                    Id_Member = ambilData.Id_Member,
                    NamaMember = ambilData.NamaMember,
                    Image = ambilData.Image
                };

                peminjaman.Id_Peminjaman = "PJ-001";

                dj.Id_Peminjaman = peminjaman.Id_Peminjaman;
                dj.Id_Member = peminjaman.Id_Member;
                dj.NamaMember = peminjaman.NamaMember;
                dj.Image = peminjaman.Image;

                _context.Add(dj);
                _context.SaveChanges();
            }


            return View();
        }
    }
}
