namespace Application.Generales.Paises.Features.Delete;

public record DeletePaisCommand(Guid Id) : IRequest<BaseReponse<bool>>;