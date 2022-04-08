using projekUas_Atun.Models;
using projekUas_Atun.Repository.SupirRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Services.SupirServices
{
    public class SupirServices:ISupirServices
    {
        private readonly ISupirRepository _supRepo;

        public SupirServices(ISupirRepository s)
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

        public List<Supir> TampilSemuaData()
        {
            return _supRepo.TampilSemuaSupirAsync().Result;
        }

        public async Task<bool> UpdateSupirAsync(Supir datanya)
        {
            return await _supRepo.UpdateSupirAsync(datanya);

        }
    }
}
