using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Repository.MobilRepository
{
    public interface IMobilRepository
    {
        Task<bool> BuatMobilAsync(Mobil datanya);
        Task<List<Mobil>> TampilSemuaMobilAsync();
        Task<Mobil> TampilMobilByIDAsync(string id);
        Task<bool> UpdateMobilAsync(Mobil datanya);
        Task<bool> HapusMobilAsync(Mobil datanya);
    }
}
