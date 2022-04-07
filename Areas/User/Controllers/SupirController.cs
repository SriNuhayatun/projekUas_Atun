using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekUas_Atun.Models;
using projekUas_Atun.Views.Services.SupirServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
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
            var semuaSupir = new SupirDashboard();
            semuaSupir.supirr = _context.Tb_Supir.ToList();
            return View(semuaSupir);
        }
    }
}
