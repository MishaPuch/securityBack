using ScurityApp.DAL.Model;

namespace ScurityApp.ApiModel.ResponseApiModel
{
    public class SecurityObjectResponceApiModel
    {
        public int Id { get; set; }
        public string ObjectAddres { get; set; }
        public int DepartmentId { get; set; }

        public DepartmentResponseApiModel Department { get; set; }
    }
}
