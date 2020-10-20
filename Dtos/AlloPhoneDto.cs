namespace PhoneDataWarehouse.Dtos
{
    public class AlloPhoneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal ScreenDiagonal { get; set; }
        public string Resolution { get; set; }
        public int Ram { get; set; }
        public int InternalStorage { get; set; }
        public int Capacity { get; set; }
        public int MakerId { get; set; }
        public AlloMakerDto Maker { get; set; }
        public string OS { get; set; }
        public decimal Price { get; set; }
        public string DescriptionUrl { get; set; }
        public string ImageUrl { get; set; }

    }
}