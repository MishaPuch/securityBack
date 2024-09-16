using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ScurityApp.ApiModel.RequestApiModel;
using ScurityApp.BLL.Services;
using ScurityApp.DAL.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScurityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService departmentService;
        private readonly IMapper mapper;
        public DepartmentController(DepartmentService departmentService, IMapper mapper)
        {
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<List<Department>> Get()
        {
            return await departmentService.GetAllDepartmentsAsync();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            return await departmentService.GetDepartmentByIdAsync(id);
        }

        [HttpGet("country/{id}")]
        public async Task<List<Department>> GetDepartmentsByCountry(int id)
        {
            return await departmentService.GetDepartmentsByCountryIdAsync(id);
        }

        // POST api/<DepartmentController>
        [HttpPost()]
        public async Task Post([FromBody] DepartmentRequestApiModel value)
        {
            var department=mapper.Map<Department>(value);

            await departmentService.AddDepartmentAsync(department);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] DepartmentRequestApiModel value)
        {
            var department = mapper.Map<Department>(value);
            department.Id = id;

            await departmentService.UpdateDepartmentAsync(department);
        }


        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {   
            await departmentService.DeleteDepartmentAsync(id);
        }
    }
}
