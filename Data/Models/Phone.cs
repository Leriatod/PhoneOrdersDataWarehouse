using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneDataWarehouse.Data.Models
{
    public class Phone
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Column(TypeName = "DECIMAL(4, 2)")]
        public decimal ScreenSize { get; set; }
        [Required]
        [StringLength(255)]
        public string Resolution { get; set; }
        public int Ram { get; set; }
        public int InternalStorage { get; set; }
        public int Capacity { get; set; }
        [Required]
        [StringLength(255)]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(255)]
        public string OS { get; set; }
        [Column(TypeName = "SMALLMONEY")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(255)]
        public string DescriptionUrl { get; set; }
        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }
    }
}