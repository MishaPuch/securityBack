using ScurityApp.DAL.Model;
using ScurityApp.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScurityApp.BLL.Services
{
    public class ShiftService
    {
        private readonly ShiftRepository _repository;
        private readonly WorkScheduleRepository _workScheduleRepository;

        public ShiftService(ShiftRepository repository, WorkScheduleRepository workScheduleRepository)
        {
            _repository = repository;
            _workScheduleRepository = workScheduleRepository;
        }

        public async Task AddShiftAsync(Shift shift)
        {
            var workSchedule =await _workScheduleRepository.GetWorkScheduleByIdAsync(shift.WorkSchedule.Id);
            shift.WorkSchedule = workSchedule;
            await _repository.AddShiftAsync(shift);
            workSchedule.EmployeeCopasity--;
            await _workScheduleRepository.UpdateWorkScheduleAsync(workSchedule);
        }

        public async Task DeleteShiftAsync(int id)
        {
            var shift = await _repository.GetShiftByIdAsync(id);
            var workSchedule = shift.WorkSchedule;
            workSchedule.EmployeeCopasity++;
            await _workScheduleRepository.UpdateWorkScheduleAsync(workSchedule);
            await _repository.DeleteShiftAsync(id);
        }

        public async Task<List<Shift>> GetAllShiftsAsync()
        {
            return await _repository.GetAllShiftsAsync();
        }
        public async Task<List<Shift>> GetShiftsByDepartmentAsync(int employeeId)
        {
            return await _repository.GetShiftsByDepartmentAsync(employeeId);
        }

        public async Task<List<Shift>> GetEmployeeShiftsAsync(int employeeId)
        {
            return await _repository.GetEmployeeShiftsAsync(employeeId);
        }

        public async Task<Shift> GetShiftByIdAsync(int id)
        {
            return await _repository.GetShiftByIdAsync(id);
        }

        public async Task UpdateShiftAsync(Shift shift)
        {
            shift.WorkSchedule= await _workScheduleRepository.GetWorkScheduleByIdAsync(shift.WorkSchedule.Id);
            await _repository.UpdateShiftAsync(shift);
        }
    }
}
