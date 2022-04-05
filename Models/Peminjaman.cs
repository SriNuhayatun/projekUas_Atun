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
        [Required]
        [DisplayName("Tanggal Peminjaman")]
        public DateTime Tgl_Pinjam { get; set; }
        [Required]
        [DisplayName("Tanggal Kembali")]
        public DateTime Tgl_Kembali { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public int Denda { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
