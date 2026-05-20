using Inventario.Application.DTOs.Login;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inventario.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUsuarioRepository usuarioRepository,
            IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public async Task<string?> LoginAsync(LoginDTO dto)
        {
            var usuario = await _usuarioRepository
                .GetByCorreoAsync(dto.Correo);

            if (usuario == null)
            {
                return null;
            }

            bool passwordValida = BCrypt.Net.BCrypt.Verify(
                dto.Password,
                usuario.ContrasenaHash);

            if (!passwordValida)
            {
                return null;
            }

            var claims = new[]
            {
                new Claim(
                    ClaimTypes.Name,
                    usuario.Correo),

                new Claim(
                    ClaimTypes.Role,
                    usuario.Rol.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);

        }
    }
}