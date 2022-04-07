using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Services.PeminjamanService
{
    public interface IPeminjamanServices
    {
        Task<List<Peminjaman>> TampilSemuaData();
        Task<Peminjaman> TampilPinjamById(string id);
        Task<bool> BuatPinjam(Peminjaman datanya);
        Task<bool> HapusPinjam(string id);
        Task<bool> UpdatePinjamAsync(Peminjaman datanya);
    }
}
