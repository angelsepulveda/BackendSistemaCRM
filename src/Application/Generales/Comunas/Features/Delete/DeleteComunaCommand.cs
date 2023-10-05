namespace Application.Generales.Comunas.Features.Delete;

public record DeleteComunaCommand(Guid Id) : IRequest<BaseResponse<bool>>;
