using Microsoft.EntityFrameworkCore;

namespace ScurityApp.DAL.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }

        // Navigation property
        public Country Country { get; set; }


    }
}
