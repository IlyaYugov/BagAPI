using Domain.IRepositories;
using DTO;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class BagRequestDomain
    {
        private readonly IBagRequestRepository repository;
        private readonly UserDomain userDomain;

        public BagRequestDomain(IBagRequestRepository repository, UserDomain userDomain)
        {
            this.repository = repository;
            this.userDomain = userDomain;
        }

        public BagRequestDto GetBagRequest(int id)
        {
            return repository.GetBagRequest(id);
        }

        public void CreateBagRequest(BagRequestDto request, int userId)
        {
            repository.CreateBagRequest(request, userId);
        }
        public BagRequestDto Deal(int requestId, string dealUserEmail)
        {
            var user = userDomain.GetUser(dealUserEmail).User;
            user.Password = null;

            var request = repository.GetBagRequest(requestId);

            return repository.Deal(request, user);
        }
        public bool DeleteBagRequest(int id, int userId)
        {
            var request = GetBagRequest(id);

            if (request.RequestTypeId == (int)BagRequestTypes.SendBag && request.SenderUser.Id != userId)
                return false;

            if (request.RequestTypeId == (int)BagRequestTypes.TransfererBag && request.TransfererUser.Id != userId)
                return false;

            repository.DeleteBagRequest(id);

            return true;
        }
        public IEnumerable<BagRequestsDto> GetBagRequests(DateTime from, DateTime to, string depatrureStationCode, string arrivalStationCode, int requestTypeId)
        {
            return repository.GetBagRequests(from, to, depatrureStationCode, arrivalStationCode, requestTypeId);
        }
    }
}
