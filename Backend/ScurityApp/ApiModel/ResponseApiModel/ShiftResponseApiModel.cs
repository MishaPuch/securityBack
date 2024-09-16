using ScurityApp.DAL.Model;

namespace ScurityApp.ApiModel.ResponseApiModel
{
    public class ShiftResponseApiModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ShiftHours { get; set; }

        public EmployeeResponseApiModel Employee { get; set; }
        public WorkScheduleResponseApiModel WorkSchedule { get; set; }
    }
}
