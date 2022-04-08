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
            datanya.Tgl_Pinjam = DateTime.Now;
            return await _pemRepo.BuatPinjamAsync(datanya);
           
        }
        public List<Db_Peminjaman> TampilSemuaData()
        {
            return _pemRepo.TampilSemuaPeminjamanAsync().Result;
        }
        public async Task<bool> HapusPinjam(string id)
        {
            var cari = await _pemRepo.TampilPinjamByIDAsync(id);
            await _pemRepo.HapusPinjamAsync(cari);
            return true;
        }

        public async Task<Db_Peminjaman> TampilPinjamById(string id)
        {
            return await _pemRepo.TampilPinjamByIDAsync(id);
        }
        public async Task<bool> UpdatePinjam(Db_Peminjaman datanya)
        {
            return await _pemRepo.UpdatePinjamAsync(datanya);

        }
    }
}
