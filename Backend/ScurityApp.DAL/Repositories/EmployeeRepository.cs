using Microsoft.EntityFrameworkCore;
using ScurityApp.DAL.Model;


namespace ScurityApp.DAL.Repositories
{
    public class EmployeeRepository
    {
        private readonly AppDbContext dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await GetEmployeeByIdAsync(id);
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await dbContext.Employees.Include(x => x.Role).Include(x => x.Department).ThenInclude(x=>x.Country).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByDepartmentIdAsync(int departmentId)
        {
            return await dbContext.Employees.Include(x => x.Role).Include(x => x.Department).ThenInclude(x => x.Country).FirstOrDefaultAsync(e => e.DepartmentId == departmentId);
        }

        public async Task<Employee> GetEmployeeByEmailAsync(string email)
        {
            return await dbContext.Employees.Include(x => x.Role).Include(x => x.Department).ThenInclude(x=>x.Country).FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await dbContext.Employees.Include(x => x.Role).Include(x => x.Department).ThenInclude(x=>x.Country).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
        {
            return await dbContext.Employees.Include(x => x.Role).Include(x => x.Department).ThenInclude(x => x.Country).Where(x=>x.DepartmentId==departmentId).ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesByRoleAsync(int roleId)
        {
            return await dbContext.Employees.Include(x => x.Role).Include(x => x.Department).ThenInclude(x => x.Country).Where(e => e.RoleId == roleId).ToListAsync();
        }
        public async Task<Employee> GetEmployeeByLoginAndPasswordAsync(string login, string password)
        {
            var employee= await dbContext.Employees
                .Include(x => x.Role)
                .Include(x => x.Department).ThenInclude(x => x.Country)
                .FirstOrDefaultAsync(e => e.Login == login && e.Password==password);
            if (employee is not null)
            {
                return employee;
            }
            else
            {
                return new Employee();
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
        }
    }
}
