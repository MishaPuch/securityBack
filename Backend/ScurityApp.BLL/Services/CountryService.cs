using ScurityApp.DAL.Model;
using ScurityApp.DAL.Repositories;

namespace ScurityApp.BLL.Services
{
    public class CountryService
    {
        private readonly CountryRepository countryRepository;

        public CountryService(CountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }


        public Task AddCountryAsync(Country country)
        {
            return countryRepository.AddCountryAsync(country);
        }

        public Task DeleteCountryByIdAsync(int id)
        {
            return countryRepository.DeleteCountryByIdAsync(id);
        }

        public Task<List<Country>> GetAllCountriesAsync()
        {
            return countryRepository.GetAllCountriesAsync();
        }

        public Task<Country> GetCountryByIdAsync(int id)
        {
            return countryRepository.GetCountryByIdAsync(id);
        }

        public Task UpdateCountryAsync(Country country)
        {
            return countryRepository.UpdateCountryAsync(country);
        }
    }
}
