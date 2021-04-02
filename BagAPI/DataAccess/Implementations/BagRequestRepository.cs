using DataAccess.Model;
using Domain.IRepositories;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementations
{
    public class BagRequestRepository : IBagRequestRepository
    {
        private BagDbContext _bagDbContext;
        public BagRequestRepository(BagDbContext bagDbContext)
        {
            _bagDbContext = bagDbContext;
        }

        public void CreateBagRequest(BagRequestDto request, int requestTypeId)
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
                RequestStatusId = (int)RequestStatuses.Created,
                Flight = new Flight
                {
                    Number = request.Flight.FlightNumber,
                    DestinationStationCode = request.Flight.ArrivalStationCode,
                    SourceStationCode = request.Flight.DepatrureStationCode,
                    ArrivalTime = request.Flight.ArrivalTime,
                    DepartureTime = request.Flight.DepartureTime,
                    TicketPhoto = request.Flight.TicketPhoto
                },
            };

           /* if(requestTypeId == (int)RequestTypes.SendBag)
            {
                bagRequest.SenderUserId = SenderUserId = request.SenderUser.Id,
                TransfererUserId = request.TransfererUser.Id
            }*/

            _bagDbContext.Request.Add(bagRequest);
            _bagDbContext.Save();
        }

        public void DeleteBagRequest(int id)
        {
            var request = _bagDbContext.Request
                .FirstOrDefault(r => r.Id == id);

            _bagDbContext.Request.Remove(request);
            _bagDbContext.Save();
        }

        public BagRequestDto GetBagRequest(int id)
        {
            var request = _bagDbContext.Request
                .Include(r => r.Bag)
                .Include(r => r.SenderUser)
                .Include(r => r.TransfererUser)
                .FirstOrDefault(r => r.Id == id);

            var result = new BagRequestDto
            {
                Bag = new BagDto
                {
                    Price = request.Bag.Price,
                    Descriprion = request.Bag.Descriprion,
                    Photo = request.Bag.Photo,
                    Weight = request.Bag.Weight
                },
                SenderUser = new UserDto
                {
                    FirstName = request.SenderUser.FirstName,
                    Email = request.SenderUser.Email,
                    LastName = request.SenderUser.LastName,
                    PhoneNumber = request.SenderUser.PhoneNumber,
                    Skype = request.SenderUser.Skype,
                },
                TransfererUser = new UserDto
                {
                    FirstName = request.TransfererUser.FirstName,
                    Email = request.TransfererUser.Email,
                    LastName = request.TransfererUser.LastName,
                    PhoneNumber = request.TransfererUser.PhoneNumber,
                    Skype = request.TransfererUser.Skype,
                },
            };

            return result;
        }

        public IEnumerable<BagRequestsDto> GetBagRequests(DateTime from, DateTime to, string depatrureStationCode, string arrivalStationCode, int requestTypeId)
        {
            var requests = _bagDbContext.Request
                .Where(r => r.Flight.DestinationStationCode == arrivalStationCode &&
                            r.Flight.SourceStationCode == depatrureStationCode &&

                            from >= r.Flight.DepartureTime &&
                            to <= r.Flight.DepartureTime &&
                            
                            r.RequestTypeId == requestTypeId)
                .Include(r=>r.Bag)
                .Include(r => r.Flight)
                .ToList();

            var result = requests.Select(r => new BagRequestsDto
            {
                Id = r.Id,
                BagWeight = r.Bag.Weight,
                Date = r.Flight.DepartureTime,
                FlightNumber = r.Flight.Number,
                ArrivalStation = r.Flight.DestinationStation.Title,
                DepatrureStation = r.Flight.SourceStation.Title,
            }) 
            .OrderBy(r=>r.Date);

            return result;
        }

        public BagRequestDto UpdateBagRequest(BagRequestDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
