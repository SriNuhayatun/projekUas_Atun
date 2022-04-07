//using Microsoft.EntityFrameworkCore;
//using projekUas_Atun.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace projekUas_Atun.Views.Repository
//{
//    public class PeminjamanRepository:IPeminjamanRepository
//    {
//        private readonly AppDbContext _PinjamDB;

//        public PeminjamanRepository(AppDbContext p)
//        {
//            _PinjamDB = p;
//        }

//        public async Task<bool> BuatPinjamAsync(Peminjaman datanya)
//        {
//            _PinjamDB.Tb_Peminjaman.Add(datanya);
//            await _PinjamDB.SaveChangesAsync();
//            return true;
//        }

//        public async Task<bool> HapusPinjamAsync(Peminjaman datanya)
//        {
//            _PinjamDB.Tb_Peminjaman.Remove(datanya);
//            await _PinjamDB.SaveChangesAsync();
//            return true;
//        }

//        public async Task<Peminjaman> TampilPinjamByIDAsync(string id)
//        {
//            return await _PinjamDB.Tb_Peminjaman.FirstOrDefaultAsync(x => x.Id_Peminjaman == id);
//        }

//        public async Task<List<Peminjaman>> TampilSemuaPinjamAsync()
//        {
//            var data = await _PinjamDB.Tb_Supir.ToListAsync();
//            return data;
//        }

//        public async Task<bool> UpdatePinjamAsync(Peminjaman datanya)
//        {
//            _PinjamDB.Tb_Peminjaman.Update(datanya);
//            await _PinjamDB.SaveChangesAsync();
//            return true;
//        }
//    }
//}
