namespace libraryApp.backend.Entity;
public class user
{
    public int Id { get; set; }
    public string Isim { get; set; }
    public string SoyIsim { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RollId { get; set; }

    public rol rol { get; set; }
}