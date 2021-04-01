using DTO;
using System.Collections.Generic;

namespace Domain.IRepositories
{
    public interface IBagRequestRepository
    {
        BagRequestDto GetBagRequest(int Id);
        BagRequestDto CreateBagRequest(BagRequestDto userDto, UserDto sourceUser);
        BagRequestDto UpdateBagRequest(BagRequestDto userDto);
        bool DeleteBagRequest(int id);
        IEnumerable<BagRequestDto> GetBagRequests(int id);
    }
}
