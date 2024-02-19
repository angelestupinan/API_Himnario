using Application.DTOs;
using Application.Features.Himnos.Queries.GetHimnoById;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Himnos.Queries.GetHimnoByName
{
    public class GetHimnoByNameQuery : IRequest<Response<HimnoDto>>
    {
        public string Name { get; set; }
    }

    public class GetHimnoByNameQueryHandler : IRequestHandler<GetHimnoByNameQuery, Response<HimnoDto>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Himnos> _repository;
        private readonly IMapper _mapper;

        public GetHimnoByNameQueryHandler(IRepositoryAsync<Domain.Entities.Himnos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<HimnoDto>> Handle(GetHimnoByNameQuery request, CancellationToken cancellationToken)
        {
            var getByName = await _repository.GetOneAsync(x => x.Name == request.Name.ToLower());

            if (getByName == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el nombre {request.Name}");
            }
            else
            {
                var data = _mapper.Map<HimnoDto>(getByName);

                return new Response<HimnoDto>(data);
            }
        }
    }
}
