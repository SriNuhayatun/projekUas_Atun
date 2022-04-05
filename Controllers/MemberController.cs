using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekUas_Atun.Models;
using projekUas_Atun.Views.Services.MemberServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMemberServices _serv;
        public MemberController(AppDbContext context, IMemberServices serv)
        {
            _context = context;
            _serv = serv;
        }
        public IActionResult Index()
        {
            var banyakdata = new BlogDashboard();

            banyakdata.memberr = _context.Tb_Member.ToList();

            return View(banyakdata);
        }
        public IActionResult CreateMember()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMember(Member Parameter, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                string[] Id = _context.Tb_Member.Select(x => x.Id_Member).ToArray();

                int temp;
                foreach (var item in Id)
                {
                    temp = Int32.Parse(item.Split("-")[1]);
                    Parameter.Id_Member = "M00-" + (temp + 1);
                }

                if (Parameter.Id_Member == null)
                {
                    Parameter.Id_Member = "M00-1";
                }


                _serv.BuatMember(Parameter, Image);

                return RedirectToAction("Index");
            }
            return View(Parameter);
        }
        
        public async Task<IActionResult> Ubah(string id)
        {

            var cari = await _serv.TampilMemberById(id);

            if (cari == null)
            {
                return NotFound();
            }

            return View(cari);
        }
        [HttpPost]
        public async Task<IActionResult> Ubah(Member data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serv.UpdateMemberAsync(data);
                }
                catch
                {
                    return NotFound();
                }

                return RedirectToAction("Index","Member");
            }

            return View(data);
        }
        public IActionResult Details(string id)
        {

            var detail = new List<Member>();
            var det = _context.Tb_Member.Where(x => x.Id_Member == id).ToList();
            if (det == null)
            {
                return NotFound();
            }
            ViewBag.detail = det;
            return View();
        }
        public async Task<IActionResult> Hapus(string id)
        {
            var cari = _context.Tb_Member.Where(x => x.Id_Member == id).FirstOrDefault();
            if (cari == null)
            {
                return NotFound();
            }
            _context.Tb_Member.Remove(cari);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        
    }
}
