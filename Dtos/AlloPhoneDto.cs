using System;

namespace PhoneDataWarehouse.Dtos
{
    public class AlloPhoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AlloBuyerDto Buyer { get; set; }
        public decimal Price { get; set; }
        public string DescriptionUrl { get; set; }
        public DateTime Date { get; set; }
    }
}