using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Models
{
    public class Db_Peminjaman
    {
        [Key]
        public string Id_Peminjaman { get; set; }
        public string Id_Member { get; set; }
        public string NamaMember { get; set; }
        public string Image { get; set; }
        public string NamaPaket { get; set; }
        public string NamaMobil { get; set; }
        public string NamaSupir { get; set; }
        public DateTime Tgl_Pinjam { get; set; }
        public DateTime Tgl_Kembali { get; set; }

        [ForeignKey("Id_Member")]
        public Member IdMember { get; set; }
    }
}
