using ScurityApp.ApiModel.ResponseApiModel;

namespace ScurityApp.ApiModel.RequestApiModel
{
    public class ShiftRequestApiModel
    {
        public int EmployeeId { get; set; }
        public int ShiftHours { get; set; }
        public int WorkScheduleId { get; set; }
    }
}
