using API.Models;

namespace API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Account account);
    }
}
