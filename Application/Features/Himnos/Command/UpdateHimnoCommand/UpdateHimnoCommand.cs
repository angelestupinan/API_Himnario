using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Himnos.Command.UpdateHimnoCommand
{
    public class UpdateHimnoCommand : IRequest<Response<HimnoDto>>
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Lyrics { get; set; }

        public string Type { get; set; }

        public string Clasification { get; set; }

        public string Status { get; set; }
    }

    public class UpdateHimnoCommandHandler : IRequestHandler<UpdateHimnoCommand, Response<HimnoDto>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Himnos> _repository;
        private readonly IMapper _mapper;

        public UpdateHimnoCommandHandler(IRepositoryAsync<Domain.Entities.Himnos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<HimnoDto>> Handle(UpdateHimnoCommand request, CancellationToken cancellationToken)
        {
            var findHimno = await _repository.GetByIdAsync(request.Id);

            if (findHimno == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            else
            {
                findHimno.Id = request.Id;
                findHimno.Number = request.Number;
                findHimno.Name = request.Name;
                findHimno.Lyrics = request.Lyrics;
                findHimno.Type = request.Type;
                findHimno.Clasification = request.Clasification;
                findHimno.Status = request.Status;

                await _repository.UpdateAsync(findHimno);

                var data = _mapper.Map<HimnoDto>(findHimno);

                return new Response<HimnoDto>(data);
            }
            
        }
    }
}
