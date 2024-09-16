using ScurityApp.DAL.Model;

namespace ScurityApp.ApiModel.ResponseApiModel
{
    public class WorkScheduleResponseApiModel
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public int SecurityObjectId { get; set; }
        public int EmployeeCopasity { get; set; }

        public SecurityObject SecurityObject { get; set; }
    }
}
