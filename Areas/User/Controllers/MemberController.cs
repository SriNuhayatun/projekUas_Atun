using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;
        public MemberController(AppDbContext context)
        {
            _context = context;
        } 
        public IActionResult Index()
        {
            var banyakdata = new BlogDashboard();
            banyakdata.memberr = _context.Tb_Member.ToList();
            return View(banyakdata);
        }
    }
}
