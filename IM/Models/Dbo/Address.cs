using System.ComponentModel.DataAnnotations;
using IM.Models.Base;
using IM.Models.Dbo.Base;

namespace IM.Models.Dbo
{
    public class Address: AddressBase, IEntityBase
    {
        [Key]
        public int Id { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime Created { get; set; }
    }
}
