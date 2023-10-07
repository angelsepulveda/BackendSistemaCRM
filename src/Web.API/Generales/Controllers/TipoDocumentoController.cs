using Application.Generales.TiposDocumentos.Features.Activate;
using Application.Generales.TiposDocumentos.Features.Create;
using Application.Generales.TiposDocumentos.Features.Deactivate;
using Application.Generales.TiposDocumentos.Features.Delete;
using Application.Generales.TiposDocumentos.Features.GetAll;
using Application.Generales.TiposDocumentos.Features.GetById;
using Application.Generales.TiposDocumentos.Features.Select;
using Application.Generales.TiposDocumentos.Features.Update;

namespace Web.API.Generales.Controllers;

[Route("api/v1/tipos-documentos")]
public class TipoDocumentoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TipoDocumentoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var response = await _mediator.Send(new GetAllTipoDocumentoQuery());

        return Ok(response);
    }

    [HttpGet("select")]
    public async Task<IActionResult> Select()
    {
        var response = await _mediator.Send(new SelectTipoDocumentoQuery());

        return Ok(response);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetByIdTipoDocumentoQuery(id));

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTipoDocumentoCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("edit")]
    public async Task<IActionResult> Update([FromBody] UpdateTipoDocumentoCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("deactivate")]
    public async Task<IActionResult> Deactivate([FromBody] DeactivateTipoDocumentoCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("activate")]
    public async Task<IActionResult> Activate([FromBody] ActivateTipoDocumentoCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteTipoDocumentoCommand(id));

        return Ok(response);
    }
}
