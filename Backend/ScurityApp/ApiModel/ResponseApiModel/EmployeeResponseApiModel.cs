using ScurityApp.DAL.Model;

namespace ScurityApp.ApiModel.ResponseApiModel
{
    public class EmployeeResponseApiModel : RefernceApiModel
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public int? DepartmentId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // Navigation properties
        public RefernceApiModel Role { get; set; }
        public DepartmentResponseApiModel Department { get; set; }
    }
}
