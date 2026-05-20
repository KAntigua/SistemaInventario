using Inventario.Application.DTOs.Producto;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;

namespace Inventario.Application.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }



        public async Task<IEnumerable<ProductoDTO>> GetAllAsync()
        {

            var productos = await _productoRepository.GetAllWithDetailsAsync();

            var productosDto = productos.Select(producto => new ProductoDTO
            {


                Id = producto.Id,
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                PrecioVenta = producto.PrecioVenta,
                Unidad = producto.Unidad,
                Stock = producto.Stock,
                CategoriaNombre = producto.Categoria.Nombre,
                ProveedorNombre = producto.Proveedor.Nombre



            });

            return productosDto;
        }

        public async Task<ProductoDTO?> GetByIdAsync(int id)
        {

            var producto = await _productoRepository.GetByIdWithDetailsAsync(id);
            if (producto == null) return null;

            return new ProductoDTO
            {
                Id = producto.Id,
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                PrecioVenta = producto.PrecioVenta,
                Unidad = producto.Unidad,
                Stock = producto.Stock,
                CategoriaNombre = producto.Categoria.Nombre,
                ProveedorNombre = producto.Proveedor.Nombre
            };

        }

        public async Task<ProductoDTO> CreateAsync(CrearProductoDTO dto)
        {
            var productos = await _productoRepository.GetAllAsync();

            var codigoGenerado =
                $"PROD-{(productos.Count() + 1):D4}";

            var producto = new Producto
            {
                Codigo = codigoGenerado,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                PrecioVenta = dto.PrecioVenta,
                PrecioCompra = dto.PrecioCompra,
                Unidad = dto.Unidad,
                Stock = dto.Stock,
                StockMinimo = dto.StockMinimo,
                CategoriaId = dto.CategoriaId,
                ProveedorId = dto.ProveedorId

            };

            var creado = await _productoRepository.CreateAsync(producto);
            var conDetalles = await _productoRepository.GetByIdWithDetailsAsync(creado.Id);

            return new ProductoDTO {
                Codigo = conDetalles.Codigo,
                Nombre = conDetalles.Nombre,
                Descripcion = conDetalles.Descripcion,
                PrecioVenta =conDetalles.PrecioVenta,
                Unidad = conDetalles.Unidad,
                Stock = conDetalles.Stock,
                CategoriaNombre = conDetalles.Categoria.Nombre,
                ProveedorNombre = conDetalles.Proveedor.Nombre

            };

        }

        public async Task<ProductoDTO> UpdateAsync(int id, ActualizarProductoDTO dto)
        { 

            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null)
            {

                return null;
            }

            producto.Codigo = dto.Codigo;
            producto.Nombre = dto.Nombre;
            producto.Descripcion = dto.Descripcion;
            producto.PrecioVenta = dto.PrecioVenta; 
            producto.Unidad = dto.Unidad;
            producto.Stock = dto.Stock;
            producto.CategoriaId = dto.CategoriaId;
            producto.ProveedorId = dto.ProveedorId;

            await _productoRepository.UpdateAsync(producto);

            var conDetalles = await _productoRepository.GetByIdWithDetailsAsync(id);
            return new ProductoDTO {

                Codigo = conDetalles.Codigo,
                Nombre = conDetalles.Nombre,
                Descripcion = conDetalles.Descripcion,
                PrecioVenta = conDetalles.PrecioVenta,
                Unidad = conDetalles.Unidad,
                Stock = conDetalles.Stock,
                CategoriaNombre = conDetalles.Categoria.Nombre,
                ProveedorNombre = conDetalles.Proveedor.Nombre

            };

        }

        public async Task DeleteAsync(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null) return;

            await _productoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductoDTO>> GetProductosBajoStockAsync()
        {
            var productos = await _productoRepository.GetProductosBajoStockAsync();

            var productosDto = productos.Select(producto => new ProductoDTO
            {


                Id = producto.Id,
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                PrecioVenta = producto.PrecioVenta,
                Unidad = producto.Unidad,
                Stock = producto.Stock,
                CategoriaNombre = producto.Categoria.Nombre,
                ProveedorNombre = producto.Proveedor.Nombre



            });

          return productosDto;


        }




    }
}