namespace ScurityApp.ApiModel.RequestApiModel
{
    public class EmployeeRequestApiModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public int? DepartmentId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
