
using Application.Service;
using Application.Service.Dtos.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _depertmentService;

        public DepartmentController(IDepartmentService depertmentService)
        {
            _depertmentService = depertmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get(int page)
        {
            return Ok(await _depertmentService.GetAll(page));
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<DepartmentDto>> ById(int id)
        //{
        //    //try
        //    //{
        //    //    Log.Information("Get department by id");

        //    //    return Ok(await depertmentService.GetById(id));
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Log.Fatal("Argument is not valid", ex.Message);

        //    //    throw new Exception("Server Error");
        //    //}
        //}

        [HttpGet("DepartmentName/{name}")]
        public async Task<ActionResult<DepartmentDto>> DepartmentName(string name)
        {
            return Ok(await _depertmentService.GetByName(name));
        }


        [HttpPost]
        public async Task<ActionResult> AddDepartment([FromBody] AddDepartmentDto data)
        {
            await _depertmentService.AddDepartment(data);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditDepartment(int id, [FromBody] EditDepartmentDto data)
        {
            await _depertmentService.UpdateDepartment(id, data);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _depertmentService.DeleteDepartment(id);
            return Ok();
        }

    }
}
