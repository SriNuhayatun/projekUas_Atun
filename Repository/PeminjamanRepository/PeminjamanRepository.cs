using Microsoft.EntityFrameworkCore;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Repository.PeminjamanRepository
{
    public class PeminjamanRepository:IPeminjamanRepository
    {
        private readonly AppDbContext _pinjamDB;

        public PeminjamanRepository(AppDbContext p)
        {
            _pinjamDB = p;
        }
        public async Task<bool> BuatPinjamAsync(Db_Peminjaman datanya)
        {
            _pinjamDB.Tb_Peminjaman.Add(datanya);
            await _pinjamDB.SaveChangesAsync();
            return true;
        }
        public async Task<List<Db_Peminjaman>> TampilSemuaPeminjamanAsync()
        {
            var data = await _pinjamDB.Tb_Peminjaman.ToListAsync();
            return data;
        }


    }
}
