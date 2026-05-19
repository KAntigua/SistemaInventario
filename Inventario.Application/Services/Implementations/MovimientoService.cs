using Inventario.Application.DTOs.Movimiento;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Enums;
using Inventario.Domain.Interfaces;

namespace Inventario.Application.Services.Implementations
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly IProductoRepository _productoRepository;
        public MovimientoService(IMovimientoRepository movientoRepository, IProductoRepository productoRepository)
        {
            _movimientoRepository = movientoRepository;
            _productoRepository = productoRepository;
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
            var producto = await _productoRepository
                .GetByIdAsync(dto.ProductoId);

            if (producto == null)
            {
                throw new Exception("Producto no encontrado");
            }

            if (dto.Tipo == TipoMovimiento.Salida)
            {
                if (producto.Stock < dto.Cantidad)
                {
                    throw new Exception("Stock insuficiente");
                }

                producto.Stock -= dto.Cantidad;
            }

            else if (dto.Tipo == TipoMovimiento.Entrada)
            {
                producto.Stock += dto.Cantidad;
            }

            await _productoRepository.UpdateAsync(producto);

            var movimiento = new Movimiento
            {
                Fecha = dto.Fecha,
                Tipo = dto.Tipo,
                Motivo = dto.Motivo,
                UsuarioId = dto.UsuarioId,
                ProductoId = dto.ProductoId,
            };

            var creado = await _movimientoRepository
                .CreateAsync(movimiento);

            var conDetalles = await _movimientoRepository
                .GetByIdWithDetailsAsync(creado.Id);

            var movimientoDto = new MovimientoDTO
            {
                Fecha = conDetalles.Fecha,
                Tipo = conDetalles.Tipo,
                Motivo = conDetalles.Motivo,
                UsuarioNombre = conDetalles.Usuario.Nombre,
                ProductoNombre = conDetalles.Producto.Nombre
            };

            if (producto.Stock <= producto.StockMinimo)
                movimientoDto.Advertencia = $"Stock bajo: {producto.Stock} unidades";

            return movimientoDto;
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
