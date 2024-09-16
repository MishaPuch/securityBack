using ScurityApp.DAL.Model;
using ScurityApp.DAL.Repositories;

namespace ScurityApp.BLL.Services
{
    public class DepartmentService
    {
        private readonly DepartmentRepository departmentRepository;

        public DepartmentService(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public Task AddDepartmentAsync(Department department)
        {
            return departmentRepository.AddDepartmentAsync(department);
        }

        public Task DeleteDepartmentAsync(int departmentId)
        {
            return departmentRepository.DeleteDepartmentAsync(departmentId);
        }

        public Task<List<Department>> GetAllDepartmentsAsync()
        {
            return departmentRepository.GetAllDepartmentsAsync();
        }

        public Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            return departmentRepository.GetDepartmentByIdAsync(departmentId);
        }

        public Task<List<Department>> GetDepartmentsByCountryIdAsync(int countryId)
        {
            return departmentRepository.GetDepartmentsByCountryIdAsync(countryId);
        }

        public Task UpdateDepartmentAsync(Department department)
        {
            return departmentRepository.UpdateDepartmentAsync(department);
        }
    }
}
