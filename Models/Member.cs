using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Models
{
    public class Member
    {
        [Key]
        public string Id_Member { get; set; }
        [Required]
        [DisplayName("Nama")]
        public string NamaMember { get; set; }
        [Required]
        [DisplayName("Jenis Kelamin")]
        public string JenisKelamin { get; set; }
        [Required]
        [DisplayName("Alamat")]
        public string Alamat { get; set; }
        [DisplayName("Foto Diri")]
        public string Image { get; set; }      
    }
    public class BlogDashboard
    {
        public List<Member> memberr { get; set; }
        public BlogDashboard()
        {
            memberr = new List<Member>();
        }
    }
}
