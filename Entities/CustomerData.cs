using System.ComponentModel.DataAnnotations;

namespace PizzeriaManagementAPI.Entities
{
    public class CustomerData
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(9)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required]
        [MaxLength(5)]
        public string HouseNumber { get; set; }

        [MaxLength(6)]
        public string PostalCode { get; set; }
        public Order Order { get; set; }
    }
}
