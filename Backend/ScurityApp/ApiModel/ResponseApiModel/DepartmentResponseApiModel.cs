using ScurityApp.DAL.Model;

namespace ScurityApp.ApiModel.ResponseApiModel
{
    public class DepartmentResponseApiModel : RefernceApiModel
    {
        public string Name {  get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }

        // Navigation property
        public CountryResponseApiModel Country { get; set; }
    }
}
