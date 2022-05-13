namespace Models;

public class Ticket
{
	public int Id { get; set; }

	public int ProductId { get; set; }
	public Product product { get; set; } = new();


	public DateTime CreatedAt { get; set; }
}
