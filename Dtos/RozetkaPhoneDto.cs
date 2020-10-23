using System;

namespace PhoneDataWarehouse.Dtos
{
    public class RozetkaPhoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public RozetkaContactDto Contact { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string DescriptionUrl { get; set; }

    }
}