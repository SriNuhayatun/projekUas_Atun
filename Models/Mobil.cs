using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Models
{
    public class Mobil
    {
        [Key]
        public string Id_mobil { get; set; }
        [Required]
        [DisplayName("Mobil")]
        public string NamaMobil { get; set; }
        [Required]
        public string Merk { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int Harga { get; set; }
        [DisplayName("Foto Mobil")]
        public string ImageMobil { get; set; }
        
    }
    public class MobilDashboard
    {
        public List<Mobil> mobill { get; set; }
        public MobilDashboard()
        {
            mobill = new List<Mobil>();
        }

    }
}
