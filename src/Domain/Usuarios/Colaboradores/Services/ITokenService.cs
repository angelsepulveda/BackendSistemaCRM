namespace Domain.Usuarios.Colaboradores.Services;

public interface ITokenService
{
    string GenerateToken(Colaborador colaborador);
    bool ComparePassword(string password, string passwordHashed);
    string EncryptPassword(string password);
}
