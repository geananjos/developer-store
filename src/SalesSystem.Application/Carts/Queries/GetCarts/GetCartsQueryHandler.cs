using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Application.Carts.DTOs;
using SalesSystem.Application.Common;
using SalesSystem.Application.Common.Extensions;
using SalesSystem.Domain.Carts.Interfaces;

namespace SalesSystem.Application.Carts.Queries.GetCarts
{
    public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery, PaginatedResult<CartDto>>
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;

        public GetCartsQueryHandler(ICartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<CartDto>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Query();

            if (!string.IsNullOrWhiteSpace(request.Order))
            {
                var orderParams = request.Order.Split(',');
                foreach (var param in orderParams.Reverse())
                {
                    var trimmed = param.Trim();
                    var descending = trimmed.EndsWith(" desc");
                    var property = trimmed.Replace(" desc", "").Replace(" asc", "").Trim();

                    query = query.OrderByDynamic(property, descending);
                }
            }

            var totalItems = await query.CountAsync(cancellationToken);
            var carts = await query
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
                .ProjectTo<CartDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PaginatedResult<CartDto>(carts, totalItems, request.Page, request.Size);
        }
    }
}
