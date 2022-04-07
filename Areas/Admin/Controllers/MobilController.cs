using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekUas_Atun.Models;
using projekUas_Atun.Views.Services.MobilServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MobilController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMobilServices _serv;

        public MobilController(AppDbContext context, IMobilServices serv)
        {
            _context = context;
            _serv = serv;
        }
        public IActionResult Index()
        {
            var semuaMobil = new MobilDashboard();
            semuaMobil.mobill = _context.Tb_Mobil.ToList();
            return View(semuaMobil);
        }
        public IActionResult CreateMobil()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMobil(Mobil Parameter, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                string[] Id = _context.Tb_Mobil.Select(x => x.Id_mobil).ToArray();

                int temp;
                foreach (var item in Id)
                {
                    temp = Int32.Parse(item.Split("-")[1]);
                    Parameter.Id_mobil = "M00-" + (temp + 1);
                }

                if (Parameter.Id_mobil == null)
                {
                    Parameter.Id_mobil = "M00-1";
                }
                await _serv.BuatMobil(Parameter, Image);

                return RedirectToAction("Index");
            }
            return View(Parameter);
        }
        public async Task<IActionResult> Hapus(string id)
        {
            var cari = _context.Tb_Mobil.Where(x => x.Id_mobil == id).FirstOrDefault();
            if (cari == null)
            {
                return NotFound();
            }
            _context.Tb_Mobil.Remove(cari);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Ubah(string id)
        {

            var cari = await _serv.TampilMobilById(id);

            if (cari == null)
            {
                return NotFound();
            }

            return View(cari);
        }
        [HttpPost]
        public async Task<IActionResult> Ubah(Mobil data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serv.UpdateMobil(data);
                }
                catch
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "Mobil");
            }

            return View(data);
        }
        public IActionResult Details(string id)
        {

            var detail = new List<Mobil>();
            var det = _context.Tb_Mobil.Where(x => x.Id_mobil == id).ToList();
            if (det == null)
            {
                return NotFound();
            }
            ViewBag.detail = det;
            return View();
        }
    }
}
