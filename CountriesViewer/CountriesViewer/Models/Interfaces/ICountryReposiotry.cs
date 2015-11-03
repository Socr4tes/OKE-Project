using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesViewer.Models.Interfaces
{
    public interface ICountryRepository<T>
    {
        IEnumerable<T> GetAllCountries();
        T GetCountry(string name);
        void AddCountry(T country);
    }
}
