namespace Domain.Common.Services;

public interface IHashPassword
{
    string Handle(string password);
}
