using Inventario.Application.DTOs.Categoria;


namespace Inventario.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetAllAsync();
        Task<CategoriaDTO> GetByIdAsync(int id);
        Task<CategoriaDTO> CreateAsync(CrearCategoriaDTO dto);
        Task<CategoriaDTO> UpdateAsync(int id, ActualizarCategoriaDTO dto);
        Task DeleteAsync(int id);


    }
}
