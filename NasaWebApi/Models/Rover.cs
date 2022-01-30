namespace NasaWebApi.Models
{
    public class Rover
    {
        public string Name { get; set; }
        public string NasaURL { get; set; }

        public string Description { get; set; }
        public string History { get; set; }
        public int Weight { get; set; }
        public int TotalWheels { get; set; }
    }
}
