using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekUas_Atun.Models;
using projekUas_Atun.Views.Services.PaketService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
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
    }
}
