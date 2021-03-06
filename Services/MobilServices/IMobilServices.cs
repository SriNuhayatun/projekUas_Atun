using Microsoft.AspNetCore.Http;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Services.MobilServices
{
    public interface IMobilServices
    {
        List<Mobil> TampilSemuaData();
        Task<Mobil> TampilMobilById(string id);
        Task<bool> BuatMobil(Mobil datanya, IFormFile Fotonya);
        Task<bool> HapusMobil(string id);
        Task<bool> UpdateMobil(Mobil datanya, IFormFile Fotonya);
    }
}
