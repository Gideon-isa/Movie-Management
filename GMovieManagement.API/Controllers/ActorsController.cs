using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using System.Text.Json;

namespace GMovieManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [Route("getAll")]
        [HttpGet] 
        public async Task<ActionResult> Get() 
        {
            var actorsFromRepo = await _unitOfWork.Actor.GetAll();
            foreach (var item in actorsFromRepo)
            {
                Console.WriteLine(item.FirstName);
            }
            
            return Ok(actorsFromRepo);
        }

        [HttpGet]
        [Route("moives")]

        public async Task<ActionResult> GetWithMovies()
        {
            var result = await _unitOfWork.Actor.GetActorsWithMovies();
            return Ok(result);

        } 
    }
}
