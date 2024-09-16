using ScurityApp.DAL.Model;
using ScurityApp.DAL.Repositories;

namespace ScurityApp.BLL.Services
{
    public class WorkScheduleService
    {
        private readonly WorkScheduleRepository workScheduleRepository;

        public WorkScheduleService(WorkScheduleRepository workScheduleRepository)
        {
            this.workScheduleRepository = workScheduleRepository;
        }

        public Task AddWorkScheduleAsync(WorkSchedule workSchedule)
        {
            return workScheduleRepository.AddWorkScheduleAsync(workSchedule);
        }

        public Task DeleteWorkScheduleAsync(int id)
        {
            return workScheduleRepository.DeleteWorkScheduleAsync(id);
        }

        public Task<List<WorkSchedule>> GetAllWorkSchedulesAsync()
        {
            return workScheduleRepository.GetAllWorkSchedulesAsync();
        }
        public Task<List<WorkSchedule>> GetWorkScheduleByDepartmentIdAsync(int departmentId)
        {
            return workScheduleRepository.GetWorkScheduleByDepartmentIdAsync(departmentId);
        }

        public Task<List<WorkSchedule>> GetWorkScheduleBySecuredObjectIdAsync(int securityObjectId)
        {
            return workScheduleRepository.GetWorkScheduleBySecuredObjectIdAsync(securityObjectId);
        }

        public Task<WorkSchedule> GetWorkScheduleByIdAsync(int id)
        {
            return workScheduleRepository.GetWorkScheduleByIdAsync(id);
        }

        public Task UpdateWorkScheduleAsync(WorkSchedule workSchedule)
        {
            return workScheduleRepository.UpdateWorkScheduleAsync(workSchedule);
        }
    }
}
