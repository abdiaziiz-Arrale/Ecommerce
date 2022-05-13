namespace Models;

public class Bussiness
{
      public int Id { get; set; }

      public int UserId { get; set; }
      public User User { get; set; } // Navigation property.

      public string Licesnce { get; set; } = "";

      public string Categories { get; set; } = "";

      public string Picture { get; set; } = "";

      public string Bio { get; set; } = "";

      public bool IsVerified { get; set; }

      public DateTime CreatedAt { get; set; }
}
