using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Services.PaketService
{
    public interface IPaketService
    {
        Task<List<Paket>> TampilSemuaData();
        Task<Paket> TampilPaketById(string id);
        Task<bool> BuatPaket(Paket datanya);
        Task<bool> HapusPaket(string id);
        Task<bool> UpdatePaketAsync(Paket datanya);
        
    }
}
