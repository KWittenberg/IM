namespace IM.Models.Base;

public abstract class ProductBase
{
    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Title { get; set; }
    
    public string? Description { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(9, 2)")]
    public decimal Price { get; set; }
}