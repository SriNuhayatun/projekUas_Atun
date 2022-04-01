using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Controllers
{
    [Authorize]
    public class MobilController : Controller
    {
        private readonly AppDbContext _context;

        public MobilController(AppDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> CreateMobil(Mobil Parameter)
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

            if (ModelState.IsValid)
            {
                _context.Add(Parameter);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(Parameter);
        }
    }
}

