﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Controllers
{
    [Authorize]
    public class PaketController : Controller
    {
        private readonly AppDbContext _context;

        public PaketController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var semuaPaket = new PaketDashboard();
            semuaPaket.pakett = _context.Tb_paket.ToList();
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
                Parameter.Id_Paket = "M00-" + (temp + 1);
            }

            if (Parameter.Id_Paket == null)
            {
                Parameter.Id_Paket = "M00-1";
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
