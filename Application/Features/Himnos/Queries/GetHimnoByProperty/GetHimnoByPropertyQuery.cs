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

namespace Application.Features.Himnos.Queries.GetHimnoByProperty
{
    public class GetHimnoByPropertyQuery : IRequest<Response<List<HimnoDto>>> 
    {
        public int Number { get; set; }

        public string? Name { get; set; }

        public string? Lyrics { get; set; }

        public string? Type { get; set; }

        public string? Clasification { get; set; }

        public string? Status { get; set; }
    }

    public class GetHimnoByPropertyQueryHandler : IRequestHandler<GetHimnoByPropertyQuery, Response<List<HimnoDto>>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Himnos> _repository;
        private readonly IMapper _mapper;

        public GetHimnoByPropertyQueryHandler(IRepositoryAsync<Domain.Entities.Himnos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<HimnoDto>>> Handle(GetHimnoByPropertyQuery request, CancellationToken cancellationToken)
        {
            var himnos = await _repository.ListAsync(new PagedHimnoSpecification
            (
                request.Number,
                request.Name,
                request.Lyrics,
                request.Type,
                request.Clasification,
                request.Status
            ));

            var himnoDto = _mapper.Map<List<HimnoDto>>(himnos);

            return new Response<List<HimnoDto>>(himnoDto);
        }
    }
}
