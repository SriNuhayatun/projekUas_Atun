using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Models
{
    public class Db_DetailPeminjaman
    {
        [Key]
        public string Id_DetailPeminjaman { get; set; }
        public string Id_Peminjaman { get; set; }
        public string Id_mobil { get; set; }
        public string Id_Supir { get; set; }

        [ForeignKey(" Id_Peminjaman")]
        public Db_Peminjaman IdPeminjaman { get; set; }
        [ForeignKey("Id_mobil")]
        public Mobil Idmobil { get; set; }
        [ForeignKey("Id_Supir")]
        public Supir IdSupir { get; set; }
    }
}
