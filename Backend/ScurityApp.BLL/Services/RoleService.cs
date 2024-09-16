using ScurityApp.DAL.Model;
using ScurityApp.DAL.Repositories;


namespace ScurityApp.BLL.Services
{
    public class RoleService
    {
        private readonly RoleRepository roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public Task<List<Role>> GetAllRolesAsync()
        {
            return roleRepository.GetAllRolesAsync();
        }

        public Task<Role> GetRoleByIdAsync(int id)
        {
            return roleRepository.GetRoleByIdAsync(id);
        }
    }
}
