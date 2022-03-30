using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Models
{
    public class Db_DetailPeminjaman
    {
        //public string Id_DetailPeminjaman { get; set; }
        [ForeignKey(" Id_Peminjaman")]
        public Db_Peminjaman Id_Peminjaman { get; set; }
        [ForeignKey("Id_mobil")]
        public Mobil Id_mobil { get; set; }
        [ForeignKey("Id_Supir")]
        public Supir Id_Supir { get; set; }
    }
}
