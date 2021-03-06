using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Services.PeminjamanServices
{
    public interface IPeminjamanServices
    {
        Task<bool> BuatPeminjaman(string id, Db_Peminjaman datanya);
        List<Db_Peminjaman> TampilSemuaData();
        Task<bool> HapusPinjam(string id);
        Task<Db_Peminjaman> TampilPinjamById(string id);
        Task<bool> UpdatePinjam(Db_Peminjaman datanya);
    }
}
