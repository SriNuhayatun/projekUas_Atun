using Microsoft.EntityFrameworkCore;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Repository.MobilRepository
{
    public class MobilRepository:IMobilRepository
    {
        private readonly AppDbContext _MobilDB;

        public MobilRepository(AppDbContext m)
        {
            _MobilDB = m;
        }

        //public async Task<bool> BuatMobilAsync(Mobil datanya)
        //{
        //    _MobilDB.Tb_Mobil.Add(datanya);
        //    await _MobilDB.SaveChangesAsync();
        //    return true;
        //}
        public async Task<bool> BuatMobilAsync(Mobil datanya)
        {
            _MobilDB.Tb_Mobil.Add(datanya);
            await _MobilDB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HapusMobilAsync(Mobil datanya)
        {
            _MobilDB.Tb_Mobil.Remove(datanya);
            await _MobilDB.SaveChangesAsync();
            return true;
        }

        public async Task<Mobil> TampilMobilByIDAsync(string id)
        {
            return await _MobilDB.Tb_Mobil.FirstOrDefaultAsync(x => x.Id_mobil == id);
        }

        public async Task<List<Mobil>> TampilSemuaMobilAsync()
        {
            var data = await _MobilDB.Tb_Mobil.ToListAsync();
            return data;
        }

        public async Task<bool> UpdateMobilAsync(Mobil datanya)
        {
            _MobilDB.Tb_Mobil.Update(datanya);
            await _MobilDB.SaveChangesAsync();
            return true;
        }
    }
}
