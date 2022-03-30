using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Models
{
    public class Paket
    {
        [Key]
        public string Id_Paket { get; set; }
        [Required]
        [DisplayName("Paket")]
        public string NamaPaket { get; set; }
        [Required]
        [DisplayName("Lama Rental")]
        public string LamaPeminjaman { get; set; }
    }
}
