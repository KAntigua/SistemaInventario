
using Inventario.Application.DTOs.Proveedor;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;

namespace Inventario.Application.Services.Implementations
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository) {

            _proveedorRepository = proveedorRepository;
        }

        public async Task<IEnumerable<ProveedorDTO>> GetAllAsync()
        {

            var proveedores = await _proveedorRepository.GetAllAsync();

            var proveedoresDto = proveedores.Select(proveedor => new ProveedorDTO
            {


                Id = proveedor.Id,
                RNC = proveedor.RNC,
                Telefono = proveedor.Telefono,
                Direccion = proveedor.Direccion,
                Correo = proveedor.Correo,
                Nombre = proveedor.Nombre


            });

            return proveedoresDto;
        }

        public async Task<ProveedorDTO?> GetByIdAsync(int id)
        {

            var proveedor = await _proveedorRepository.GetByIdAsync(id);
            if (proveedor == null) return null;

            return new ProveedorDTO
            {
                Id = proveedor.Id,
                RNC = proveedor.RNC,
                Telefono = proveedor.Telefono,
                Direccion = proveedor.Direccion,
                Correo = proveedor.Correo,
                Nombre = proveedor.Nombre
            };

        }

        public async Task<ProveedorDTO> CreateAsync(CrearProveedorDTO dto)
        {

            var proveedor = new Proveedor
            {
                RNC = dto.RNC,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Correo = dto.Correo,
                Nombre = dto.Nombre

            };

            var creado = await _proveedorRepository.CreateAsync(proveedor);

            return new ProveedorDTO
            {
                Id = creado.Id,
                RNC = creado.RNC,
                Telefono = creado.Telefono,
                Direccion = creado.Direccion,
                Correo = creado.Correo,
                Nombre = creado.Nombre
            };

        }

        public async Task<ProveedorDTO> UpdateAsync(int id, ActualizarProveedorDTO dto)
        {

            var proveedor = await _proveedorRepository.GetByIdAsync(id);
            if (proveedor == null)
            {

                return null;
            }


            proveedor.RNC = dto.RNC;
            proveedor.Telefono = dto.Telefono;
            proveedor.Direccion = dto.Direccion;
            proveedor.Correo = dto.Correo;
            proveedor.Nombre = dto.Nombre;

            await _proveedorRepository.UpdateAsync(proveedor);

            return new ProveedorDTO
            {
                RNC = proveedor.RNC,
                Telefono = proveedor.Telefono,
                Direccion = proveedor.Direccion,
                Correo = proveedor.Correo,
                Nombre = proveedor.Nombre
            };

        }

        public async Task DeleteAsync(int id)
        {
            var proveedor = await _proveedorRepository.GetByIdAsync(id);
            if (proveedor == null) return;

            await _proveedorRepository.DeleteAsync(id);
        }


    }
}
