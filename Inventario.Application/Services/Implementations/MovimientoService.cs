using Inventario.Application.DTOs.Movimiento;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;

namespace Inventario.Application.Services.Implementations
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository;

        public MovimientoService(IMovimientoRepository movientoRepository)
        {
            _movimientoRepository = movientoRepository;
        }

        public async Task<IEnumerable<MovimientoDTO>> GetAllAsync()
        {

            var movimientos = await _movimientoRepository.GetAllWithDetailsAsync();

            var movimientosDto = movimientos.Select(movimiento => new MovimientoDTO
            {

                Id = movimiento.Id,
                Fecha = movimiento.Fecha,
                Tipo = movimiento.Tipo,
                Motivo = movimiento.Motivo,
                UsuarioNombre = movimiento.Usuario.Nombre,
                ProductoNombre = movimiento.Producto.Nombre

            });

            return movimientosDto;
        }

        public async Task<MovimientoDTO?> GetByIdAsync(int id)
        {

            var movimiento = await _movimientoRepository.GetByIdWithDetailsAsync(id);
            if (movimiento == null) return null;

            return new MovimientoDTO
            {
                Id = movimiento.Id,
                Fecha = movimiento.Fecha,
                Tipo = movimiento.Tipo,
                Motivo = movimiento.Motivo,
                UsuarioNombre = movimiento.Usuario.Nombre,
                ProductoNombre = movimiento.Producto.Nombre
            };

        }

        public async Task<MovimientoDTO> CreateAsync(CrearMovimientoDTO dto)
        {

            var movimiento = new Movimiento
            {
                Fecha = dto.Fecha,
                Tipo = dto.Tipo,
                Motivo = dto.Motivo,
                UsuarioId = dto.UsuarioId,
                ProductoId = dto.ProductoId
            };

            var creado = await _movimientoRepository.CreateAsync(movimiento);
            var conDetalles = await _movimientoRepository.GetByIdWithDetailsAsync(creado.Id);

            return new MovimientoDTO
            {
                Fecha = conDetalles.Fecha,
                Tipo = conDetalles.Tipo,
                Motivo = conDetalles.Motivo,
                UsuarioNombre = conDetalles.Usuario.Nombre,
                ProductoNombre = conDetalles.Producto.Nombre
            };

        }


        public async Task DeleteAsync(int id)
        {
            var movimiento = await _movimientoRepository.GetByIdAsync(id);
            if (movimiento == null) return;

            await _movimientoRepository.DeleteAsync(id);
        }


        public async Task<IEnumerable<MovimientoDTO>> GetByProductoIdAsync(int id)
        {
            var movimientos = await _movimientoRepository.GetByProductoIdAsync(id);

            var movimientosDto = movimientos.Select(movimiento => new MovimientoDTO
            {
                Fecha = movimiento.Fecha,
                Tipo = movimiento.Tipo,
                Motivo = movimiento.Motivo,
                UsuarioNombre = movimiento.Usuario.Nombre,
                ProductoNombre = movimiento.Producto.Nombre

            });

            return movimientosDto;

        }

        public async Task<IEnumerable<MovimientoDTO>> GetByUsuarioIdAsync(int id)
        {
            var movimientos = await _movimientoRepository.GetByUsuarioIdAsync(id);


            var movimientosDto = movimientos.Select(movimiento => new MovimientoDTO
            {
                Fecha = movimiento.Fecha,
                Tipo = movimiento.Tipo,
                Motivo = movimiento.Motivo,
                UsuarioNombre = movimiento.Usuario.Nombre,
                ProductoNombre = movimiento.Producto.Nombre
            });
            return movimientosDto;

        }
    }
}
