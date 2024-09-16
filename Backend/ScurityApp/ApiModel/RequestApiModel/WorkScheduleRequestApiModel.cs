using ScurityApp.DAL.Model;

namespace ScurityApp.ApiModel.RequestApiModel
{
    public class WorkScheduleRequestApiModel
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public int SecurityObjectId { get; set; }
        public int EmployeeCopasity { get; set; }
    }
}
