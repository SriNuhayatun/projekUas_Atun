using projekUas_Atun.Models;
using projekUas_Atun.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Services.PaketService
{
    public class PaketService:IPaketService
    {
        private readonly IPaketRepository _pakRepo;
        
        public PaketService(IPaketRepository pk)
        {
            _pakRepo = pk;
            
        }

        public async Task<bool> BuatPaket(Paket datanya)
        {

            return await _pakRepo.BuatPaketAsync(datanya);
        }

        public async Task<bool> HapusPaket(string id)
        {
            var cari = await _pakRepo.TampilPaketByIDAsync(id);
            await _pakRepo.HapusPaketAsync(cari);
            return true;
        }

        public async Task<Paket> TampilPaketById(string id)
        {
            return await _pakRepo.TampilPaketByIDAsync(id);
        }

        public async Task<List<Paket>> TampilSemuaData()
        {
            return await _pakRepo.TampilSemuaPaketAsync();
        }
        public async Task<bool> UpdatePaketAsync(Paket datanya)
        {
            return await _pakRepo.UpdatePaketAsync(datanya);

        }
    }
}
