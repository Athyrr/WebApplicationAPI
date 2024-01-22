using AutoMapper;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Text.Json.Serialization;
using WebApplicationAPI.DTO.FlowerDTO;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerBusiness _flowerBusiness;
        private readonly IMapper _mapper;

        public FlowerController(IFlowerBusiness flowerBusiness, IMapper mapper)
        {
            _flowerBusiness = flowerBusiness;
            _mapper = mapper;
        }
 
        /// <summary>
        /// Get all flowers
        /// </summary>
        /// <returns></returns>
        // GetAll 
        [HttpGet]
        public async Task<ActionResult<List<FlowerDTO>>> GetFlowers()
        {
            var flowers = await _flowerBusiness.GetFlowersAsync();

            var flowersDTO = _mapper.Map<List<FlowerDTO>>(flowers);

            return Ok(flowersDTO);
        }
        


        /// <summary>
        /// Get 1 flower
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //GetById
        [HttpGet("GetFlowerById")]
        public async Task<ActionResult<FlowerDTO>> GetFlowerById(int id)
        {
            var flower = await _flowerBusiness.GetFlowerByIdAsync(id);

            if (flower is null)
            {
                return BadRequest("Cet id n'existe pas");
            }

            var flowerDTO = _mapper.Map<FlowerDTO>(flower);
            return Ok(flowerDTO);
        }


        /// <summary>
        /// Search with props
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        //Search
        [HttpGet("Search")]
        public async Task<ActionResult<List<FlowerDTO>>> Search(string search)
        {
            var flowersSearched = await _flowerBusiness.SearchAsync(search);

            if (flowersSearched.Count == 0)
            {
                return NotFound();
            }

            var flowersDTO = _mapper.Map<List<FlowerDTO>>(flowersSearched);
            return Ok(flowersDTO);
        }
        

        /// <summary>
        /// create using dto
        /// </summary>
        /// <param name="flowerByIdDTO"></param>
        /// <returns></returns>
        //Post
        [HttpPost]
        public async Task<ActionResult<FlowerDTO>> PlantFlower(FlowerByIdDTO flowerByIdDTO)
        {
            try
            {
                var flower = _mapper.Map<Flower>(flowerByIdDTO);
                var flowerPlanted = await _flowerBusiness.PlantFlowerAsync(flower);

                var flowerPlantedDTO = _mapper.Map<FlowerDTO>(flowerPlanted);
                return CreatedAtAction(nameof(GetFlowerById), new { id = flowerPlantedDTO.Id }, flowerPlantedDTO);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Edit using dto
        /// </summary>
        /// <param name="flowerDTO"></param>
        /// <returns></returns>
        //Put
        [HttpPut]
        public async Task<ActionResult<FlowerToChangeDTO>> ChangeFlower(FlowerDTO flowerDTO)
        {
            //Comment savoir quel fleur supprimer si l'id est caché avec FlowerDTO
            //Utilisation va devoir deviner l'id à moins de retourner l'object avec l'id
            //Ou ajouter un numero unique en prop
                var flower = _mapper.Map<Flower>(flowerDTO);
            try
            {
                var flowerToChange = await _flowerBusiness.GetFlowerByIdAsync(flower.Id);

                flowerToChange.Name = flower.Name;
                flowerToChange.NbPetal = flower.NbPetal;

                var flowerEdited = await _flowerBusiness.ChangeFlowerAsync(flowerToChange);

                var flowerEditedDTO = _mapper.Map<FlowerToChangeDTO>(flowerToChange);
                return Ok(flowerEditedDTO);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Delete with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Delete
        [HttpDelete]
        public async Task<ActionResult<string>> BurnFlower(int id)
        {
            try
            {
                string mess = await _flowerBusiness.BurnFlowerAsync(id);

                return Ok(mess);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
