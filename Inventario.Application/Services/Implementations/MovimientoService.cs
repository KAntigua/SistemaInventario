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
        private readonly IProductoAlmacenRepository _productoAlmacenRepository;

        public MovimientoService(IMovimientoRepository movientoRepository, IProductoRepository productoRepository, IProductoAlmacenRepository productoAlmacenRepository)
        {
            _movimientoRepository = movientoRepository;
            _productoRepository = productoRepository;
            _productoAlmacenRepository = productoAlmacenRepository;
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
                ProductoNombre = movimiento.Producto.Nombre,
                AlmacenNombre = movimiento.Almacen.Nombre



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
                ProductoNombre = movimiento.Producto.Nombre,
                AlmacenNombre = movimiento.Almacen.Nombre

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

            var productoAlmacen = await _productoAlmacenRepository
                .GetByProductoYAlmacenAsync(dto.ProductoId, dto.AlmacenId);

            if (dto.Tipo == TipoMovimiento.Salida)
            {
                if (productoAlmacen == null)
                    throw new Exception("Producto no encontrado en este almacén");

                if (producto.Stock < dto.Cantidad)
                    throw new Exception("Stock global insuficiente");

                if (productoAlmacen.Stock < dto.Cantidad)
                    throw new Exception("Stock insuficiente en este almacén");

                producto.Stock -= dto.Cantidad;
                productoAlmacen.Stock -= dto.Cantidad;

                await _productoAlmacenRepository.UpdateAsync(productoAlmacen);
            }
            else if (dto.Tipo == TipoMovimiento.Entrada)
            {
                producto.Stock += dto.Cantidad;

                if (productoAlmacen == null)
                {
                    productoAlmacen = new ProductoAlmacen
                    {
                        ProductoId = dto.ProductoId,
                        AlmacenId = dto.AlmacenId,
                        Stock = dto.Cantidad,
                        StockMinimo = 5
                    };

                    await _productoAlmacenRepository.CreateAsync(productoAlmacen);
                }
                else
                {
                    productoAlmacen.Stock += dto.Cantidad;

                    await _productoAlmacenRepository.UpdateAsync(productoAlmacen);
                }
            }

            await _productoRepository.UpdateAsync(producto);

            var movimiento = new Movimiento
            {
                Fecha = dto.Fecha,
                Tipo = dto.Tipo,
                Motivo = dto.Motivo,
                UsuarioId = dto.UsuarioId,
                ProductoId = dto.ProductoId,
                AlmacenId = dto.AlmacenId
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
                ProductoNombre = conDetalles.Producto.Nombre,
                AlmacenNombre = conDetalles.Almacen.Nombre
            };

            if (producto.Stock <= producto.StockMinimo)
                movimientoDto.Advertencia = $"Stock global bajo: {producto.Stock} unidades";

            if (productoAlmacen.Stock <= productoAlmacen.StockMinimo)
                movimientoDto.Advertencia = $"Stock bajo en almacén: {productoAlmacen.Stock} unidades";

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
                ProductoNombre = movimiento.Producto.Nombre,
                AlmacenNombre = movimiento.Almacen.Nombre

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
                ProductoNombre = movimiento.Producto.Nombre,
                AlmacenNombre = movimiento.Almacen.Nombre
            });
            return movimientosDto;

        }
    }
}
