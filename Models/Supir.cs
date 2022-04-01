using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Models
{
    public class Supir
    {
        [Key]
        public string Id_Supir { get; set; }
        [Required]
        [DisplayName("Nama")]
        public string NamaSupir { get; set; }
        [Required]
        public string Alamat { get; set; }
        [Required]
        public int HargaPerhari { get; set; }
        [Required]
        public string status { get; set; }
    }
    public class SupirDashboard
    {
        public List<Supir> supirr { get; set; }
        public SupirDashboard()
        {
            supirr = new List<Supir>();
        }
    }
}
