using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekUas_Atun.Models;
using projekUas_Atun.Services.PaketServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PaketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPaketServices _serv;

        public PaketController(AppDbContext context, IPaketServices s)
        {
            _context = context;
            _serv = s;
        }
        public IActionResult Index()
        {
            var semuaPaket = _serv.TampilSemuaData();
            return View(semuaPaket);
        }
        public IActionResult CreatePaket()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePaket(Paket Parameter)
        {
            string[] Id = _context.Tb_paket.Select(x => x.Id_Paket).ToArray();

            int temp;
            foreach (var item in Id)
            {
                temp = Int32.Parse(item.Split("-")[1]);
                Parameter.Id_Paket = "K00-" + (temp + 1);
            }

            if (Parameter.Id_Paket == null)
            {
                Parameter.Id_Paket = "K00-1";
            }

            if (ModelState.IsValid)
            {
                _context.Add(Parameter);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(Parameter);
        }
        public async Task<IActionResult> Ubah(string id)
        {
            var cari = await _serv.TampilPaketById(id);

            if (cari == null)
            {
                return NotFound();
            }

            return View(cari);
        }
        [HttpPost]
        public async Task<IActionResult> Ubah(Paket data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serv.UpdatePaketAsync(data);
                }
                catch
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "Paket");
            }

            return View(data);
        }
        public IActionResult Details(string id)
        {

            var detail = new List<Paket>();
            var det = _context.Tb_paket.Where(x => x.Id_Paket == id).ToList();
            if (det == null)
            {
                return NotFound();
            }
            ViewBag.detail = det;
            return View();
        }

        public async Task<IActionResult> Hapus(string id)
        {
            var cari = _context.Tb_paket.Where(x => x.Id_Paket == id).FirstOrDefault();
            if (cari == null)
            {
                return NotFound();
            }
            _context.Tb_paket.Remove(cari);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
