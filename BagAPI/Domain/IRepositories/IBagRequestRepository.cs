using DTO;
using System;
using System.Collections.Generic;

namespace Domain.IRepositories
{
    public interface IBagRequestRepository
    {
        BagRequestDto GetBagRequest(int id);
        void CreateBagRequest(BagRequestDto userDto, int requestTypeId);
        BagRequestDto UpdateBagRequest(BagRequestDto userDto);
        void DeleteBagRequest(int id);
        IEnumerable<BagRequestsDto> GetBagRequests(DateTime from, DateTime to, string depatrureStationCode, string arrivalStationCode, int requestTypeId);
    }
}
