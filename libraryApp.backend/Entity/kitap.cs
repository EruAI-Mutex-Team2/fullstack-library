namespace libraryApp.backend.Entity;
public class kitap
{
    public int Id { get; set; }
    public string Isim { get; set; }
    public bool KitapYayinlandiMi { get; set; }
    public DateTime YayinlanmaTarihi { get; set; }
}