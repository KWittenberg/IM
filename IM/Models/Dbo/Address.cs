namespace IM.Models.Dbo;

public class Address : AddressBase, IEntityBase
{
    [Key]
    public int Id { get; set; }
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }

    public DateTime Created { get; set; }
}