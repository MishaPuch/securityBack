using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScurityApp.ApiModel.RequestApiModel;
using ScurityApp.ApiModel.ResponseApiModel;
using ScurityApp.BLL.Services;
using ScurityApp.DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScurityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityObjectController : ControllerBase
    {
        private readonly SecurityObjectService _securityObjectService;
        private readonly IMapper mapper;

        public SecurityObjectController(SecurityObjectService securityObjectService, IMapper mapper)
        {
            _securityObjectService = securityObjectService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SecurityObjectResponceApiModel>>> GetAllSecurityObjects()
        {
            var securityObjects = await _securityObjectService.GetAllSecurityObjectsAsync();
            return Ok(securityObjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SecurityObjectResponceApiModel>> GetSecurityObjectById(int id)
        {
            var securityObject = await _securityObjectService.GetSecurityObjectByIdAsync(id);
            if (securityObject == null)
            {
                return NotFound();
            }
            return Ok(securityObject);
        }

        [HttpPost]
        public async Task<ActionResult> AddSecurityObject(SecurityObjectResponceApiModel value)
        {
            var securityObject = mapper.Map<SecurityObject>(value);

            await _securityObjectService.AddSecurityObjectAsync(securityObject);
            return CreatedAtAction(nameof(GetSecurityObjectById), new { id = securityObject.Id }, securityObject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSecurityObject(int id, SecurityObjectRequestApiModel value)
        {
            var securityObject = mapper.Map<SecurityObject>(value);
            securityObject.Id = id;

            try
            {
                await _securityObjectService.UpdateSecurityObjectAsync(securityObject);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSecurityObject(int id)
        {
            await _securityObjectService.DeleteSecurityObjectByIdAsync(id);
            return NoContent();
        }
    }
}
