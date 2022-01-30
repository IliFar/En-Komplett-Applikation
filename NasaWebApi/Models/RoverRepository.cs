using System.Collections.Generic;
using System.Linq;

namespace NasaWebApi.Models
{
    public class RoverRepository : IRoverRepository
    {
        IList<Rover> rovers;

        public RoverRepository()
        {
            rovers = new List<Rover>()
            {
                new Rover { Name = "Curiosity", Description = "Something", History = "Something", NasaURL = "https://mars.nasa.gov/system/feature_items/images/6037_msl_banner.jpg", TotalWheels = 4, Weight = 100 },
                new Rover { Name = "Spirit", Description = "Something", History = "Something", NasaURL = "https://d2pn8kiwq2w21t.cloudfront.net/original_images/missionswebmer.jpg", TotalWheels = 4, Weight = 100 },
                new Rover { Name = "Opportunity", Description = "Something", History = "Something", NasaURL = "https://www.spaceflightinsider.com/wp-content/uploads/2019/02/mer-opportunity-going-offline-james-vaughan-18921.jpg", TotalWheels = 4, Weight = 100 }
            };
        }
        public IEnumerable<Rover> GetAll()
        {
            return rovers.ToList();
        }

        public Rover GetById(string id)
        {
            return rovers.FirstOrDefault(r => r.Name.ToLower() == id.ToLower());
        }
    }
}
