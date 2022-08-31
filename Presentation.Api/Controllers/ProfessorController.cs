
using Application.Service;
using Application.Service.Dtos.Professor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet("{page}/professors")]
        public async Task<ActionResult<IEnumerable<ProfessorDto>>> Get(int page)
        {
            return Ok(await _professorService.GetAll(page));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorDto>> ProfessorById(int id)
        {
            return Ok(await _professorService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddProfessor([FromBody] AddProfessorDto data)
        {
            try
            {
                await _professorService.AddProfessor(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}", data, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditProfessor(int id, [FromBody] EditProfessorDto data)
        {
            try
            {
                await _professorService.UpdateProfessor(id, data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}, Object with id:{@id} not found!", data, id, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _professorService.DeleteProfessor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Object with Id: {@id} not found!", id, ex.Message);
                throw new Exception("Server error");
            }
        }
    }
}
