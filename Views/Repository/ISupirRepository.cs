using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Repository
{
    public interface ISupirRepository
    {
        Task<bool> BuatSupirAsync(Supir datanya);
        Task<List<Supir>> TampilSemuaSupirAsync();
        Task<Supir> TampilSupirByIDAsync(string id);
        Task<bool> UpdateSupirAsync(Supir datanya);
        Task<bool> HapusSupirAsync(Supir datanya);
    }
}
