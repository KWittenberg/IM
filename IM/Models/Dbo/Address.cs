using System.ComponentModel.DataAnnotations;

namespace IM.Models.Dbo
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
