namespace Models;

public class Product
{
      public int Id { get; set; }

      public int UserId { get; set; }
      public User User { get; set; }

      public string ProductName { get; set; } = "";
      public string ProductDescription { get; set; } = "";

      public decimal ProductAmmount { get; set; }

      public decimal Commission { get; set; }

      public decimal BussinessRevenue { get; set; }

      public string TransactionId { get; set; } = "";

      public string PaymentMethod { get; set; } = "";

      public bool IsCompleted { get; set; }

      public DateTime CreatedAt { get; set; }
}
