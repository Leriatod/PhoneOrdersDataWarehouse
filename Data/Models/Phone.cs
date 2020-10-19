using System.ComponentModel.DataAnnotations;

namespace PhoneDataWarehouse.Data.Models
{
    public class Phone
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}