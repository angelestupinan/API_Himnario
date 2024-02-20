using Application.Features.Himnos.Command.CreateHimnosCommand;
using Application.Features.Himnos.Command.DeleteHimnoCommand;
using Application.Features.Himnos.Command.UpdateHimnoCommand;
using Application.Features.Himnos.Queries.GetAllHimnos;
using Application.Features.Himnos.Queries.GetHimnoById;
using Application.Features.Himnos.Queries.GetHimnoByProperty;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class HimnoController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateHimno(CreateHimnoCommand himno)
        {
            return Ok(await Mediator.Send(himno));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHimno(DeleteHimnoCommand himno)
        {
            return Ok(await Mediator.Send(himno));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHimno(UpdateHimnoCommand himno)
        {
            return Ok(await Mediator.Send(himno));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHimnoById(int id)
        {
            return Ok(await Mediator.Send(new GetHimnoByIdQuery { Id = id}));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHimnos([FromQuery]GetAllHimnosQueryParameter query)
        {
            return Ok(await Mediator.Send(new GetAllHimnosQuery { 
                PageNumber = query.PageNumber, 
                PageSize = query.PageSize
            }));
        }

        [HttpGet("property")]
        public async Task<IActionResult> GetHimnoByProperty([FromQuery]GetHimnoByPropertyQueryParameters query)
        {
            return Ok(await Mediator.Send(new GetHimnoByPropertyQuery
            {
                Number = query.Number,
                Name = query.Name,
                Lyrics = query.Lyrics,
                Type = query.Type,
                Clasification = query.Clasification,
                Status = query.Status
            }));
        }
    }
}
