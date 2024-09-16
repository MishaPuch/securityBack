using ScurityApp.DAL.Model;
using ScurityApp.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScurityApp.BLL.Services
{
    public class SecurityObjectService
    {
        private readonly SecurityObjectRepository _repository;

        public SecurityObjectService(SecurityObjectRepository repository)
        {
            _repository = repository;
        }

        public async Task AddSecurityObjectAsync(SecurityObject securityObject)
        {
            await _repository.AddSecurityObjectAsync(securityObject);
        }

        public async Task DeleteSecurityObjectByIdAsync(int id)
        {
            await _repository.DeleteSecurityObjectByIdAsync(id);
        }

        public async Task<List<SecurityObject>> GetAllSecurityObjectsAsync()
        {
            return await _repository.GetAllCountriesAsync();
        }

        public async Task<SecurityObject> GetSecurityObjectByIdAsync(int id)
        {
            return await _repository.GetSecurityObjectByIdAsync(id);
        }

        public async Task UpdateSecurityObjectAsync(SecurityObject securityObject)
        {
            await _repository.UpdateSecurityObjectAsync(securityObject);
        }
    }
}
