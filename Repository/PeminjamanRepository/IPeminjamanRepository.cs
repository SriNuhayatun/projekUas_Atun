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
        
    }
}
