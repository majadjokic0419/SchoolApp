
using Application.Service;
using Application.Service.Dtos.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{page}")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> Get(int page)
        {
            return Ok(await _studentService.GetAll(page));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> StudentById(int id)
        {
            return Ok(await _studentService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] AddStudentDto data)
        {
            await _studentService.AddStudent(data);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EditStudentDto data)
        {
            await _studentService.UpdateStudent(id, data);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _studentService.DeleteStudent(id);
            return Ok();
        }
    }
}
