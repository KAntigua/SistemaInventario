using Inventario.Application.DTOs.Login;

namespace Inventario.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginDTO dto);

    }
}
