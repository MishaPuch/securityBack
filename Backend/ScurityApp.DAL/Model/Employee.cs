using System.Data;
using System;

namespace ScurityApp.DAL.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public int? DepartmentId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // Navigation properties
        public Role Role { get; set; }
        public Department Department { get; set; }
    }
}
