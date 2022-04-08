using projekUas_Atun.Models;
using projekUas_Atun.Repository.PeminjamanRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Services.PeminjamanServices
{
    public class PeminjamanServices:IPeminjamanServices
    {
        private readonly IPeminjamanRepository _pemRepo;

        public PeminjamanServices(IPeminjamanRepository pm)
        {
            _pemRepo = pm;

        }
        public async Task<bool> BuatPeminjaman(string Id, Db_Peminjaman datanya)
        {

            return await _pemRepo.BuatPinjamAsync(datanya);
        }
        public List<Db_Peminjaman> TampilSemuaData()
        {
            return _pemRepo.TampilSemuaPeminjamanAsync().Result;
        }
    }
}
