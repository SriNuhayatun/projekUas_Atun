using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Services.SupirServices
{
    public interface ISupirServices
    {
        Task<List<Supir>> TampilSemuaData();
        Task<Supir> TampilSupirById(string id);
        Task<bool> BuatSupir(Supir datanya);
        Task<bool> HapusSupir(string id);
        Task<bool> UpdateSupirAsync(Supir datanya);
    }
}
