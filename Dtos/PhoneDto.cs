namespace PhoneDataWarehouse.Dtos
{
    public class PhoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MemoryDto Memory { get; set; }
        public DisplayDto Display { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public string DescriptionUrl { get; set; }

    }
}