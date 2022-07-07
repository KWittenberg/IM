using System.ComponentModel.DataAnnotations;
using IM.Models.Dbo.Base;

namespace IM.Models.Dbo
{
    public class Address: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime Created { get; set; }
    }
}
