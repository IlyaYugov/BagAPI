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

        public void CreateBagRequest(BagRequestDto request, int userId)
        {
            var bagRequest = new BagRequest
            {
                RequestStatusId = (int)BagRequestStatuses.Created,
                RequestTypeId = request.RequestTypeId,
                Bag = new Bag
                {
                    Descriprion = request.Bag.Descriprion,
                    Photo = request.Bag.Photo,
                    Weight = request.Bag.Weight,
                    Price = request.Bag.Price
                },
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

            if (request.RequestTypeId == (int)BagRequestTypes.SendBag)
            {
                bagRequest.SenderUserId = userId;
            }
            if (request.RequestTypeId == (int)BagRequestTypes.TransfererBag)
            {
                bagRequest.TransfererUserId = userId;
            }

            _bagDbContext.BagRequest.Add(bagRequest);
            _bagDbContext.SaveChanges();
        }

        public void DeleteBagRequest(int id)
        {
            var request = _bagDbContext.BagRequest
                .FirstOrDefault(r => r.Id == id);

            _bagDbContext.BagRequest.Remove(request);
            _bagDbContext.SaveChanges();
        }

        public BagRequestDto GetBagRequest(int id)
        {
            var request = _bagDbContext.BagRequest
                .Include(r => r.Bag)
                .Include(r => r.SenderUser)
                .Include(r => r.TransfererUser)
                .FirstOrDefault(r => r.Id == id);

            var result = new BagRequestDto
            {
                Id = request.Id,
                RequestTypeId = request.RequestTypeId,
                RequestStatusId = request.RequestStatusId,
                Bag = new BagDto
                {
                    Price = request.Bag.Price,
                    Descriprion = request.Bag.Descriprion,
                    Photo = request.Bag.Photo,
                    Weight = request.Bag.Weight
                },
                SenderUser = new UserDto
                {
                    FirstName = request.SenderUser?.FirstName,
                    Email = request.SenderUser?.Email,
                    LastName = request.SenderUser?.LastName,
                    PhoneNumber = request.SenderUser?.PhoneNumber,
                    Skype = request.SenderUser?.Skype,
                },
                TransfererUser = new UserDto
                {
                    FirstName = request.TransfererUser?.FirstName,
                    Email = request.TransfererUser?.Email,
                    LastName = request.TransfererUser?.LastName,
                    PhoneNumber = request.TransfererUser?.PhoneNumber,
                    Skype = request.TransfererUser?.Skype,
                },
            };

            return result;
        }

        public IEnumerable<BagRequestsDto> GetBagRequests(DateTime from, DateTime to, string depatrureStationCode, string arrivalStationCode, int requestTypeId)
        {
            var requests = _bagDbContext.BagRequest
                .Where(r => r.Flight.DestinationStationCode == arrivalStationCode &&
                            r.Flight.SourceStationCode == depatrureStationCode &&

                            r.Flight.ArrivalTime <= to &&
                            r.Flight.DepartureTime >=  from &&
                            
                            r.RequestTypeId == requestTypeId)
                .Include(r=>r.Bag)
                .Include(r => r.Flight)
                .Include(r => r.Flight.DestinationStation)
                .Include(r => r.Flight.SourceStation)
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

        public BagRequestDto Deal(BagRequestDto requestDto, UserDto user)
        {
            var request = _bagDbContext.BagRequest.FirstOrDefault(r => r.Id == requestDto.Id);

            request.RequestStatusId = (int)BagRequestStatuses.Deal;

            if (requestDto.RequestTypeId == (int)BagRequestTypes.SendBag)
            {
                request.TransfererUserId = user.Id;
                requestDto.TransfererUser = user;
            }
            if (requestDto.RequestTypeId == (int)BagRequestTypes.TransfererBag)
            {
                request.SenderUserId = user.Id;
                requestDto.SenderUser = user;
            }

            _bagDbContext.Update(request);
            _bagDbContext.SaveChanges();

            return requestDto;
        }

        public BagRequestDto UnDeal(BagRequestDto requestDto, UserDto user)
        {
            var request = _bagDbContext.BagRequest.FirstOrDefault(r => r.Id == requestDto.Id);

            request.RequestStatusId = (int)BagRequestStatuses.Created;

            if (requestDto.RequestTypeId == (int)BagRequestTypes.SendBag && (user.Id == request.SenderUserId || user.Id == request.TransfererUserId))
            {
                request.TransfererUserId = null;
            }
            if (requestDto.RequestTypeId == (int)BagRequestTypes.TransfererBag && (user.Id == request.SenderUserId || user.Id == request.TransfererUserId))
            {
                request.SenderUserId = null;
            }

            _bagDbContext.Update(request);
            _bagDbContext.SaveChanges();

            return requestDto;
        }
    }
}
