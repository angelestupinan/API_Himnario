using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Himnos.Command.DeleteHimnoCommand
{
    public class DeleteHimnoCommand : IRequest<Response<Domain.Entities.Himnos>>
    {
        public int Number { get; set; }
    }

    public class DeleteHimnoCommandHandler : IRequestHandler<DeleteHimnoCommand, Response<Domain.Entities.Himnos>>
    {

        private readonly IRepositoryAsync<Domain.Entities.Himnos> _repository;

        public DeleteHimnoCommandHandler(IRepositoryAsync<Domain.Entities.Himnos> repository)
        {
            _repository = repository;
        }


        public async Task<Response<Domain.Entities.Himnos>> Handle(DeleteHimnoCommand request, CancellationToken cancellationToken)
        {
            var findHimno = await _repository.GetOneAsync(x => x.Number == request.Number);

            if (request == null || findHimno == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el numero {request.Number}");
            }

            else
            {
                var data = _repository.DeleteAsync(findHimno);

                return new Response<Domain.Entities.Himnos>(findHimno);
            }
        }
    }
}
