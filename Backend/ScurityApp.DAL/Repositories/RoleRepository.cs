using Microsoft.EntityFrameworkCore;
using ScurityApp.DAL.Model;


namespace ScurityApp.DAL.Repositories
{
    public class RoleRepository
    {
        private readonly AppDbContext dbContext;

        public RoleRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await dbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
