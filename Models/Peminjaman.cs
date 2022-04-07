using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Models
{
    public class Peminjaman
    {
        public string Id_Peminjaman { get; set; }
        public string Id_Member { get; set; }
        public string NamaMember { get; set; }
        public string Image { get; set; }
        public string NamaPaket { get; set; }
        public string NamaMobil { get; set; }
        public string NamaSupir { get; set; }
        [Required]
        [DisplayName("Tanggal Peminjaman")]
        public DateTime Tgl_Pinjam { get; set; }
        [Required]
        [DisplayName("Tanggal Kembali")]
        public DateTime Tgl_Kembali { get; set; }
    }
    public class PinjamDashboard
    {
        public List<Peminjaman> pinjamm { get; set; }
  
        public PinjamDashboard()
        {
            pinjamm = new List<Peminjaman>();
        }

    }
}
