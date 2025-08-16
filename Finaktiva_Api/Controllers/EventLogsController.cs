using Application.DTOs;
using Application.UseCases;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Finaktiva_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventLogsController : ControllerBase
    {
        private readonly CreateEventLogHandler _createHandler;
        private readonly GetEventLogsHandler _getHandler;

        public EventLogsController(CreateEventLogHandler createHandler, GetEventLogsHandler getHandler)
        {
            _createHandler = createHandler;
            _getHandler = getHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventLogDto dto)
        {
            var id = await _createHandler.Handle(dto);
            return CreatedAtAction(nameof(GetByFilters), new { id }, new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetByFilters(
            [FromQuery] TipoEvento? tipo,
            [FromQuery] DateTime? desde,
            [FromQuery] DateTime? hasta)
        {
            var result = await _getHandler.Handle(tipo, desde, hasta);
            return Ok(result);
        }
    }
}
