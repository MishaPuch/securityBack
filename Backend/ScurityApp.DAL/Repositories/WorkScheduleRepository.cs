using Microsoft.EntityFrameworkCore;
using ScurityApp.DAL.Model;

namespace ScurityApp.DAL.Repositories
{
    public class WorkScheduleRepository
    {
        private readonly AppDbContext dbContext;

        public WorkScheduleRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddWorkScheduleAsync(WorkSchedule workSchedule)
        {
            await dbContext.WorkSchedules.AddAsync(workSchedule);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteWorkScheduleAsync(int id)
        {
            var workSchedule = await dbContext.WorkSchedules.FindAsync(id);
            if (workSchedule != null)
            {
                dbContext.WorkSchedules.Remove(workSchedule);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<WorkSchedule>> GetAllWorkSchedulesAsync()
        {
            return await dbContext.WorkSchedules.Include(x=>x.SecurityObject).ThenInclude(x=>x.Department).ToListAsync();
        }

        public async Task<List<WorkSchedule>> GetWorkScheduleBySecuredObjectIdAsync(int securityObjectId)
        {
            return await dbContext.WorkSchedules.Include(x => x.SecurityObject).ThenInclude(x => x.Department).Where(ws => ws.SecurityObjectId == securityObjectId).ToListAsync();
        }

        public async Task<WorkSchedule> GetWorkScheduleByIdAsync(int id)
        {
            return await dbContext.WorkSchedules.Include(x => x.SecurityObject).ThenInclude(x => x.Department).FirstOrDefaultAsync(ws => ws.Id == id);
        }

        public async Task<List<WorkSchedule>> GetWorkScheduleByDepartmentIdAsync(int departmentId)
        {
            return await dbContext.WorkSchedules.Include(x => x.SecurityObject).ThenInclude(x => x.Department).Where(ws => ws.SecurityObject.DepartmentId == departmentId).ToListAsync();
        }

        public async Task UpdateWorkScheduleAsync(WorkSchedule workSchedule)
        {
            dbContext.WorkSchedules.Update(workSchedule);
            await dbContext.SaveChangesAsync();
        }
    }
}
