using Microsoft.EntityFrameworkCore;
using ScurityApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScurityApp.DAL.Repositories
{
    public class SecurityObjectRepository
    {
        private readonly AppDbContext dbContext;

        public SecurityObjectRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddSecurityObjectAsync(SecurityObject securityObject)
        {
            await dbContext.SecurityObjects.AddAsync(securityObject);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteSecurityObjectByIdAsync(int id)
        {
            var securityObject = await dbContext.SecurityObjects.FindAsync(id);
            if (securityObject != null)
            {
                dbContext.SecurityObjects.Remove(securityObject);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<SecurityObject>> GetAllCountriesAsync()
        {
            return await dbContext.SecurityObjects.Include(x => x.Department).ThenInclude(x => x.Country).ToListAsync();
        }

        public async Task<SecurityObject> GetSecurityObjectByIdAsync(int id)
        {
            return await dbContext.SecurityObjects.Include(x=>x.Department).ThenInclude(x=>x.Country).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateSecurityObjectAsync(SecurityObject securityObject)
        {
            dbContext.SecurityObjects.Update(securityObject);
            await dbContext.SaveChangesAsync();
        }
    }
}
