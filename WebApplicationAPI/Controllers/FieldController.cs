using AutoMapper;
using Business;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.DTO.FieldDTO;

namespace WebApplicationAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IFieldBusiness _fieldBusiness;
        private readonly IMapper _mapper;

        public FieldController(IFieldBusiness fieldBusiness, IMapper mapper)
        {
            _fieldBusiness = fieldBusiness;
            _mapper = mapper;
        }



        // GetAll 
        [HttpGet]
        public async Task<ActionResult<List<Field>>> GetFields()
        {
            var fields = await _fieldBusiness.GetFieldsAsync();

            var fieldDTO = _mapper.Map<List<FieldDTO>>(fields);

            return Ok(fieldDTO);
        }


        //GetById
        [HttpGet("GetFieldById")]
        public async Task<ActionResult<Field>> GetFieldById(int id)
        {
            var field = await _fieldBusiness.GetFieldByIdAsync(id);

            if (field is null)
            {
                return BadRequest("Cet id n'existe pas");
            }

            var fieldByIdDTO = _mapper.Map<FieldByIdDTO>(field);
            return Ok(fieldByIdDTO);
        }


        //Search
        [HttpGet("Search")]
        public async Task<ActionResult<List<FieldDTO>>> Search(string search)
        {
            var fieldsSearched = await _fieldBusiness.SearchAsync(search);

            if (fieldsSearched.Count == 0)
            {
                return NotFound();
            }

            var fieldsDTO = _mapper.Map<List<FieldDTO>>(fieldsSearched);
            return Ok(fieldsDTO);
        }


        //Post
        [HttpPost]
        public async Task<ActionResult<FieldDTO>> CreateField(FieldToAddDTO fieldToAddDTO)
        {
            try
            {
                var field = _mapper.Map<Field>(fieldToAddDTO);
                var fieldAdded = await _fieldBusiness.CreateFieldAsync(field);

                var fieldDTO = _mapper.Map<FieldDTO>(fieldAdded);

                return CreatedAtAction(nameof(GetFieldById), new { id = fieldDTO.Id }, fieldDTO);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        //Put
        [HttpPut]
        public async Task<ActionResult<FieldDTO>> ChangeField(FieldDTO fieldDTO)
        {
            //Comment savoir quel fleur supprimer si l'id est caché avec FlowerDTO
            //Utilisation va devoir deviner l'id à moins de retourner l'object avec l'id
            //Ou ajouter un numero unique en prop

                var field = _mapper.Map<Field>(fieldDTO);
            try
            {
                var fieldToChange = await _fieldBusiness.GetFieldByIdAsync(field.Id);

                fieldToChange.Name = field.Name;
                fieldToChange.Area = field.Area;

               var fieldEdited =  await _fieldBusiness.ChangeFieldAsync(fieldToChange);

                var fieldEditedDTO = _mapper.Map<FieldDTO>(fieldEdited);
                return Ok(fieldDTO); //With ID
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        //Delete
        [HttpDelete]
        public async Task<ActionResult<string>> BurnField(int id)
        {
            try
            {
                string mess = await _fieldBusiness.BurnFieldAsync(id);

                return Ok(mess);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
