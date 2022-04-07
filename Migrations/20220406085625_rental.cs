using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projekUas_Atun.Migrations
{
    public partial class rental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Member",
                columns: table => new
                {
                    Id_Member = table.Column<string>(type: "varchar(767)", nullable: false),
                    NamaMember = table.Column<string>(type: "text", nullable: false),
                    JenisKelamin = table.Column<string>(type: "text", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Member", x => x.Id_Member);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Mobil",
                columns: table => new
                {
                    Id_mobil = table.Column<string>(type: "varchar(767)", nullable: false),
                    NamaMobil = table.Column<string>(type: "text", nullable: false),
                    Merk = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Harga = table.Column<int>(type: "int", nullable: false),
                    ImageMobil = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Mobil", x => x.Id_mobil);
                });

            migrationBuilder.CreateTable(
                name: "Tb_paket",
                columns: table => new
                {
                    Id_Paket = table.Column<string>(type: "varchar(767)", nullable: false),
                    NamaPaket = table.Column<string>(type: "text", nullable: false),
                    LamaPeminjaman = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_paket", x => x.Id_Paket);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Supir",
                columns: table => new
                {
                    Id_Supir = table.Column<string>(type: "varchar(767)", nullable: false),
                    NamaSupir = table.Column<string>(type: "text", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    HargaPerhari = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Supir", x => x.Id_Supir);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Peminjaman",
                columns: table => new
                {
                    Id_Peminjaman = table.Column<string>(type: "varchar(767)", nullable: false),
                    Id_Member = table.Column<string>(type: "varchar(767)", nullable: true),
                    NamaMember = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    NamaPaket = table.Column<string>(type: "text", nullable: true),
                    NamaMobil = table.Column<string>(type: "text", nullable: true),
                    NamaSupir = table.Column<string>(type: "text", nullable: true),
                    Tgl_Pinjam = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tgl_Kembali = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Peminjaman", x => x.Id_Peminjaman);
                    table.ForeignKey(
                        name: "FK_Tb_Peminjaman_Tb_Member_Id_Member",
                        column: x => x.Id_Member,
                        principalTable: "Tb_Member",
                        principalColumn: "Id_Member",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_User",
                columns: table => new
                {
                    Username = table.Column<string>(type: "varchar(767)", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    RolesId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_User", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Tb_User_Tb_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Tb_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_DetailPeminjaman",
                columns: table => new
                {
                    Id_DetailPeminjaman = table.Column<string>(type: "varchar(767)", nullable: false),
                    Id_Peminjaman = table.Column<string>(type: "varchar(767)", nullable: true),
                    Id_mobil = table.Column<string>(type: "text", nullable: true),
                    Id_Supir = table.Column<string>(type: "text", nullable: true),
                    Id_Member = table.Column<string>(type: "text", nullable: true),
                    NamaMember = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    NamaPaket = table.Column<string>(type: "text", nullable: true),
                    NamaMobil = table.Column<string>(type: "text", nullable: true),
                    NamaSupir = table.Column<string>(type: "text", nullable: true),
                    Tgl_Pinjam = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tgl_Kembali = table.Column<DateTime>(type: "datetime", nullable: false),
                    denda = table.Column<string>(type: "text", nullable: true),
                    total = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_DetailPeminjaman", x => x.Id_DetailPeminjaman);
                    table.ForeignKey(
                        name: "FK_Tb_DetailPeminjaman_Tb_Peminjaman_Id_Peminjaman",
                        column: x => x.Id_Peminjaman,
                        principalTable: "Tb_Peminjaman",
                        principalColumn: "Id_Peminjaman",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_DetailPeminjaman_Id_Peminjaman",
                table: "Tb_DetailPeminjaman",
                column: "Id_Peminjaman");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Peminjaman_Id_Member",
                table: "Tb_Peminjaman",
                column: "Id_Member");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_User_RolesId",
                table: "Tb_User",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_DetailPeminjaman");

            migrationBuilder.DropTable(
                name: "Tb_Mobil");

            migrationBuilder.DropTable(
                name: "Tb_paket");

            migrationBuilder.DropTable(
                name: "Tb_Supir");

            migrationBuilder.DropTable(
                name: "Tb_User");

            migrationBuilder.DropTable(
                name: "Tb_Peminjaman");

            migrationBuilder.DropTable(
                name: "Tb_Roles");

            migrationBuilder.DropTable(
                name: "Tb_Member");
        }
    }
}
