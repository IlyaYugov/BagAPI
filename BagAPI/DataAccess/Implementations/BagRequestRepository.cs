using DataAccess.Model;
using Domain.IRepositories;
using DTO;
using System;
using System.Collections.Generic;

namespace DataAccess.Implementations
{
    public class BagRequestRepository : IBagRequestRepository
    {
        private BagDbContext _bagDbContext;
        public BagRequestRepository(BagDbContext bagDbContext)
        {
            _bagDbContext = bagDbContext;
        }

        public BagRequestDto CreateBagRequest(BagRequestDto request, UserDto sourceUser)
        {
            var bagRequest = new BagRequest
            {
                Bag = new Bag
                {
                    Descriprion = request.Bag.Descriprion,
                    Photo = request.Bag.Photo,
                    Weight = request.Bag.Weight,
                    Price = request.Bag.Price
                },
                //SourceUser = sourceUser,
                RequestStatusId = (int)RequestStatuses.Created,
                Flight = new Flight
                {
                    
                }
            };

            return new BagRequestDto();
        }

        public bool DeleteBagRequest(int id)
        {
            throw new NotImplementedException();
        }

        public BagRequestDto GetBagRequest(int Id)
        {
            throw new NotImplementedException();
        }

        public List<BagRequestDto> GetBagRequests(int id)
        {
            throw new NotImplementedException();
        }

        public BagRequestDto UpdateBagRequest(BagRequestDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
