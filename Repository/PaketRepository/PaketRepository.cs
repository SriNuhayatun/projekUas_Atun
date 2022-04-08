using Microsoft.EntityFrameworkCore;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Repository.PaketRepository
{
    public class PaketRepository:IPaketRepository
    {
        private readonly AppDbContext _PaketDB;

        public PaketRepository(AppDbContext p)
        {
            _PaketDB = p;
        }

        public async Task<bool> BuatPaketAsync(Paket datanya)
        {
            _PaketDB.Tb_paket.Add(datanya);
            await _PaketDB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HapusPaketAsync(Paket datanya)
        {
            _PaketDB.Tb_paket.Remove(datanya);
            await _PaketDB.SaveChangesAsync();
            return true;
        }

        public async Task<Paket> TampilPaketByIDAsync(string id)
        {
            return await _PaketDB.Tb_paket.FirstOrDefaultAsync(x => x.Id_Paket == id);
        }

        public async Task<List<Paket>> TampilSemuaPaketAsync()
        {
            var data = await _PaketDB.Tb_paket.ToListAsync();
            return data;
        }

        public async Task<bool> UpdatePaketAsync(Paket datanya)
        {
            _PaketDB.Tb_paket.Update(datanya);
            await _PaketDB.SaveChangesAsync();
            return true;
        }
    }
}
