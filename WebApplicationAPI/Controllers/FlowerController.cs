using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repositories.Contracts;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerRepository _flowerRepository;

        public FlowerController(IFlowerRepository flowerRepository)
        {
            _flowerRepository = flowerRepository;
        }

        // GetAll 
        [HttpGet]
        public async Task<ActionResult<List<Flower>>> GetFlowers()
        {
            var flowers = await _flowerRepository.GetFlowers();

            return Ok(flowers);
        }

        //GetById
        [HttpGet("GetFlowerById")]
        public async Task<ActionResult<Flower>> GetFlowerById(int id)
        {
            var flower = await _flowerRepository.GetFlowerById(id);

            if (flower is null)
            {
                return NotFound();
            }
            return Ok(flower);
        }

        //Search
        [HttpGet("Search")]
        public async Task<ActionResult<List<Flower>>> Search(string search)
        {
            var flowersSearched = await _flowerRepository.Search(search);
            return Ok(flowersSearched);
        }

        //Post
        [HttpPost]
        public async Task<ActionResult<Flower>> PlantFlower(Flower flower)
        {
            await _flowerRepository.PlantFlower(flower);
            return Ok(flower);
        }


        //Put
        [HttpPut]
        public async Task<ActionResult<Flower>> ChangeFlower(Flower flower)
        {
            Flower flowerToChange = await _flowerRepository.GetFlowerById(flower.Id);

            flowerToChange.Name = flower.Name;
            flowerToChange.NbPetal = flower.NbPetal;

            await _flowerRepository.ChangeFlower(flowerToChange);

            return Ok(flowerToChange);
        }

        //Delete
        [HttpDelete]

        public async Task<ActionResult<Flower>> BurnFlower(int id)
        {
            await _flowerRepository.BurnFlower(id);

            return Ok();
        }

    }
}
