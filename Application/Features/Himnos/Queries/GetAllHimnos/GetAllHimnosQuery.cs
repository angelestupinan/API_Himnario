using Application.DTOs;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Himnos.Queries.GetAllHimnos
{
    public class GetAllHimnosQuery : IRequest<PagedResponse<List<HimnoDto>>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
    public class GetAllHimnosQueryHandler : IRequestHandler<GetAllHimnosQuery, PagedResponse<List<HimnoDto>>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Himnos> _repository;
        private readonly IMapper _mapper;

        public GetAllHimnosQueryHandler(IRepositoryAsync<Domain.Entities.Himnos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<HimnoDto>>> Handle(GetAllHimnosQuery request, CancellationToken cancellationToken)
        {
            var himnos = await _repository.ListAsync(new PagedHimnoSpecification
            (
                request.PageNumber,
                request.PageSize
            ));

            var himnoDto = _mapper.Map<List<HimnoDto>>(himnos);

            return new PagedResponse<List<HimnoDto>>(himnoDto, request.PageNumber, request.PageSize);
        }
    }
}
