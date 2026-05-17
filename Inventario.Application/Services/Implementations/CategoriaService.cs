using Inventario.Application.DTOs.Categoria;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;

namespace Inventario.Application.Services.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository) {
        
        _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
        {

            var categorias = await _categoriaRepository.GetAllAsync();

            var categoriasDto = categorias.Select(categoria => new CategoriaDTO
            {


                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion

            });

            return categoriasDto;
        }

        public async Task<CategoriaDTO?> GetByIdAsync(int id)
        {

            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null) return null;

            return new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
            };

        }

        public async Task<CategoriaDTO> CreateAsync(CrearCategoriaDTO dto)
        {

            var categoria = new Categoria
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion

            };

            var creado = await _categoriaRepository.CreateAsync(categoria);

            return new CategoriaDTO
            {
                Nombre = creado.Nombre,
                Descripcion = creado.Descripcion,

            };

        }

        public async Task<CategoriaDTO> UpdateAsync(int id, ActualizarCategoriaDTO dto)
        {

            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null)
            {

                return null;
            }


            categoria.Nombre = dto.Nombre;
            categoria.Descripcion = dto.Descripcion;

            await _categoriaRepository.UpdateAsync(categoria);

            return new CategoriaDTO
            {

                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion

            };

        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null) return;

            await _categoriaRepository.DeleteAsync(id);
        }

       
    }
}
