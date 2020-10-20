namespace PhoneDataWarehouse.Dtos
{
    public class RozetkaPhoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RozetkaDisplayDto Display { get; set; }
        public RozetkaMemoryDto Memory { get; set; }
        public int Capacity { get; set; }
        public int CategoryId { get; set; }
        public RozetkaCategoryDto Category { get; set; }
        public decimal Price { get; set; }
        public string DescriptionUrl { get; set; }
        public string ImageUrl { get; set; }

    }
}