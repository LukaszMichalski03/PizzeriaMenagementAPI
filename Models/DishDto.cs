﻿using System.ComponentModel.DataAnnotations;

namespace PizzeriaManagementAPI.Models
{
    public class DishDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int Price { get; set; }
    }
}
