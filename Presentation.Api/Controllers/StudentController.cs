
using Application.Service;
using Application.Service.Dtos.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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

        [HttpGet("{page}/students")]
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
            try
            {
                await _studentService.AddStudent(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}", data, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EditStudentDto data)
        {
            try
            {
                await _studentService.UpdateStudent(id, data);
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
                await _studentService.DeleteStudent(id);
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
