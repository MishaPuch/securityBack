using Microsoft.EntityFrameworkCore;
using ScurityApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScurityApp.DAL.Repositories
{
    public class ShiftRepository
    {
        private readonly AppDbContext dbContext;

        public ShiftRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddShiftAsync(Shift shift)
        {
            await dbContext.Shifts.AddAsync(shift);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteShiftAsync(int id)
        {
            var shift = await dbContext.Shifts.FindAsync(id);
            if (shift != null)
            {
                dbContext.Shifts.Remove(shift);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Shift>> GetAllShiftsAsync()
        {
            return await dbContext.Shifts.Include(x => x.Employee).ThenInclude(x => x.Department).ThenInclude(x=>x.Country).Include(x=>x.Employee.Role).Include(x=>x.WorkSchedule).ThenInclude(x=>x.SecurityObject).ToListAsync();
        }
        public async Task<List<Shift>> GetShiftsByDepartmentAsync(int departmentId)
        {
            return await dbContext.Shifts.Include(x => x.Employee).ThenInclude(x => x.Department).ThenInclude(x => x.Country).Include(x => x.Employee.Role).Include(x => x.WorkSchedule).ThenInclude(x => x.SecurityObject).Where(ws => ws.Employee.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<List<Shift>> GetEmployeeShiftsAsync(int employeeId)
        {
            return await dbContext.Shifts.Include(x => x.Employee).ThenInclude(x => x.Department).ThenInclude(x => x.Country).Include(x => x.Employee.Role).Include(x => x.WorkSchedule).ThenInclude(x => x.SecurityObject).Where(ws => ws.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<Shift> GetShiftByIdAsync(int id)
        {
            return await dbContext.Shifts.Include(x => x.Employee).ThenInclude(x => x.Department).ThenInclude(x => x.Country).Include(x => x.Employee.Role).Include(x => x.WorkSchedule).ThenInclude(x => x.SecurityObject).FirstOrDefaultAsync(ws => ws.Id == id);
        }

        public async Task UpdateShiftAsync(Shift shift)
        {

            dbContext.Shifts.Update(shift);
            await dbContext.SaveChangesAsync();
        }
    }
}
