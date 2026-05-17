using Inventario.Application.DTOs.Factura;
using Inventario.Application.DTOs.Movimiento;
using Inventario.Application.DTOs.Producto;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Enums;
using Inventario.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Application.Services.Implementations
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaService(IFacturaRepository facturaRepository) { 
        
        _facturaRepository = facturaRepository;
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
            var conDetalles = await _facturaRepository.GetByIdWithDetailsAsync(creado.Id);

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
