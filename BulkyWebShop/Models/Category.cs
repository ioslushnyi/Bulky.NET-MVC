﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
