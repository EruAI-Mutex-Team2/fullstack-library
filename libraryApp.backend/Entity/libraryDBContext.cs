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

}
