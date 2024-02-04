using System.ComponentModel.DataAnnotations;

namespace PizzeriaManagementAPI.Models
{
    public class SizeDto
    {
        [Required]
        public int Diameter { get; set; }
        [Required]
        public double PriceModifier { get; set; }
    }
}
