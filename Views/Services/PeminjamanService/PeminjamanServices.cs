//using projekUas_Atun.Models;
//using projekUas_Atun.Views.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace projekUas_Atun.Views.Services.PeminjamanService
//{
//    public class PeminjamanServices:IPeminjamanServices
//    {
//        private readonly IPeminjamanRepository _pinRepo;

//        public PeminjamanServices(IPeminjamanRepository p)
//        {
//            _pinRepo = p;

//        }

//        public async Task<bool> BuatPinjam(Peminjaman datanya)
//        {

//            return await _pinRepo.BuatPinjamAsync(datanya);
//        }

//        public async Task<bool> HapusPinjam(string id)
//        {
//            var cari = await _pinRepo.TampilPinjamByIDAsync(id);
//            await _pinRepo.HapusPinjamAsync(cari);
//            return true;
//        }

//        public async Task<Peminjaman> TampilPinjamById(string id)
//        {
//            return await _pinRepo.TampilPinjamByIDAsync(id);
//        }

//        public async Task<List<Peminjaman>> TampilSemuaData()
//        {
//            return await _pinRepo.TampilSemuaPinjamAsync();
//        }
//        public async Task<bool> UpdatePinjamAsync(Peminjaman datanya)
//        {
//            return await _pinRepo.UpdatePinjamAsync(datanya);

//        }
//    }
//}
