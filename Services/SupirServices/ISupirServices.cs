using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Services.SupirServices
{
    public interface ISupirServices
    {
        List<Supir> TampilSemuaData();
        Task<Supir> TampilSupirById(string id);
        Task<bool> BuatSupir(Supir datanya);
        Task<bool> HapusSupir(string id);
        Task<bool> UpdateSupirAsync(Supir datanya);
    }
}
