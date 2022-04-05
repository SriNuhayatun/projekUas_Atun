using Microsoft.AspNetCore.Http;
using projekUas_Atun.Models;
using projekUas_Atun.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Services.MobilServices
{
    public class MobilServices : IMobilServices
    {
        private readonly IMobilRepository _mobRepo;
        private readonly FileServiceMobil _file;

        public MobilServices(IMobilRepository mb, FileServiceMobil f)
        {
            _mobRepo = mb;
            _file = f;
        }

        public async Task<bool> BuatMobil(Mobil datanya,IFormFile Fotonya)
        {
            datanya.ImageMobil = await _file.SimpanFile(Fotonya);

            return await _mobRepo.BuatMobilAsync(datanya);
        }
        public async Task<bool> HapusMobil(String id)
        {
            var cari = await _mobRepo.TampilMobilByIDAsync(id);
            await _mobRepo.HapusMobilAsync(cari);
            return true;
        }

        public async Task<Mobil> TampilMobilById(string id)
        {
            return await _mobRepo.TampilMobilByIDAsync(id);
        }

        public  async Task<List<Mobil>> TampilSemuaData()
        {
            return await _mobRepo.TampilSemuaMobilAsync();
        }
        public async Task<bool> UpdateMobil(Mobil datanya)
        {
            return await _mobRepo.UpdateMobilAsync(datanya);
        }
    }
}
