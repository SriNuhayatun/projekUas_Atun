using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Repository.PaketRepository
{
    public interface IPaketRepository
    {
        Task<bool> BuatPaketAsync(Paket datanya);
        Task<List<Paket>> TampilSemuaPaketAsync();
        Task<Paket> TampilPaketByIDAsync(string id);
        Task<bool> UpdatePaketAsync(Paket datanya);
        Task<bool> HapusPaketAsync(Paket datanya);
    }
}
