using CountriesViewer.Helpers;
using CountriesViewer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CountriesViewer.Models.Repositories
{
    public class CountryRepository : ICountryRepository<Country>
    {
        public static Countries Countries;

        public IEnumerable<Country> GetAllCountries()
        {
            return Countries.CountriesList;
        }

        public Country GetCountry(string name)
        {
            return Countries.CountriesList.Single(c => c.Name == name);
        }

        public bool AddCountry(Country country)
        {
            if (Countries.CountriesList.Any(c => c.Name == country.Name))
            {
                return false;
            }

            Countries.CountriesList.Add(country);
            DataContext.SaveDatabase(Countries);

            return true;
        }
    }
}