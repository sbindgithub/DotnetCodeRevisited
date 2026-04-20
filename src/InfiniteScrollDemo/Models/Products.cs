public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
}