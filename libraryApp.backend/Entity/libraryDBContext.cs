using Microsoft.EntityFrameworkCore;
namespace libraryApp.backend.Entity;
public class libraryDBContext : DbContext
{
    public DbSet<ceza> cezalar => Set<ceza>();
    public DbSet<hesapAcmaTalebi> hesapAcmaTalepleri => Set<hesapAcmaTalebi>();
    public DbSet<kitap> kitaplar => Set<kitap>();
    public DbSet<kitapOdunc> kitapOduncler => Set<kitapOdunc>();
    public DbSet<kitapYayinTalebi> kitapYayinTalepleri => Set<kitapYayinTalebi>();
    public DbSet<kitapYazari> kitapYazarlari => Set<kitapYazari>();
    public DbSet<mesaj> mesajlar => Set<mesaj>();
    public DbSet<puan> puanlar => Set<puan>();
    public DbSet<rol> roller => Set<rol>();
    public DbSet<sayfa> sayfalar => Set<sayfa>();
    public DbSet<user> users => Set<user>();

    public libraryDBContext(DbContextOptions<libraryDBContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ceza>().HasData(
    new ceza { Id = 1, UserId = 2, CezaGunu = DateTime.UtcNow.AddDays(-30), CezaBitisGunu = DateTime.UtcNow.AddDays(-20), CezaAktifMi = false },
    new ceza { Id = 2, UserId = 3, CezaGunu = DateTime.UtcNow.AddDays(-60), CezaBitisGunu = DateTime.UtcNow.AddDays(-50), CezaAktifMi = false },
    new ceza { Id = 3, UserId = 4, CezaGunu = DateTime.UtcNow.AddDays(-90), CezaBitisGunu = DateTime.UtcNow.AddDays(-80), CezaAktifMi = false },
    new ceza { Id = 4, UserId = 5, CezaGunu = DateTime.UtcNow.AddDays(-120), CezaBitisGunu = DateTime.UtcNow.AddDays(-110), CezaAktifMi = false },
    new ceza { Id = 5, UserId = 6, CezaGunu = DateTime.UtcNow.AddDays(-150), CezaBitisGunu = DateTime.UtcNow.AddDays(-140), CezaAktifMi = true },
    new ceza { Id = 6, UserId = 7, CezaGunu = DateTime.UtcNow.AddDays(-180), CezaBitisGunu = DateTime.UtcNow.AddDays(-170), CezaAktifMi = false },
    new ceza { Id = 7, UserId = 8, CezaGunu = DateTime.UtcNow.AddDays(-210), CezaBitisGunu = DateTime.UtcNow.AddDays(-200), CezaAktifMi = false },
    new ceza { Id = 8, UserId = 9, CezaGunu = DateTime.UtcNow.AddDays(-240), CezaBitisGunu = DateTime.UtcNow.AddDays(-230), CezaAktifMi = true },
    new ceza { Id = 9, UserId = 10, CezaGunu = DateTime.UtcNow.AddDays(-270), CezaBitisGunu = DateTime.UtcNow.AddDays(-260), CezaAktifMi = false },
    new ceza { Id = 10, UserId = 11, CezaGunu = DateTime.UtcNow.AddDays(-300), CezaBitisGunu = DateTime.UtcNow.AddDays(-290), CezaAktifMi = true }
);

        modelBuilder.Entity<hesapAcmaTalebi>().HasData(
            new hesapAcmaTalebi { Id = 1, UserId = 4, TalepTarihi = DateTime.UtcNow.AddDays(-5), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 2, UserId = 5, TalepTarihi = DateTime.UtcNow.AddDays(-2), OnaylandiMi = false, BeklemedeMi = true },
            new hesapAcmaTalebi { Id = 3, UserId = 6, TalepTarihi = DateTime.UtcNow.AddDays(-8), OnaylandiMi = false, BeklemedeMi = true },
            new hesapAcmaTalebi { Id = 4, UserId = 7, TalepTarihi = DateTime.UtcNow.AddDays(-15), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 5, UserId = 8, TalepTarihi = DateTime.UtcNow.AddDays(-20), OnaylandiMi = false, BeklemedeMi = true },
            new hesapAcmaTalebi { Id = 6, UserId = 9, TalepTarihi = DateTime.UtcNow.AddDays(-25), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 7, UserId = 10, TalepTarihi = DateTime.UtcNow.AddDays(-30), OnaylandiMi = false, BeklemedeMi = true },
            new hesapAcmaTalebi { Id = 8, UserId = 11, TalepTarihi = DateTime.UtcNow.AddDays(-35), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 9, UserId = 12, TalepTarihi = DateTime.UtcNow.AddDays(-40), OnaylandiMi = false, BeklemedeMi = true },
            new hesapAcmaTalebi { Id = 10, UserId = 13, TalepTarihi = DateTime.UtcNow.AddDays(-45), OnaylandiMi = true, BeklemedeMi = false }
        );

        modelBuilder.Entity<kitap>().HasData(
            new kitap { Id = 1, Isim = "The Art of Coding", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-365) },
            new kitap { Id = 2, Isim = "Mastering Algorithms", KitapYayinlandiMi = false, YayinlanmaTarihi = DateTime.UtcNow },
            new kitap { Id = 3, Isim = "Clean Code", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-180) },
            new kitap { Id = 4, Isim = "Refactoring", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-200) },
            new kitap { Id = 5, Isim = "Design Patterns", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-300) },
            new kitap { Id = 6, Isim = "Introduction to Algorithms", KitapYayinlandiMi = false, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-10) },
            new kitap { Id = 7, Isim = "Data Structures and Algorithms", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-365) },
            new kitap { Id = 8, Isim = "Agile Software Development", KitapYayinlandiMi = false, YayinlanmaTarihi = DateTime.UtcNow },
            new kitap { Id = 9, Isim = "The Pragmatic Programmer", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-200) },
            new kitap { Id = 10, Isim = "Effective Java", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-250) }
        );

        modelBuilder.Entity<kitapOdunc>().HasData(
            new kitapOdunc { Id = 1, KitapId = 1, UserId = 2, TalepTarihi = DateTime.UtcNow.AddDays(-7), DonusTarihi = DateTime.UtcNow.AddDays(7), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 2, KitapId = 2, UserId = 3, TalepTarihi = DateTime.UtcNow.AddDays(-10), DonusTarihi = DateTime.UtcNow.AddDays(10), OnaylandiMi = false, BeklemedeMi = true, DondurulduMu = false },
            new kitapOdunc { Id = 3, KitapId = 3, UserId = 4, TalepTarihi = DateTime.UtcNow.AddDays(-12), DonusTarihi = DateTime.UtcNow.AddDays(12), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = true },
            new kitapOdunc { Id = 4, KitapId = 4, UserId = 5, TalepTarihi = DateTime.UtcNow.AddDays(-15), DonusTarihi = DateTime.UtcNow.AddDays(15), OnaylandiMi = false, BeklemedeMi = true, DondurulduMu = false },
            new kitapOdunc { Id = 5, KitapId = 5, UserId = 6, TalepTarihi = DateTime.UtcNow.AddDays(-18), DonusTarihi = DateTime.UtcNow.AddDays(18), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 6, KitapId = 6, UserId = 7, TalepTarihi = DateTime.UtcNow.AddDays(-20), DonusTarihi = DateTime.UtcNow.AddDays(20), OnaylandiMi = false, BeklemedeMi = true, DondurulduMu = false },
            new kitapOdunc { Id = 7, KitapId = 7, UserId = 8, TalepTarihi = DateTime.UtcNow.AddDays(-22), DonusTarihi = DateTime.UtcNow.AddDays(22), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false }
        );

        modelBuilder.Entity<kitapYayinTalebi>().HasData(
    new kitapYayinTalebi { Id = 1, KitapId = 1, YazarId = 1, TalepTarihi = DateTime.UtcNow.AddDays(-3), OnaylandiMi = true, BeklemedeMi = false },
    new kitapYayinTalebi { Id = 2, KitapId = 2, YazarId = 2, TalepTarihi = DateTime.UtcNow.AddDays(-6), OnaylandiMi = false, BeklemedeMi = true },
    new kitapYayinTalebi { Id = 3, KitapId = 3, YazarId = 1, TalepTarihi = DateTime.UtcNow.AddDays(-9), OnaylandiMi = false, BeklemedeMi = true },
    new kitapYayinTalebi { Id = 4, KitapId = 4, YazarId = 3, TalepTarihi = DateTime.UtcNow.AddDays(-12), OnaylandiMi = true, BeklemedeMi = false },
    new kitapYayinTalebi { Id = 5, KitapId = 5, YazarId = 2, TalepTarihi = DateTime.UtcNow.AddDays(-15), OnaylandiMi = false, BeklemedeMi = true },
    new kitapYayinTalebi { Id = 6, KitapId = 6, YazarId = 1, TalepTarihi = DateTime.UtcNow.AddDays(-18), OnaylandiMi = false, BeklemedeMi = true },
    new kitapYayinTalebi { Id = 7, KitapId = 7, YazarId = 4, TalepTarihi = DateTime.UtcNow.AddDays(-21), OnaylandiMi = true, BeklemedeMi = false },
    new kitapYayinTalebi { Id = 8, KitapId = 8, YazarId = 3, TalepTarihi = DateTime.UtcNow.AddDays(-24), OnaylandiMi = false, BeklemedeMi = true },
    new kitapYayinTalebi { Id = 9, KitapId = 9, YazarId = 2, TalepTarihi = DateTime.UtcNow.AddDays(-27), OnaylandiMi = true, BeklemedeMi = false },
    new kitapYayinTalebi { Id = 10, KitapId = 10, YazarId = 1, TalepTarihi = DateTime.UtcNow.AddDays(-30), OnaylandiMi = false, BeklemedeMi = true }
);

        modelBuilder.Entity<kitapYazari>().HasData(
            new kitapYazari { Id = 1, KitapId = 1, UserId = 1 },
            new kitapYazari { Id = 2, KitapId = 2, UserId = 2 },
            new kitapYazari { Id = 3, KitapId = 3, UserId = 1 },
            new kitapYazari { Id = 4, KitapId = 4, UserId = 3 },
            new kitapYazari { Id = 5, KitapId = 5, UserId = 2 },
            new kitapYazari { Id = 6, KitapId = 6, UserId = 4 },
            new kitapYazari { Id = 7, KitapId = 7, UserId = 3 },
            new kitapYazari { Id = 8, KitapId = 8, UserId = 1 },
            new kitapYazari { Id = 9, KitapId = 9, UserId = 2 },
            new kitapYazari { Id = 10, KitapId = 10, UserId = 3 }
        );

        modelBuilder.Entity<mesaj>().HasData(
            new mesaj { Id = 1, AlanId = 1, GonderenId = 2, Icerik = "Hello!", Konu = "Greetings" },
            new mesaj { Id = 2, AlanId = 2, GonderenId = 3, Icerik = "How are you?", Konu = "Checking in" },
            new mesaj { Id = 3, AlanId = 3, GonderenId = 4, Icerik = "Don't forget our meeting.", Konu = "Reminder" },
            new mesaj { Id = 4, AlanId = 4, GonderenId = 1, Icerik = "Thanks for the book!", Konu = "Appreciation" },
            new mesaj { Id = 5, AlanId = 5, GonderenId = 6, Icerik = "Can you send me the details?", Konu = "Request" },
            new mesaj { Id = 6, AlanId = 6, GonderenId = 7, Icerik = "Let's catch up soon.", Konu = "Catch up" },
            new mesaj { Id = 7, AlanId = 7, GonderenId = 8, Icerik = "See you at the conference!", Konu = "Conference" },
            new mesaj { Id = 8, AlanId = 8, GonderenId = 9, Icerik = "I need your input on the project.", Konu = "Project" },
            new mesaj { Id = 9, AlanId = 9, GonderenId = 10, Icerik = "It was great meeting you!", Konu = "Meeting" },
            new mesaj { Id = 10, AlanId = 10, GonderenId = 11, Icerik = "Welcome to the team!", Konu = "Introduction" }
        );

        modelBuilder.Entity<puan>().HasData(
            new puan { Id = 1, KazanilanPuan = 1000, PuanGunu = DateTime.UtcNow.AddDays(-1), UserId = 1 },
            new puan { Id = 2, KazanilanPuan = 2000, PuanGunu = DateTime.UtcNow.AddDays(-2), UserId = 2 },
            new puan { Id = 3, KazanilanPuan = 1500, PuanGunu = DateTime.UtcNow.AddDays(-3), UserId = 3 },
            new puan { Id = 4, KazanilanPuan = 2500, PuanGunu = DateTime.UtcNow.AddDays(-4), UserId = 4 },
            new puan { Id = 5, KazanilanPuan = 3000, PuanGunu = DateTime.UtcNow.AddDays(-5), UserId = 5 },
            new puan { Id = 6, KazanilanPuan = 3500, PuanGunu = DateTime.UtcNow.AddDays(-6), UserId = 6 },
            new puan { Id = 7, KazanilanPuan = 4000, PuanGunu = DateTime.UtcNow.AddDays(-7), UserId = 7 },
            new puan { Id = 8, KazanilanPuan = 4500, PuanGunu = DateTime.UtcNow.AddDays(-8), UserId = 8 },
            new puan { Id = 9, KazanilanPuan = 5000, PuanGunu = DateTime.UtcNow.AddDays(-9), UserId = 9 },
            new puan { Id = 10, KazanilanPuan = 5500, PuanGunu = DateTime.UtcNow.AddDays(-10), UserId = 10 }
        );

        modelBuilder.Entity<rol>().HasData(
            new rol { Id = 1, RolIsmi = "uye" },
            new rol { Id = 2, RolIsmi = "yazar" },
            new rol { Id = 3, RolIsmi = "gorevli" },
            new rol { Id = 4, RolIsmi = "yonetici" }
        );

        modelBuilder.Entity<sayfa>().HasData(
            new sayfa { Id = 1, Icerik = "Ana Sayfa", SayfaNo = 1, KitapId = 1 },
            new sayfa { Id = 2, Icerik = "Kitaplar", SayfaNo = 2, KitapId = 1 },
            new sayfa { Id = 3, Icerik = "Kullanıcılar", SayfaNo = 3, KitapId = 1 },
            new sayfa { Id = 4, Icerik = "Yazarlar", SayfaNo = 4, KitapId = 1 },
            new sayfa { Id = 5, Icerik = "Ödünç Alma", SayfaNo = 5, KitapId = 1 },
            new sayfa { Id = 6, Icerik = "Mesajlar", SayfaNo = 6, KitapId = 1 },
            new sayfa { Id = 7, Icerik = "Ayarlar", SayfaNo = 7, KitapId = 1 },
            new sayfa { Id = 8, Icerik = "Yardım", SayfaNo = 8, KitapId = 1 },
            new sayfa { Id = 9, Icerik = "Hesap Yönetimi", SayfaNo = 9, KitapId = 1 },
            new sayfa { Id = 10, Icerik = "Çıkış", SayfaNo = 10, KitapId = 1 }
        );

        modelBuilder.Entity<user>().HasData(
            new user { Id = 1, Isim = "Ahmet", SoyIsim = "Yılmaz", Email = "ahmet.yilmaz@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 2, Isim = "Mehmet", SoyIsim = "Kara", Email = "mehmet.kara@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 3, Isim = "Ayşe", SoyIsim = "Çelik", Email = "ayse.celik@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 2 },
            new user { Id = 4, Isim = "Fatma", SoyIsim = "Koç", Email = "fatma.koc@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 5, Isim = "Emre", SoyIsim = "Demir", Email = "emre.demir@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 6, Isim = "Seda", SoyIsim = "Aydın", Email = "seda.aydin@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 2 },
            new user { Id = 7, Isim = "Oğuz", SoyIsim = "Polat", Email = "oguz.polat@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 8, Isim = "Zeynep", SoyIsim = "Güneş", Email = "zeynep.gunes@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 9, Isim = "Can", SoyIsim = "Arslan", Email = "can.arslan@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 2 },
            new user { Id = 10, Isim = "Merve", SoyIsim = "Sönmez", Email = "merve.sonmez@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 11, Isim = "Ali", SoyIsim = "Ak", Email = "ali.ak@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 12, Isim = "Berk", SoyIsim = "Öztürk", Email = "berk.ozturk@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 13, Isim = "Ayla", SoyIsim = "Yalçın", Email = "ayla.yalcin@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 2 },
            new user { Id = 14, Isim = "Emine", SoyIsim = "Çınar", Email = "emine.cinar@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 15, Isim = "Serdar", SoyIsim = "Toprak", Email = "serdar.toprak@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },

            new user { Id = 16, Isim = "Türker", SoyIsim = "Kıvılcım", Email = "yonetici@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 4 },
            new user { Id = 17, Isim = "Melek", SoyIsim = "Altun", Email = "gorevli@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 3 },
            new user { Id = 18, Isim = "Ebrar", SoyIsim = "Saygılı", Email = "yazar@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 2 },
            new user { Id = 19, Isim = "Zehra", SoyIsim = "Akdemir", Email = "uye@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 }

        );

    }
}