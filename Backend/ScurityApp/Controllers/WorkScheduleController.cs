using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScurityApp.ApiModel.RequestApiModel;
using ScurityApp.BLL.Services;
using ScurityApp.DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScurityApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkScheduleController : ControllerBase
    {
        private readonly WorkScheduleService _workScheduleService;
        private readonly IMapper mapper;
        public WorkScheduleController(WorkScheduleService workScheduleService, IMapper mapper)
        {
            _workScheduleService = workScheduleService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkSchedule([FromBody] WorkScheduleRequestApiModel value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            var workSchedule = mapper.Map<WorkSchedule>(value);
            await _workScheduleService.AddWorkScheduleAsync(workSchedule);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkSchedule(int id)
        {
            await _workScheduleService.DeleteWorkScheduleAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkSchedule>>> GetAllWorkSchedules()
        {
            var workSchedules = await _workScheduleService.GetAllWorkSchedulesAsync();
            return Ok(workSchedules);
        }

        [HttpGet("securityObject/{securityObjectId}")]
        public async Task<ActionResult<List<WorkSchedule>>> GetWorkScheduleBySecuredObjectIdAsync(int securityObjectId)
        {
            var workSchedules = await _workScheduleService.GetWorkScheduleBySecuredObjectIdAsync(securityObjectId);
            return Ok(workSchedules);
        }

        [HttpGet("department/{departmentId}")]
        public async Task<ActionResult<List<WorkSchedule>>> GetWorkScheduleByDepartmentIdAsync(int departmentId)
        {
            var workSchedules = await _workScheduleService.GetWorkScheduleByDepartmentIdAsync(departmentId);
            return Ok(workSchedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkSchedule>> GetWorkScheduleById(int id)
        {
            var workSchedule = await _workScheduleService.GetWorkScheduleByIdAsync(id);
            if (workSchedule == null)
            {
                return NotFound();
            }

            return Ok(workSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkSchedule(int id, [FromBody] WorkScheduleRequestApiModel value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var workSchedule = mapper.Map<WorkSchedule>(value);
            workSchedule.Id = id;

            await _workScheduleService.UpdateWorkScheduleAsync(workSchedule);
            return Ok();
        }
    }
}
