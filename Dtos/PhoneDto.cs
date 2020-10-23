using System;

namespace PhoneDataWarehouse.Dtos
{
    public class PhoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContactDto Contact { get; set; }
        public decimal Price { get; set; }
        public string DescriptionUrl { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}