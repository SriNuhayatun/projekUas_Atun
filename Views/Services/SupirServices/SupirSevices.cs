using projekUas_Atun.Models;
using projekUas_Atun.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Services.SupirServices
{
    public class SupirSevices:ISupirServices
    {
        private readonly ISupirRepository _supRepo;

        public SupirSevices(ISupirRepository s)
        {
            _supRepo = s;
        }
        
        public async Task<bool> BuatSupir(Supir datanya)
        {
            return await _supRepo.BuatSupirAsync(datanya);
        }

        public async Task<bool> HapusSupir(string id)
        {
            var cari = await _supRepo.TampilSupirByIDAsync(id);
            await _supRepo.HapusSupirAsync(cari);
            return true;
        }

        public async Task<Supir> TampilSupirById(string id)
        {
            return await _supRepo.TampilSupirByIDAsync(id);
        }

        public async Task<List<Supir>> TampilSemuaData()
        {
            return await _supRepo.TampilSemuaSupirAsync();
        }

        public async Task<bool> UpdateSupirAsync(Supir datanya)
        {
            return await _supRepo.UpdateSupirAsync(datanya);

        }
    }
}
