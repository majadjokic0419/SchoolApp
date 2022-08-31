
using Application.Service;
using Application.Service.Dtos.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            await _courseService.AddCourse(data);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditCourse(int id, [FromBody] EditCourseDto data)
        {
            await _courseService.UpdateCourse(id,data);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _courseService.DeleteCourse(id);
            return Ok();
        }

        [HttpPost("studentToCourse")]
        public async Task<ActionResult> AddStudent([FromBody] AddStudentToCourseDto data)
        {
            await _courseService.AddStudentToCourse(data.studentId, data.courseId);
            return Ok();
        }

        [HttpPost("professorToCourse")]
        public async Task<ActionResult> AddProfessor([FromBody] AddProfessorToCourseDto data)
        {
            await _courseService.AddStudentToCourse(data.professorId, data.courseId);
            return Ok();
        }

    }
}
