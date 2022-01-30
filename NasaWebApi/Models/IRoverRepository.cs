using System.Collections.Generic;

namespace NasaWebApi.Models
{
    public interface IRoverRepository
    {
        IEnumerable<Rover> GetAll();
        Rover GetById(string id);
    }
}
