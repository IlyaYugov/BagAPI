using DTO;
using System.Collections.Generic;

namespace Domain.IRepositories
{
    public interface IBugRequestRepository
    {
        BugRequestDto GetBugRequest(int Id);
        BugRequestDto CreateBugRequest(BugRequestDto userDto);
        BugRequestDto UpdateBugRequest(BugRequestDto userDto);
        bool DeleteBugRequest(int id);
        List<BugRequestDto> GetBugRequests(int id);
    }
}
