using Microsoft.EntityFrameworkCore;
using ScurityApp.DAL.Model;


namespace ScurityApp.DAL.Repositories
{
    public class DepartmentRepository
    {
        private readonly AppDbContext dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await dbContext.Departments.AddAsync(department);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int departmentId)
        {
            var employees = dbContext.Employees.Where(e => e.DepartmentId == departmentId).ToList();
            foreach (var employee in employees)
            {
                employee.DepartmentId = null; 
            }

            var department = await dbContext.Departments.FindAsync(departmentId);
            if (department != null)
            {
                dbContext.Departments.Remove(department);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await dbContext.Departments.Include(x=>x.Country).ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            return await dbContext.Departments.Include(x => x.Country).FirstOrDefaultAsync(x => x.Id == departmentId);
        }

        public async Task<List<Department>> GetDepartmentsByCountryIdAsync(int countryId)
        {
            return await dbContext.Departments.Where(x => x.CountryId == countryId).Include(x => x.Country).ToListAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            dbContext.Departments.Update(department);
            await dbContext.SaveChangesAsync();
        }
    }
}
