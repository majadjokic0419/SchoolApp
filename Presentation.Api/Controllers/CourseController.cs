using Application.Service;
using Application.Service.Dtos.Course;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{page}/courses")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get(int page)
        {
            return Ok(await _courseService.GetAll(page));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            return Ok(await _courseService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddCourse([FromBody] AddCourseDto data)
        {
            try
            {
                await _courseService.AddCourse(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}", data, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditCourse(int id, [FromBody] EditCourseDto data)
        {
            try
            {
                await _courseService.UpdateCourse(id, data);
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
                await _courseService.DeleteCourse(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Object with Id: {@id} not found!", id, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPost("studentToCourse")]
        public async Task<ActionResult> AddStudent([FromBody] AddStudentToCourseDto data)
        {
            try
            {
                await _courseService.AddStudentToCourse(data.studentId, data.courseId);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Object sent: {@data}", data, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPost("professorToCourse")]
        public async Task<ActionResult> AddProfessor([FromBody] AddProfessorToCourseDto data)
        {
            try
            {
                await _courseService.AddStudentToCourse(data.professorId, data.courseId);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Object sent: {@data}", data, ex.Message);
                throw new Exception("Server error");
            }
        }

    }
}
