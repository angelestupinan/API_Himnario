using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Himnos.Queries.GetHimnoById
{
    public class GetHimnoByIdQuery : IRequest<Response<HimnoDto>>
    {
        public int Id { get; set; }
    }

    public class GetHimnoByIdQueryHandler : IRequestHandler<GetHimnoByIdQuery, Response<HimnoDto>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Himnos> _repository;
        private readonly IMapper _mapper;

        public GetHimnoByIdQueryHandler(IRepositoryAsync<Domain.Entities.Himnos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<Response<HimnoDto>> Handle(GetHimnoByIdQuery request, CancellationToken cancellationToken)
        {
            var himno = await _repository.GetByIdAsync(request.Id);

            if(himno == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            else
            {
                var data = _mapper.Map<HimnoDto>(himno);

                return new Response<HimnoDto>(data);
            }
        }
    }
}
