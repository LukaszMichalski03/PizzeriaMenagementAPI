using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaManagementAPI.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1,100)]
        public int Price { get; set; }

    }
}
