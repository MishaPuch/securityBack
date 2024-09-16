namespace ScurityApp.DAL.Model
{
    public class WorkSchedule
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public int SecurityObjectId {  get; set; }
        public int EmployeeCopasity { get; set; }
        
        public SecurityObject SecurityObject { get; set; }
    }
}
