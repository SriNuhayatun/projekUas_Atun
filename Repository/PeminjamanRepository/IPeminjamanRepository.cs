using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Repository.PeminjamanRepository
{
    public interface IPeminjamanRepository
    {
        Task<bool> BuatPinjamAsync(Db_Peminjaman datanya);
        Task<List<Db_Peminjaman>> TampilSemuaPeminjamanAsync();
        Task<bool> HapusPinjamAsync(Db_Peminjaman datanya);
        Task<Db_Peminjaman> TampilPinjamByIDAsync(string id);
        Task<bool> UpdatePinjamAsync(Db_Peminjaman datanya);




    }
}
