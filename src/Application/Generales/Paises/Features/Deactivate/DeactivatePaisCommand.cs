namespace Application.Generales.Paises.Features.Deactivate;

public record DeactivatePaisCommand(Guid Id) : IRequest<BaseResponse<bool>>;