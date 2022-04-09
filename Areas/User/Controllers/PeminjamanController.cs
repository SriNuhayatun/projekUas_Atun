using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekUas_Atun.Models;
using projekUas_Atun.Services.PeminjamanServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class PeminjamanController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPeminjamanServices _serv;
        public PeminjamanController(AppDbContext c, IPeminjamanServices s)
        {
            _context = c;
            _serv = s;
        }
        public IActionResult Index()
        {
            var semuaPaket = _serv.TampilSemuaData();
            return View(semuaPaket);
        }
        public IActionResult CreatePeminjaman()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePeminjaman(string id, Peminjaman dj)
        {
            if (ModelState.IsValid)
            {
                var ambilData = _context.Tb_Member.Where(x => x.Id_Member == id).FirstOrDefault();

                var peminjaman = new Db_Peminjaman()
                {
                    Id_Member = ambilData.Id_Member,
                    NamaMember = ambilData.NamaMember,
                    Image = ambilData.Image,
                    NamaMobil = dj.NamaMobil,
                    NamaPaket = dj.NamaPaket,
                    NamaSupir = dj.NamaSupir,
                    Tgl_Pinjam = dj.Tgl_Pinjam,
                    Tgl_Kembali = dj.Tgl_Kembali
                };

                string[] Id = _context.Tb_Peminjaman.Select(x => x.Id_Peminjaman).ToArray();

                int temp;
                foreach (var item in Id)
                {
                    temp = Int32.Parse(item.Split("-")[1]);
                    peminjaman.Id_Peminjaman = "P00-" + (temp + 1);
                }

                if (peminjaman.Id_Peminjaman == null)
                {
                    peminjaman.Id_Peminjaman = "P00-1";
                }
                await _serv.BuatPeminjaman(id, peminjaman);

                return RedirectToAction("Index");
            }


            return View();
        }
    }
}
