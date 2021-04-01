using DTO;
using System.Collections.Generic;

namespace Domain.IRepositories
{
    public interface IDirectionRepository
    {
        IEnumerable<CityDto> GetDirections(string search);
    }
}
