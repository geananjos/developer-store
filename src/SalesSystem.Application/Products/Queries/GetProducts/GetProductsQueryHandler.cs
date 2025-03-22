using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Application.Common;
using SalesSystem.Application.Common.Extensions;
using SalesSystem.Application.Products.DTOs;
using SalesSystem.Domain.Interfaces;

namespace SalesSystem.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PaginatedResult<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Query();

            if (!string.IsNullOrWhiteSpace(request.Category))
                query = query.Where(p => p.Category.ToLower() == request.Category.ToLower());


            if (!string.IsNullOrWhiteSpace(request.Order))
            {
                var orders = request.Order.Split(',');
                foreach (var o in orders.Reverse())
                {
                    var trimmed = o.Trim();
                    var descending = trimmed.EndsWith(" desc");
                    var prop = trimmed.Replace(" desc", "").Replace(" asc", "");

                    query = query.OrderByDynamic(prop, descending);
                }
            }
            else
            {
                query = query.OrderBy(p => p.Id);
            }

            var totalItems = await query.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling(totalItems / (double)request.Size);

            var products = await query
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PaginatedResult<ProductDto>
            {
                Data = products,
                TotalItems = totalItems,
                CurrentPage = request.Page,
                TotalPages = totalPages
            };
        }
    }
}
