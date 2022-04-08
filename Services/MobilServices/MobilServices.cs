using Microsoft.AspNetCore.Http;
using projekUas_Atun.Models;
using projekUas_Atun.Repository.MobilRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Services.MobilServices
{
    public class MobilServices:IMobilServices
    {
        private readonly IMobilRepository _mobRepo;

        public MobilServices(IMobilRepository pk)
        {
            _mobRepo = pk;

        }

        public async Task<bool> BuatMobil(Mobil datanya, IFormFile Fotonya)
        {

            return await _mobRepo.BuatMobilAsync(datanya);
        }

        public async Task<bool> HapusMobil(string id)
        {
            var cari = await _mobRepo.TampilMobilByIDAsync(id);
            await _mobRepo.HapusMobilAsync(cari);
            return true;
        }

        public async Task<Mobil> TampilMobilById(string id)
        {
            return await _mobRepo.TampilMobilByIDAsync(id);
        }

        public List<Mobil> TampilSemuaData()
        {
            return _mobRepo.TampilSemuaMobilAsync().Result;
        }
        public async Task<bool> UpdateMobil(Mobil datanya)
        {
            return await _mobRepo.UpdateMobilAsync(datanya);

        }
        
    }
}
