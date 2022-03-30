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
    public class PaketController : Controller
    {
        private readonly AppDbContext _context;

        public PaketController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult TampilPaket()
        {
            var SemuaPaket = _context.Tb_paket.ToList();
            return View(SemuaPaket);
        }
        public IActionResult CreatePaket()
        {
            return View();
        }
    }
}
