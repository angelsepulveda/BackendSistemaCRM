namespace Application.Generales.Paises.Features.Activate;

public record ActivatePaisCommand(Guid Id) : IRequest<BaseResponse<bool>>;