using ScurityApp.DAL.Model;
using ScurityApp.DAL.Repositories;

namespace ScurityApp.BLL.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Task AddEmployeeAsync(Employee employee)
        {
            return employeeRepository.AddEmployeeAsync(employee);
        }

        public Task DeleteEmployeeAsync(int id)
        {
            return employeeRepository.DeleteEmployeeAsync(id);
        }

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            return employeeRepository.GetAllEmployeesAsync();
        }
        public Task<Employee> GetEmployeeByLoginAndPassword(string login, string password)
        {
            return employeeRepository.GetEmployeeByLoginAndPasswordAsync(login, password);
        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return employeeRepository.GetEmployeeByIdAsync(id);
        }

        public Task<Employee> GetEmployeeByEmailAsync(string email)
        {
            return employeeRepository.GetEmployeeByEmailAsync(email);
        }

        public Task<List<Employee>> GetEmployeesByRoleAsync(int roleId)
        {
            return employeeRepository.GetEmployeesByRoleAsync(roleId);
        }
        public Task<List<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
        {
            return employeeRepository.GetEmployeesByDepartmentAsync(departmentId);
        }
        public Task<Employee> GetEmployeeByDepartmentIdAsync(int departmentId)
        {
            return employeeRepository.GetEmployeeByDepartmentIdAsync(departmentId);
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            return employeeRepository.UpdateEmployeeAsync(employee);
        }
    }
}
