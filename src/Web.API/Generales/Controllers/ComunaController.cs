using Application.Generales.Comunas.Features.Activate;
using Application.Generales.Comunas.Features.Create;
using Application.Generales.Comunas.Features.Deactivate;
using Application.Generales.Comunas.Features.Delete;
using Application.Generales.Comunas.Features.GetAll;
using Application.Generales.Comunas.Features.GetById;
using Application.Generales.Comunas.Features.Select;
using Application.Generales.Comunas.Features.Update;

[Route("api/v1/comunas")]
public class ComunaController : ControllerBase
{
    private readonly IMediator _mediator;

    public ComunaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var response = await _mediator.Send(new GetAllComunaQuery());

        return Ok(response);
    }

    [HttpGet("select")]
    public async Task<IActionResult> Select()
    {
        var response = await _mediator.Send(new SelectComunaQuery());

        return Ok(response);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetByIdComunaQuery(id));

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateComunaCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("edit")]
    public async Task<IActionResult> Update([FromBody] UpdateComunaCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("deactivate")]
    public async Task<IActionResult> Deactivate([FromBody] DeactivateComunaCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("activate")]
    public async Task<IActionResult> Activate([FromBody] ActivateComunaCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteComunaCommand(id));

        return Ok(response);
    }
}
