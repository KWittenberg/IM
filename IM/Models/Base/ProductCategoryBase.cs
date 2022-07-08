﻿using System.ComponentModel.DataAnnotations;

namespace IM.Models.Base
{
    public abstract class ProductCategoryBase
    {
        [Required(ErrorMessage = "Obavezan unos!")]
        public string Title { get; set; } 
        public string? Description { get; set; }
    }
}
