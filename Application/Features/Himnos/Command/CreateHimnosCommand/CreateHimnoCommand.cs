using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Himnos.Command.CreateHimnosCommand
{
    public class CreateHimnoCommand : IRequest<Response<int>>
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public string Lyrics { get; set; }

        public string Type { get; set; }

        public string Clasification { get; set; }

        public string Status { get; set; } = "WAITING_CONFIRMATION";
    }

    public class CreateHimnoCommandHandler : IRequestHandler<CreateHimnoCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Domain.Entities.Himnos> _repositoryAsync;

        public CreateHimnoCommandHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Himnos> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(CreateHimnoCommand request, CancellationToken cancellationToken)
        {
            var createClient = _mapper.Map<Domain.Entities.Himnos>(request);

            var data = await _repositoryAsync.AddAsync(createClient);

            return new Response<int>(data.Id);
        }
    }
}
