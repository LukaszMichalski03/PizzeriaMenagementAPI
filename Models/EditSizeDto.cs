using System.ComponentModel.DataAnnotations;

namespace PizzeriaManagementAPI.Models
{
    public class EditSizeDto
    {
        [Required]
        public int Diameter { get; set; }
        [Required]
        public double PriceModifier { get; set; }
    }
}
