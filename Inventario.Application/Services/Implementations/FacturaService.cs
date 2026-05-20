using Inventario.Application.DTOs.Factura;
using Inventario.Application.DTOs.Movimiento;
using Inventario.Application.DTOs.Producto;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Enums;
using Inventario.Domain.Interfaces;

namespace Inventario.Application.Services.Implementations
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IDetalleFacturaRepository _detalleFacturaRepository;
        private readonly IProductoRepository _productoRepository;

        public FacturaService(
            IFacturaRepository facturaRepository,
            IDetalleFacturaRepository detalleFacturaRepository,
            IProductoRepository productoRepository)
        {
            _facturaRepository = facturaRepository;
            _detalleFacturaRepository = detalleFacturaRepository;
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<FacturaDTO>> GetAllAsync()
        {

            var facturas = await _facturaRepository.GetAllWithDetailsAsync();

            var facturasDto = facturas.Select(factura => new FacturaDTO
            {
                Id = factura.Id,
                Fecha = factura.Fecha,
                Total = factura.Total,
                UsuarioNombre = factura.Usuario.Nombre,
                Estado = factura.Estado

            });

            return facturasDto;
        }

        public async Task<FacturaDTO?> GetByIdAsync(int id)
        {

            var factura = await _facturaRepository.GetByIdWithDetailsAsync(id);
            if (factura == null) return null;

            return new FacturaDTO
            {
                Id = factura.Id,
                Fecha = factura.Fecha,
                Total = factura.Total,
                UsuarioNombre = factura.Usuario.Nombre,
                Estado = factura.Estado
            };

        }

        public async Task<FacturaDTO> CreateAsync(CrearFacturaDTO dto)
        {
            var factura = new Factura
            {
                Fecha = dto.Fecha,
                UsuarioId = dto.UsuarioId,
                Estado = EstadoFactura.Borrador
            };

            var creado = await _facturaRepository.CreateAsync(factura);

            var detallesFactura = new List<DetalleFactura>();

            foreach (var detalle in dto.Detalles)
            {
                var producto = await _productoRepository
                    .GetByIdAsync(detalle.ProductoId);

                if (producto == null)
                {
                    throw new Exception("Producto no encontrado");
                }

                var detalleFactura = new DetalleFactura
                {
                    FacturaId = creado.Id,
                    ProductoId = detalle.ProductoId,
                    Cantidad = detalle.Cantidad,
                    PrecioUnitario = producto.PrecioVenta
                };

                await _detalleFacturaRepository
                    .CreateAsync(detalleFactura);

                detallesFactura.Add(detalleFactura);
            }

            factura.Total = detallesFactura.Sum(d =>
                d.Cantidad * d.PrecioUnitario);

            await _facturaRepository.UpdateAsync(factura);

            var conDetalles = await _facturaRepository
                .GetByIdWithDetailsAsync(creado.Id);

            return new FacturaDTO
            {
                Id = conDetalles.Id,
                Fecha = conDetalles.Fecha,
                Total = conDetalles.Total,
                Estado = conDetalles.Estado,
                UsuarioNombre = conDetalles.Usuario.Nombre
            };
        }

        public async Task<FacturaDTO> UpdateAsync(int id, ActualizarFacturaDTO dto)
        {

            var factura = await _facturaRepository.GetByIdAsync(id);
            if (factura == null)
            {

                return null;
            }

            factura.Estado = dto.Estado;
     

            await _facturaRepository.UpdateAsync(factura);

            var conDetalles = await _facturaRepository.GetByIdWithDetailsAsync(id);
            return new FacturaDTO { 

                Fecha = conDetalles.Fecha,
                Total = conDetalles.Total,
                Estado = conDetalles.Estado,
                UsuarioNombre = conDetalles.Usuario.Nombre
            };

        }

        public async Task DeleteAsync(int id)
        {
            var factura = await _facturaRepository.GetByIdAsync(id);
            if (factura == null) return;

            await _facturaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FacturaDTO>> GetByUsuarioIdAsync(int id)
        {
            var facturas = await _facturaRepository.GetByUsuarioIdAsync(id);


            var facturasDto = facturas.Select(factura => new FacturaDTO
            {
                Fecha = factura.Fecha,
                Total = factura.Total,
                Estado = factura.Estado,
                UsuarioNombre = factura.Usuario.Nombre
            });

            return facturasDto;

        }

        public async Task<IEnumerable<FacturaDTO>> GetByEstadoAsync(EstadoFactura estado)
        {
            var facturas = await _facturaRepository.GetByEstadoAsync(estado);


            var facturasDto = facturas.Select(factura => new FacturaDTO
            {
                Fecha = factura.Fecha,
                Total = factura.Total,
                Estado = factura.Estado,
                UsuarioNombre = factura.Usuario.Nombre
            });

            return facturasDto;

        }

    }
}
