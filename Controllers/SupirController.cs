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
    public class SupirController : Controller
    {
        private readonly AppDbContext _context;

        public SupirController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var semuaSupir = new SupirDashboard();
            semuaSupir.supirr = _context.Tb_Supir.ToList();
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
                Parameter.Id_Supir = "M00-" + (temp + 1);
            }

            if (Parameter.Id_Supir == null)
            {
                Parameter.Id_Supir = "M00-1";
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
