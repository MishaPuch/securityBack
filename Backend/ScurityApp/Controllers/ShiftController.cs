using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScurityApp.ApiModel.RequestApiModel;
using ScurityApp.BLL.Helpers;
using ScurityApp.BLL.Services;
using ScurityApp.DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScurityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly ShiftService _shiftService;
        private readonly EmployeeService _employeeService;
        private readonly WorkScheduleService _workScheduleService;
        private readonly IMapper mapper;
        private int Asigning = 1;
        private int Changing = 2;
        private int Deleting = 3;
        public ShiftController(ShiftService shiftService, EmployeeService employeeService, WorkScheduleService workSchedule ,IMapper mapper)
        {
            _shiftService = shiftService;
            _employeeService = employeeService;
            _workScheduleService = workSchedule;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Shift>>> GetAllShifts()
        {
            var shifts = await _shiftService.GetAllShiftsAsync();
            return Ok(shifts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shift>> GetShiftById(int id)
        {
            var shift = await _shiftService.GetShiftByIdAsync(id);
            if (shift == null)
            {
                return NotFound();
            }
            return Ok(shift);
        }

        [HttpPost]
        public async Task<ActionResult> AddShift(ShiftRequestApiModel value)
        {
            var shift = mapper.Map<Shift>(value);

            await _shiftService.AddShiftAsync(shift);
            await EmailHelper.SendEmailForEmailAsync(shift.Employee, shift.WorkSchedule, Asigning);

            return CreatedAtAction(nameof(GetShiftById), new { id = shift.Id }, shift);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateShift(int id, ShiftRequestApiModel value)
        {
            var shift = mapper.Map<Shift>(value);
            shift.Employee=await _employeeService.GetEmployeeByIdAsync(value.EmployeeId);
            shift.WorkSchedule = await _workScheduleService.GetWorkScheduleByIdAsync(value.WorkScheduleId);
            shift.Id=id;
            try
            {
                await _shiftService.UpdateShiftAsync(shift);
                await EmailHelper.SendEmailForEmailAsync(shift.Employee, shift.WorkSchedule, Changing);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShift(int id)
        {
            var shift = await _shiftService.GetShiftByIdAsync(id);
            await _shiftService.DeleteShiftAsync(id);
            await EmailHelper.SendEmailForEmailAsync(shift.Employee, shift.WorkSchedule, Deleting);
            return NoContent();
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<List<Shift>>> GetEmployeeShifts(int employeeId)
        {
            var shifts = await _shiftService.GetEmployeeShiftsAsync(employeeId);
            return Ok(shifts);
        }

        [HttpGet("department/{departmentId}")]
        public async Task<ActionResult<List<Shift>>> GetShiftsByDepartmentAsync(int departmentId)
        {
            var shifts = await _shiftService.GetShiftsByDepartmentAsync(departmentId);
            return Ok(shifts);
        }
    }
}
