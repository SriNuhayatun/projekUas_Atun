using Microsoft.EntityFrameworkCore;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Repository
{
    public class SupirRepository:ISupirRepository
    {
        private readonly AppDbContext _SupirDB;

        public SupirRepository(AppDbContext s)
        {
            _SupirDB = s;
        }

        public async Task<bool> BuatSupirAsync(Supir datanya)
        {
            _SupirDB.Tb_Supir.Add(datanya);
            await _SupirDB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HapusSupirAsync(Supir datanya)
        {
            _SupirDB.Tb_Supir.Remove(datanya);
            await _SupirDB.SaveChangesAsync();
            return true;
        }

        public async Task<Supir> TampilSupirByIDAsync(string id)
        {
            return await _SupirDB.Tb_Supir.FirstOrDefaultAsync(x => x.Id_Supir == id);
        }

        public async Task<List<Supir>> TampilSemuaSupirAsync()
        {
            var data = await _SupirDB.Tb_Supir.ToListAsync();
            return data;
        }

        public async Task<bool> UpdateSupirAsync(Supir datanya)
        {
            _SupirDB.Tb_Supir.Update(datanya);
            await _SupirDB.SaveChangesAsync();
            return true;
        }
    }
}
