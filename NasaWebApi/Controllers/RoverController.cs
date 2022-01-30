using Microsoft.AspNetCore.Mvc;
using NasaWebApi.Models;
using System.Collections.Generic;

namespace NasaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : Controller
    {
        private readonly IRoverRepository roverRepository;

        public RoverController(IRoverRepository roverRepository)
        {
            this.roverRepository = roverRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Rover> rovers = roverRepository.GetAll();

            return Ok(rovers);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            Rover rover = roverRepository.GetById(id);

            if (rover == null) return NotFound();

            return Ok(rover);
        }
    }
}
