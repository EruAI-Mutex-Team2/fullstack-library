using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace libraryApp.backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cezalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CezaGunu = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CezaBitisGunu = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CezaAktifMi = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cezalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hesapAcmaTalepleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnaylandiMi = table.Column<bool>(type: "boolean", nullable: false),
                    BeklemedeMi = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hesapAcmaTalepleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Isim = table.Column<string>(type: "text", nullable: false),
                    KitapYayinlandiMi = table.Column<bool>(type: "boolean", nullable: false),
                    YayinlanmaTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitaplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kitapOduncler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KitapId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DonusTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnaylandiMi = table.Column<bool>(type: "boolean", nullable: false),
                    BeklemedeMi = table.Column<bool>(type: "boolean", nullable: false),
                    DondurulduMu = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitapOduncler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kitapYayinTalepleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KitapId = table.Column<int>(type: "integer", nullable: false),
                    YazarId = table.Column<int>(type: "integer", nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnaylandiMi = table.Column<bool>(type: "boolean", nullable: false),
                    BeklemedeMi = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitapYayinTalepleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kitapYazarlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KitapId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitapYazarlari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mesajlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GonderenId = table.Column<int>(type: "integer", nullable: false),
                    AlanId = table.Column<int>(type: "integer", nullable: false),
                    Konu = table.Column<string>(type: "text", nullable: false),
                    Icerik = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesajlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "puanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PuanGunu = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    KazanilanPuan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RollIsmi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sayfalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KitapId = table.Column<int>(type: "integer", nullable: false),
                    SayfaNo = table.Column<int>(type: "integer", nullable: false),
                    Icerik = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sayfalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Isim = table.Column<string>(type: "text", nullable: false),
                    SoyIsim = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RollId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cezalar");

            migrationBuilder.DropTable(
                name: "hesapAcmaTalepleri");

            migrationBuilder.DropTable(
                name: "kitaplar");

            migrationBuilder.DropTable(
                name: "kitapOduncler");

            migrationBuilder.DropTable(
                name: "kitapYayinTalepleri");

            migrationBuilder.DropTable(
                name: "kitapYazarlari");

            migrationBuilder.DropTable(
                name: "mesajlar");

            migrationBuilder.DropTable(
                name: "puanlar");

            migrationBuilder.DropTable(
                name: "roller");

            migrationBuilder.DropTable(
                name: "sayfalar");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
