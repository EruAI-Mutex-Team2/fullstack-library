using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    RolIsmi = table.Column<string>(type: "text", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_sayfalar_kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    RolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_roller_RolId",
                        column: x => x.RolId,
                        principalTable: "roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_kitapOduncler_kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitapOduncler_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_kitapYayinTalepleri_kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitapYayinTalepleri_users_YazarId",
                        column: x => x.YazarId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_kitapYazarlari_kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitapYazarlari_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_mesajlar_users_GonderenId",
                        column: x => x.GonderenId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cezalar",
                columns: new[] { "Id", "CezaAktifMi", "CezaBitisGunu", "CezaGunu", "UserId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2024, 9, 9, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8169), new DateTime(2024, 8, 30, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8160), 2 },
                    { 2, false, new DateTime(2024, 8, 10, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8173), new DateTime(2024, 7, 31, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8171), 3 },
                    { 3, false, new DateTime(2024, 7, 11, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8176), new DateTime(2024, 7, 1, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8175), 4 },
                    { 4, false, new DateTime(2024, 6, 11, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8179), new DateTime(2024, 6, 1, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8178), 5 },
                    { 5, true, new DateTime(2024, 5, 12, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8182), new DateTime(2024, 5, 2, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8181), 6 },
                    { 6, false, new DateTime(2024, 4, 12, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8185), new DateTime(2024, 4, 2, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8184), 7 },
                    { 7, false, new DateTime(2024, 3, 13, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8188), new DateTime(2024, 3, 3, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8187), 8 },
                    { 8, true, new DateTime(2024, 2, 12, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8191), new DateTime(2024, 2, 2, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8190), 9 },
                    { 9, false, new DateTime(2024, 1, 13, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8194), new DateTime(2024, 1, 3, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8193), 10 },
                    { 10, true, new DateTime(2023, 12, 14, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8197), new DateTime(2023, 12, 4, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8196), 11 }
                });

            migrationBuilder.InsertData(
                table: "hesapAcmaTalepleri",
                columns: new[] { "Id", "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[,]
                {
                    { 1, false, true, new DateTime(2024, 9, 24, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8381), 4 },
                    { 2, true, false, new DateTime(2024, 9, 27, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8384), 5 },
                    { 3, true, false, new DateTime(2024, 9, 21, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8387), 6 },
                    { 4, false, true, new DateTime(2024, 9, 14, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8389), 7 },
                    { 5, true, false, new DateTime(2024, 9, 9, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8391), 8 },
                    { 6, false, true, new DateTime(2024, 9, 4, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8394), 9 },
                    { 7, true, false, new DateTime(2024, 8, 30, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8404), 10 },
                    { 8, false, true, new DateTime(2024, 8, 25, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8407), 11 },
                    { 9, true, false, new DateTime(2024, 8, 20, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8409), 12 },
                    { 10, false, true, new DateTime(2024, 8, 15, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8411), 13 }
                });

            migrationBuilder.InsertData(
                table: "kitaplar",
                columns: new[] { "Id", "Isim", "KitapYayinlandiMi", "YayinlanmaTarihi" },
                values: new object[,]
                {
                    { 1, "The Art of Coding", true, new DateTime(2023, 9, 30, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8541) },
                    { 2, "Mastering Algorithms", false, new DateTime(2024, 9, 29, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8544) },
                    { 3, "Clean Code", true, new DateTime(2024, 4, 2, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8546) },
                    { 4, "Refactoring", true, new DateTime(2024, 3, 13, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8548) },
                    { 5, "Design Patterns", true, new DateTime(2023, 12, 4, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8550) },
                    { 6, "Introduction to Algorithms", false, new DateTime(2024, 9, 19, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8552) },
                    { 7, "Data Structures and Algorithms", true, new DateTime(2023, 9, 30, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8554) },
                    { 8, "Agile Software Development", false, new DateTime(2024, 9, 29, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8556) },
                    { 9, "The Pragmatic Programmer", true, new DateTime(2024, 3, 13, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8558) },
                    { 10, "Effective Java", true, new DateTime(2024, 1, 23, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8560) }
                });

            migrationBuilder.InsertData(
                table: "puanlar",
                columns: new[] { "Id", "KazanilanPuan", "PuanGunu", "UserId" },
                values: new object[,]
                {
                    { 1, 1000, new DateTime(2024, 9, 28, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8844), 1 },
                    { 2, 2000, new DateTime(2024, 9, 27, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8847), 2 },
                    { 3, 1500, new DateTime(2024, 9, 26, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8849), 3 },
                    { 4, 2500, new DateTime(2024, 9, 25, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8851), 4 },
                    { 5, 3000, new DateTime(2024, 9, 24, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8853), 5 },
                    { 6, 3500, new DateTime(2024, 9, 23, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8855), 6 },
                    { 7, 4000, new DateTime(2024, 9, 22, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8857), 7 },
                    { 8, 4500, new DateTime(2024, 9, 21, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8859), 8 },
                    { 9, 5000, new DateTime(2024, 9, 20, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8861), 9 },
                    { 10, 5500, new DateTime(2024, 9, 19, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8862), 10 }
                });

            migrationBuilder.InsertData(
                table: "roller",
                columns: new[] { "Id", "RolIsmi" },
                values: new object[,]
                {
                    { 1, "uye" },
                    { 2, "yazar" },
                    { 3, "gorevli" },
                    { 4, "yonetici" }
                });

            migrationBuilder.InsertData(
                table: "sayfalar",
                columns: new[] { "Id", "Icerik", "KitapId", "SayfaNo" },
                values: new object[,]
                {
                    { 1, "Ana Sayfa", 1, 1 },
                    { 2, "Kitaplar", 1, 2 },
                    { 3, "Kullanıcılar", 1, 3 },
                    { 4, "Yazarlar", 1, 4 },
                    { 5, "Ödünç Alma", 1, 5 },
                    { 6, "Mesajlar", 1, 6 },
                    { 7, "Ayarlar", 1, 7 },
                    { 8, "Yardım", 1, 8 },
                    { 9, "Hesap Yönetimi", 1, 9 },
                    { 10, "Çıkış", 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "Isim", "Password", "RolId", "SoyIsim" },
                values: new object[,]
                {
                    { 1, "ahmet.yilmaz@example.com", "Ahmet", "$2a$11$XZCw9Xvm3tT57To1IOAyKe/10WcndvmrOdewzuFs487UgIuNYaOq.", 1, "Yılmaz" },
                    { 2, "mehmet.kara@example.com", "Mehmet", "$2a$11$195Z9mbqWHMh67dOXLCBEOCYBVW43Amg4wSElF9pAdLUil8.YIC7u", 1, "Kara" },
                    { 3, "ayse.celik@example.com", "Ayşe", "$2a$11$oNv2X2YC47uQTnItKDTqPeh2p03L0p8MC4Rq8atVsvfDXI6pzYlzm", 2, "Çelik" },
                    { 4, "fatma.koc@example.com", "Fatma", "$2a$11$UmpxWT6dmkrHnZmjAgf5Iunmq5Z6iAesFfxHwSB4xQVN1AQuDHhDS", 1, "Koç" },
                    { 5, "emre.demir@example.com", "Emre", "$2a$11$cRgePI7jeKdDv2uVyNF59.dmSYjOdjaeivwsLCk38KxyneXhlQZJm", 1, "Demir" },
                    { 6, "seda.aydin@example.com", "Seda", "$2a$11$O8b/nnXyosn2.4jt7tEUOOpkp7fJFAs3Ud8Au/uGVjez9vrpZwJii", 2, "Aydın" },
                    { 7, "oguz.polat@example.com", "Oğuz", "$2a$11$3MYXzyhkwNqQwuOzK/J7gO0ro6Lji.nBNpuZSHAVem8mBWkZsgD4m", 1, "Polat" },
                    { 8, "zeynep.gunes@example.com", "Zeynep", "$2a$11$QI7nnjWVhuYR/eQegKKD3OX/tNDhjPEao.qHAmhY3NJsotW52PVEO", 1, "Güneş" },
                    { 9, "can.arslan@example.com", "Can", "$2a$11$sMsAs7EX5BVpYyV6MOONfOPTrfRiNj1SQ7Cgz1jmTN8lyyrLWmADG", 2, "Arslan" },
                    { 10, "merve.sonmez@example.com", "Merve", "$2a$11$5Z3JCvmGIMkKgBxEvDhMaOvISbIWsfovMXtsYj5ZRNvYW3/Y8Ut9q", 1, "Sönmez" },
                    { 11, "ali.ak@example.com", "Ali", "$2a$11$yQR8gL4LT82B1hxeG22YDOJKof4Od6QN.94/s1.7KIlLskjXWDYaq", 1, "Ak" },
                    { 12, "berk.ozturk@example.com", "Berk", "$2a$11$OVR2B9mN2umUdrKqaz8u4.DJ1E2ulchwGzNzFFWZ7ulziFDf35WJq", 1, "Öztürk" },
                    { 13, "ayla.yalcin@example.com", "Ayla", "$2a$11$Z/jWMlPBd3Xs.cxyoLfWL.uwhc6MzWFXJdY/isk/oaNQzEM6IjYPG", 2, "Yalçın" },
                    { 14, "emine.cinar@example.com", "Emine", "$2a$11$n4Vug7vfeCMur3Zb6ywoQ.xl087T.ikmsFa3nbPVSlJBfAKobcptG", 1, "Çınar" },
                    { 15, "serdar.toprak@example.com", "Serdar", "$2a$11$ubNgBu.qGdN3Z4A683R3G.HdMfJ6tbhmfbPZJ9aheKpY99thqzExC", 1, "Toprak" },
                    { 16, "yonetici@example.com", "Türker", "$2a$11$DUmvI5bYqfunQIUhqxpACOA7zsMufnHP5YzuwiUsCAhhIvxbdwCzi", 4, "Kıvılcım" },
                    { 17, "gorevli@example.com", "Melek", "$2a$11$5ZtMyd/y5rqpsfhgA6diu.0mBk1gBsDfL/RyfSDslG3S/XhH/V6iK", 3, "Altun" },
                    { 18, "yazar@example.com", "Ebrar", "$2a$11$73bgsHJnpkzXHI3XpGOpZuj64p6MFkS6DPuHSTQ8SoYxDRmKmw2Nq", 2, "Saygılı" },
                    { 19, "uye@example.com", "Zehra", "$2a$11$9eiCC3IECQauLG5pS4fpfu0wwykacWKKXJjQjw9S7b3rAQ8iODnEK", 1, "Akdemir" }
                });

            migrationBuilder.InsertData(
                table: "kitapOduncler",
                columns: new[] { "Id", "BeklemedeMi", "DondurulduMu", "DonusTarihi", "KitapId", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[,]
                {
                    { 1, false, false, new DateTime(2024, 10, 6, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8610), 1, true, new DateTime(2024, 9, 22, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8609), 2 },
                    { 2, true, false, new DateTime(2024, 10, 9, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8615), 2, false, new DateTime(2024, 9, 19, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8614), 3 },
                    { 3, false, true, new DateTime(2024, 10, 11, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8619), 3, true, new DateTime(2024, 9, 17, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8618), 4 },
                    { 4, true, false, new DateTime(2024, 10, 14, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8622), 4, false, new DateTime(2024, 9, 14, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8621), 5 },
                    { 5, false, false, new DateTime(2024, 10, 17, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8626), 5, true, new DateTime(2024, 9, 11, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8625), 6 },
                    { 6, true, false, new DateTime(2024, 10, 19, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8630), 6, false, new DateTime(2024, 9, 9, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8629), 7 },
                    { 7, false, false, new DateTime(2024, 10, 21, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8633), 7, true, new DateTime(2024, 9, 7, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8632), 8 }
                });

            migrationBuilder.InsertData(
                table: "kitapYayinTalepleri",
                columns: new[] { "Id", "BeklemedeMi", "KitapId", "OnaylandiMi", "TalepTarihi", "YazarId" },
                values: new object[,]
                {
                    { 1, false, 1, true, new DateTime(2024, 9, 26, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8677), 1 },
                    { 2, true, 2, false, new DateTime(2024, 9, 23, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8680), 2 },
                    { 3, true, 3, false, new DateTime(2024, 9, 20, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8683), 1 },
                    { 4, false, 4, true, new DateTime(2024, 9, 17, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8686), 3 },
                    { 5, true, 5, false, new DateTime(2024, 9, 14, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8688), 2 },
                    { 6, true, 6, false, new DateTime(2024, 9, 11, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8691), 1 },
                    { 7, false, 7, true, new DateTime(2024, 9, 8, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8693), 4 },
                    { 8, true, 8, false, new DateTime(2024, 9, 5, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8695), 3 },
                    { 9, false, 9, true, new DateTime(2024, 9, 2, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8698), 2 },
                    { 10, true, 10, false, new DateTime(2024, 8, 30, 13, 27, 17, 586, DateTimeKind.Utc).AddTicks(8700), 1 }
                });

            migrationBuilder.InsertData(
                table: "kitapYazarlari",
                columns: new[] { "Id", "KitapId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 1 },
                    { 4, 4, 3 },
                    { 5, 5, 2 },
                    { 6, 6, 4 },
                    { 7, 7, 3 },
                    { 8, 8, 1 },
                    { 9, 9, 2 },
                    { 10, 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "mesajlar",
                columns: new[] { "Id", "AlanId", "GonderenId", "Icerik", "Konu" },
                values: new object[,]
                {
                    { 1, 1, 2, "Hello!", "Greetings" },
                    { 2, 2, 3, "How are you?", "Checking in" },
                    { 3, 3, 4, "Don't forget our meeting.", "Reminder" },
                    { 4, 4, 1, "Thanks for the book!", "Appreciation" },
                    { 5, 5, 6, "Can you send me the details?", "Request" },
                    { 6, 6, 7, "Let's catch up soon.", "Catch up" },
                    { 7, 7, 8, "See you at the conference!", "Conference" },
                    { 8, 8, 9, "I need your input on the project.", "Project" },
                    { 9, 9, 10, "It was great meeting you!", "Meeting" },
                    { 10, 10, 11, "Welcome to the team!", "Introduction" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_kitapOduncler_KitapId",
                table: "kitapOduncler",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_kitapOduncler_UserId",
                table: "kitapOduncler",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_kitapYayinTalepleri_KitapId",
                table: "kitapYayinTalepleri",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_kitapYayinTalepleri_YazarId",
                table: "kitapYayinTalepleri",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_kitapYazarlari_KitapId",
                table: "kitapYazarlari",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_kitapYazarlari_UserId",
                table: "kitapYazarlari",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_mesajlar_GonderenId",
                table: "mesajlar",
                column: "GonderenId");

            migrationBuilder.CreateIndex(
                name: "IX_sayfalar_KitapId",
                table: "sayfalar",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_users_RolId",
                table: "users",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cezalar");

            migrationBuilder.DropTable(
                name: "hesapAcmaTalepleri");

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
                name: "sayfalar");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "kitaplar");

            migrationBuilder.DropTable(
                name: "roller");
        }
    }
}
