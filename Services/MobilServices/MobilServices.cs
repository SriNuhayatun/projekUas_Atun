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
        private readonly FileServices _file;

        public MobilServices(IMobilRepository pk, FileServices f)
        {
            _mobRepo = pk;
            _file = f;
        }

        public async Task<bool> BuatMobil(Mobil datanya, IFormFile Fotonya)
        {
            datanya.ImageMobil = await _file.SimpanFile(Fotonya);
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
        public async Task<bool> UpdateMobil(Mobil datanya, IFormFile Fotonya)
        {
            var cari = _mobRepo.TampilMobilByIDAsync(datanya.Id_mobil).Result;
            if (cari != null)
            {
                cari.NamaMobil = datanya.NamaMobil;
                cari.Merk = datanya.Merk;
                cari.Status = datanya.Status;
                cari.Harga = datanya.Harga;
                

                if (Fotonya != null) cari.ImageMobil = await _file.SimpanFile(Fotonya);
                else cari.ImageMobil = cari.ImageMobil;
                return await _mobRepo.UpdateMobilAsync(cari);
            }
            return false;


        }

    }
}
