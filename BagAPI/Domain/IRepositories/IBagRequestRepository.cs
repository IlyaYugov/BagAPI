using DTO;
using System.Collections.Generic;

namespace Domain.IRepositories
{
    public interface IBagRequestRepository
    {
        BagRequestDto GetBagRequest(int Id);
        BagRequestDto CreateBagRequest(BagRequestDto userDto);
        BagRequestDto UpdateBagRequest(BagRequestDto userDto);
        bool DeleteBagRequest(int id);
        List<BagRequestDto> GetBagRequests(int id);
    }
}
