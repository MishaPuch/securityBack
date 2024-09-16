using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScurityApp.ApiModel.ResponseApiModel;
using ScurityApp.BLL.Services;
using ScurityApp.DAL.Model;

namespace ScurityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService roleService;
        private readonly IMapper mapper;
        public RoleController(RoleService roleService, IMapper mapper)
        {
            this.roleService = roleService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<RoleResponseApiModel>> GetRoles()
        {
            var roles= await roleService.GetAllRolesAsync();

            var mappedRoles= new List<RoleResponseApiModel>();
            foreach(var role in roles)
            {
                mappedRoles.Add(mapper.Map<RoleResponseApiModel>(role));

            }
            return mappedRoles;

        }

        [HttpGet("{id}")]
        public async Task<RoleResponseApiModel> GetRoleById(int id)
        {
            var role = mapper.Map<RoleResponseApiModel>( await roleService.GetRoleByIdAsync(id));
            return role;
        }
    }
}
