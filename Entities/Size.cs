using System.ComponentModel.DataAnnotations;

namespace PizzeriaManagementAPI.Entities
{
    public class Size
    {
        public int Id { get; set; }
        [Required]
        public int Diameter { get; set; }
        [Required]
        public double PriceModifier { get; set; }
    }
}
