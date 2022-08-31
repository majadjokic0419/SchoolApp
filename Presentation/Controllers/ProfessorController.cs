
using Application.Service;
using Application.Service.Dtos.Professor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{page}")]
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
            await _professorService.AddProfessor(data);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditProfessor(int id, [FromBody] EditProfessorDto data)
        {
            await _professorService.UpdateProfessor(id, data);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _professorService.DeleteProfessor(id);
            return Ok();
        }
    }
}
