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
        public DateTime Tgl_Pinjam { get; set; }
        public DateTime Tgl_Kembali { get; set; }
        public int Total { get; set; }
        public int Denda { get; set; }
        public string Status { get; set; }
        [ForeignKey("Id_Member")]
        public Member IdMember { get; set; }
    }
}
