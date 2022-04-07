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
    }
}
