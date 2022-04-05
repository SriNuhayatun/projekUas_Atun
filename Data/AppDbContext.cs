using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
        }

        public virtual DbSet<Roles> Tb_Roles { get; set; }
        public virtual DbSet<User> Tb_User { get; set; }
        public virtual DbSet<Member> Tb_Member { get; set; }
        public virtual DbSet<Mobil> Tb_Mobil { get; set; }
        public virtual DbSet<Supir> Tb_Supir { get; set; }
        public virtual DbSet<Paket> Tb_paket { get; set; }
        public virtual DbSet<Db_Peminjaman> Tb_Peminjaman { get; set; }
        public virtual DbSet<Db_DetailPeminjaman> Tb_DetailPeminjaman { get; set; }

    }
}
