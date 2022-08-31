
using Application.Infrastructure.Services;
using Application.Service;
using Application.Service.Dtos.Department;
using Microsoft.AspNetCore.Mvc;
using Serilog;
//using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("{page}/departments)")]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get(int page)
        {
            return Ok(await _departmentService.GetAll(page));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> DepartmentById(int id)
        {
            return Ok(await _departmentService.GetById(id));
        }

        [HttpGet("DepartmentName/{name}")]
        public async Task<ActionResult<DepartmentDto>> DepartmentName(string name)
        {
            return Ok(await _departmentService.GetByName(name));
        }


        [HttpPost]
        public async Task<ActionResult> AddDepartment([FromBody] AddDepartmentDto data)
        {
            try
            {
                await _departmentService.AddDepartment(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}", data, ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditDepartment(int id, [FromBody] EditDepartmentDto data)
        {
            try
            {
                await _departmentService.UpdateDepartment(id, data);
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
                await _departmentService.DeleteDepartment(id);
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
