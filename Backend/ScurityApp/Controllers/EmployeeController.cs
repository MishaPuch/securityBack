using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScurityApp.ApiModel.RequestApiModel;
using ScurityApp.BLL.Services;
using ScurityApp.DAL.Model;
using ScurityApp.DAL.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScurityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;
        private readonly IMapper mapper;
        public EmployeeController(EmployeeService employeeService , IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<Employee>> GetAllEmployee()
        {
            return await employeeService.GetAllEmployeesAsync();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await employeeService.GetEmployeeByIdAsync(id);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{roleId}")]
        public async Task<List<Employee>> GetEmployeesByRoleId(int roleId)
        {
            return await employeeService.GetEmployeesByRoleAsync(roleId);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("login/{login}/{password}")]
        public async Task<ActionResult<Employee>> Login(string login , string password)
        {
             var employee = await employeeService.GetEmployeeByLoginAndPassword(login, password);
            if (employee == null)
            {
                return NoContent();
            }
            return Ok(employee);
             
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post([FromBody] EmployeeRequestApiModel employeeApiModel)
        {
            var employee = mapper.Map<Employee>(employeeApiModel);
            await employeeService.AddEmployeeAsync(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EmployeeRequestApiModel employeeApiModel)
        {
            var employee = mapper.Map<Employee>(employeeApiModel);
            employee.Id = id;
            await employeeService.UpdateEmployeeAsync(employee);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("department/{departmentId}")]
        public async Task<List<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
        {
            return await employeeService.GetEmployeesByDepartmentAsync(departmentId);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await employeeService.DeleteEmployeeAsync(id);
        }
    }
}
