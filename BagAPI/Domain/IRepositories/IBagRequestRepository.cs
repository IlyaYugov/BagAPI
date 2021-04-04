using DTO;
using System;
using System.Collections.Generic;

namespace Domain.IRepositories
{
    public interface IBagRequestRepository
    {
        BagRequestDto GetBagRequest(int id);
        void CreateBagRequest(BagRequestDto request, int userId);
        BagRequestDto Deal(BagRequestDto request, UserDto userDto);
        void DeleteBagRequest(int id);
        IEnumerable<BagRequestsDto> GetBagRequests(DateTime from, DateTime to, string depatrureStationCode, string arrivalStationCode, int requestTypeId);
    }
}
