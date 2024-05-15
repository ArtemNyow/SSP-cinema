using Domain.Models;

namespace BLL.Interfaces;

public interface IAuthService
{
    string GenerateJwt(User user);
}