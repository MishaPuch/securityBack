using Microsoft.EntityFrameworkCore;
using ScurityApp.DAL.Model;


namespace ScurityApp.DAL.Repositories
{
    public class CountryRepository 
    {
        private readonly AppDbContext dbContext;

        public CountryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCountryAsync(Country country)
        {
            await dbContext.Countries.AddAsync(country);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteCountryByIdAsync(int id)
        {
            var country = await dbContext.Countries.FindAsync(id);
            if (country != null)
            {
                dbContext.Countries.Remove(country);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await dbContext.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await dbContext.Countries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateCountryAsync(Country country)
        {
            dbContext.Countries.Update(country);
            await dbContext.SaveChangesAsync();
        }
    }
}
