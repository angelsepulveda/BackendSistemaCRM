using Application.Generales.Paises.Features.Activate;
using Application.Generales.Paises.Features.Create;
using Application.Generales.Paises.Features.Deactivate;
using Application.Generales.Paises.Features.Delete;
using Application.Generales.Paises.Features.GetAll;
using Application.Generales.Paises.Features.GetById;
using Application.Generales.Paises.Features.Select;
using Application.Generales.Paises.Features.Update;

namespace Web.API.Generales.Controllers;

[Route("api/v1/paises")]
public class PaisController : ControllerBase
{
  private readonly IMediator _mediator;

  public PaisController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<IActionResult> List()
  {
    var response = await _mediator.Send(new GetAllPaisQuery());

    return Ok(response);
  }


  [HttpGet("select")]
  public async Task<IActionResult> Select()
  {
    var response = await _mediator.Send(new SelectPaisQuery());

    return Ok(response);
  }

  [HttpGet("{id:Guid}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var response = await _mediator.Send(new GetByIdPaisQuery(id));

    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreatePaisCommand command)
  {
    var response = await _mediator.Send(command);

    return Ok(response);
  }


  [HttpPut("edit")]
  public async Task<IActionResult> Update([FromBody] UpdatePaisCommand command)
  {
    var response = await _mediator.Send(command);

    return Ok(response);
  }

  [HttpPut("deactivate")]
  public async Task<IActionResult> Deactivate([FromBody] DeactivatePaisCommand command)
  {
    var response = await _mediator.Send(command);

    return Ok(response);
  }

  [HttpPut("activate")]
  public async Task<IActionResult> Activate([FromBody] ActivatePaisCommand command)
  {
    var response = await _mediator.Send(command);

    return Ok(response);
  }

  [HttpDelete("{id:Guid}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    var response = await _mediator.Send(new DeletePaisCommand(id));

    return Ok(response);
  }
}
