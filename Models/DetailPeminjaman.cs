using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Models
{
    public class DetailPeminjaman
    {
        public string Id_DetailPeminjaman { get; set; }
        public string Id_Peminjaman { get; set; }
        public string Id_mobil { get; set; }
        public string Id_Supir { get; set; }
        public string Id_Member { get; set; }
        public string NamaMember { get; set; }
        public string Image { get; set; }
        public string NamaPaket { get; set; }
        public string NamaMobil { get; set; }
        public string NamaSupir { get; set; }
        public DateTime Tgl_Pinjam { get; set; }
        public DateTime Tgl_Kembali { get; set; }
        public DateTime tgl_Pengembalian{get;set;}
        public string denda { get; set; }
        public string total { get; set; }
    }
}
