namespace Models;

public class User
{
      public int Id { get; set; }

      public string Name { get; set; } = "";
[Required]
      public string Email { get; set; } = "";

      public string? Password { get; set; }


      public string Address { get; set; } = "";

      public string Phone { get; set; } = "";

      public bool IsDisabled { get; set; }

      public DateTime CreatedAt { get; set; }
}
