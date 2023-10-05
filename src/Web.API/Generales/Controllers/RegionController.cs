using Application.Generales.Regiones.Features.Activate;
using Application.Generales.Regiones.Features.Create;
using Application.Generales.Regiones.Features.Deactivate;
using Application.Generales.Regiones.Features.Delete;
using Application.Generales.Regiones.Features.GetAll;
using Application.Generales.Regiones.Features.GetById;
using Application.Generales.Regiones.Features.Select;
using Application.Generales.Regiones.Features.Update;

namespace Web.API.Generales.Controllers;

[Route("api/v1/regiones")]
public class RegionController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var response = await _mediator.Send(new GetAllRegionQuery());

        return Ok(response);
    }

    [HttpGet("select")]
    public async Task<IActionResult> Select()
    {
        var response = await _mediator.Send(new SelectRegionQuery());

        return Ok(response);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetByIdRegionQuery(id));

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRegionCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("edit")]
    public async Task<IActionResult> Update([FromBody] UpdateRegionCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("deactivate")]
    public async Task<IActionResult> Deactivate([FromBody] DeactivateRegionCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("activate")]
    public async Task<IActionResult> Activate([FromBody] ActivateRegionCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteRegionCommand(id));

        return Ok(response);
    }
}
