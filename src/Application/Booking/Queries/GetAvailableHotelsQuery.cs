﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Booking;
using Domain.Booking.Specification;
using MediatR;

namespace Application.Booking.Queries
{
    public class GetAvailableHotelsQuery : IRequest<IReadOnlyCollection<GetAvailableHotelsDto>>
    {
        public DateTime CheckIn { get; set; } 
        public DateTime CheckOut { get; set; } 
        public int GuestsCount { get; set; }
        public class GetAvailableHotelsQueryHandler : IRequestHandler<GetAvailableHotelsQuery, IReadOnlyCollection<GetAvailableHotelsDto>>
        {
            private readonly IBookingRepository _bookingRepository;

            public GetAvailableHotelsQueryHandler(IBookingRepository bookingRepository)
            {
                this._bookingRepository = bookingRepository;
            }
            public async Task<IReadOnlyCollection<GetAvailableHotelsDto>> Handle(GetAvailableHotelsQuery request, CancellationToken cancellationToken)
            {
                return await this._bookingRepository.SearchAvailableHotels(new SearchAvailableHotelsSpecification());
            }
        }
    }
}
