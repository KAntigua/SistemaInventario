using Inventario.Application.DTOs.Almacen;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;

namespace Inventario.Application.Services.Implementations
{
    public class AlmacenService : IAlmacenService
    {
        private readonly IAlmacenRepository _almacenRepository;

        public AlmacenService(IAlmacenRepository almacenRepository)
        {

            _almacenRepository = almacenRepository;
        }

        public async Task<IEnumerable<AlmacenDTO>> GetAllAsync()
        {

            var almacenes = await _almacenRepository.GetAllAsync();

            var almacenesDto = almacenes.Select(almacen => new AlmacenDTO
            {


                Id = almacen.Id,
                Nombre = almacen.Nombre,
                Empresa = almacen.Empresa,
                Direccion = almacen.Direccion
            });

            return almacenesDto;
        }

        public async Task<AlmacenDTO?> GetByIdAsync(int id)
        {

            var almacen = await _almacenRepository.GetByIdAsync(id);
            if (almacen == null) return null;

            return new AlmacenDTO
            {
                Id = almacen.Id,
                Nombre = almacen.Nombre,
                Empresa = almacen.Empresa,
                Direccion = almacen.Direccion
            };

        }

        public async Task<AlmacenDTO> CreateAsync(CrearAlmacenDTO dto)
        {

            var almacen = new Almacen
            {

                Nombre = dto.Nombre,
                Empresa = dto.Empresa,
                Direccion = dto.Direccion

            };

            var creado = await _almacenRepository.CreateAsync(almacen);

            return new AlmacenDTO
            {

                Id = creado.Id,
                Nombre = creado.Nombre,
                Empresa = creado.Empresa,
                Direccion= creado.Direccion

            };

        }

        public async Task<AlmacenDTO> UpdateAsync(int id, ActualizarAlmacenDTO dto)
        {

            var almacen = await _almacenRepository.GetByIdAsync(id);
            if (almacen == null)
            {

                return null;
            }

            
            almacen.Nombre = dto.Nombre;
            almacen.Empresa = dto.Empresa;
            almacen.Direccion = dto.Direccion;

            await _almacenRepository.UpdateAsync(almacen);

            return new AlmacenDTO
            {
                Id= almacen.Id,
                Nombre = almacen.Nombre,
                Empresa = almacen.Empresa,
                Direccion = almacen.Direccion

            };

        }

        public async Task DeleteAsync(int id)
        {
            var almacen = await _almacenRepository.GetByIdAsync(id);
            if (almacen == null) return;

            await _almacenRepository.DeleteAsync(id);
        }
    }
}
