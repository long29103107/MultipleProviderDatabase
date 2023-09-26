namespace Basket.Service.DTO;
public sealed class BasketReponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime DeletedAt { get; set; }
}
