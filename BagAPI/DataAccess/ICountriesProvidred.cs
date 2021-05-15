using DataAccess.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ICountriesProvidred
    {
        Task<IList<Country>> GetCountries();
    }
}
