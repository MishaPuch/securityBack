using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScurityApp.DAL.Model
{
    public class SecurityObject
    {
        public int Id { get; set; }
        public string ObjectAddres { get; set; }
        public int DepartmentId {  get; set; }

        public Department Department { get; set; }
    }
}
