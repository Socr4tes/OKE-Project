using CountriesViewer.Helpers;
using CountriesViewer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddCountry(Country country)
        {
            Countries.CountriesList.Add(country);
            DataContext.SaveDatabase(Countries);
        }
    }
}