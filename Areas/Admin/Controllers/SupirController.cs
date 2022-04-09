using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekUas_Atun.Models;
using projekUas_Atun.Services.SupirServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SupirController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISupirServices _serv;

        public SupirController(AppDbContext context, ISupirServices s)
        {
            _context = context;
            _serv = s;
        }
        public IActionResult Index()
        {
            var semuaSupir = _serv.TampilSemuaData();
            return View(semuaSupir);
        }
        public IActionResult CreateSupir()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSupir(Supir Parameter)
        {
            string[] Id = _context.Tb_Supir.Select(x => x.Id_Supir).ToArray();

            int temp;
            foreach (var item in Id)
            {
                temp = Int32.Parse(item.Split("-")[1]);
                Parameter.Id_Supir = "S00-" + (temp + 1);
            }

            if (Parameter.Id_Supir == null)
            {
                Parameter.Id_Supir = "S00-1";
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
            var cari = await _serv.TampilSupirById(id);

            if (cari == null)
            {
                return NotFound();
            }

            return View(cari);
        }
        [HttpPost]
        public async Task<IActionResult> Ubah(Supir data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serv.UpdateSupirAsync(data);
                }
                catch
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "Supir");
            }

            return View(data);
        }
        public IActionResult Details(string id)
        {

            var detail = new List<Supir>();
            var det = _context.Tb_Supir.Where(x => x.Id_Supir == id).ToList();
            if (det == null)
            {
                return NotFound();
            }
            ViewBag.detail = det;
            return View();
        }
        public async Task<IActionResult> Hapus(string id)
        {
            var cari = _context.Tb_Supir.Where(x => x.Id_Supir == id).FirstOrDefault();
            if (cari == null)
            {
                return NotFound();
            }
            _context.Tb_Supir.Remove(cari);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
