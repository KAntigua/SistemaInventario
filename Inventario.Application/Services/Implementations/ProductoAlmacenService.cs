using Inventario.Application.DTOs.ProductoAlmacen;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Entities;
using Inventario.Domain.Interfaces;


namespace Inventario.Application.Services.Implementations
{
    public class ProductoAlmacenService : IProductoAlmacenService
    {
        private readonly IProductoAlmacenRepository _productoAlmacenRepository;

        public ProductoAlmacenService(IProductoAlmacenRepository productoAlmacenRepository)
        {

            _productoAlmacenRepository = productoAlmacenRepository;
        }

        public async Task<IEnumerable<ProductoAlmacenDTO>> GetAllAsync()
        {

            var productoAlmacenes = await _productoAlmacenRepository.GetAllWithDetailsAsync();

            var productoAlmacenesDto = productoAlmacenes.Select(pa => new ProductoAlmacenDTO
            {

                Id = pa.Id,
                NombreProducto = pa.Producto.Nombre,
                NombreAlmacen = pa.Almacen.Nombre,
                Stock = pa.Stock,
                StockMinimo = pa.StockMinimo
            });
            return productoAlmacenesDto;

        }

        public async Task<ProductoAlmacenDTO?> GetByIdAsync(int id)
        {

            var productoAlmacenes = await _productoAlmacenRepository.GetByIdWithDetailsAsync(id);
            if (productoAlmacenes == null) return null;

            return new ProductoAlmacenDTO
            {
                Id = productoAlmacenes.Id,
                NombreProducto = productoAlmacenes.Producto.Nombre,
                NombreAlmacen = productoAlmacenes.Almacen.Nombre,
                Stock = productoAlmacenes.Stock,
                StockMinimo = productoAlmacenes.StockMinimo
            };


        }

        public async Task<ProductoAlmacenDTO> CreateAsync(CrearProductoAlmacenDTO dto)
        {

            var productoAlmacen = new ProductoAlmacen
            {
                ProductoId = dto.ProductoId,
                AlmacenId = dto.AlmacenId,
                Stock = dto.Stock,
                StockMinimo = dto.StockMinimo
            };

            var creado = await _productoAlmacenRepository.CreateAsync(productoAlmacen);
            var conDetalles = await _productoAlmacenRepository.GetByIdWithDetailsAsync(creado.Id);

            return new ProductoAlmacenDTO
            {
                Id = conDetalles.Id,
                NombreProducto = conDetalles.Producto.Nombre,
                NombreAlmacen = conDetalles.Almacen.Nombre,
                Stock = conDetalles.Stock,
                StockMinimo = conDetalles.StockMinimo

            };

        }

        public async Task<ProductoAlmacenDTO> UpdateAsync(int id, ActualizarProductoAlmacenDTO dto)
        {

            var productoAlmacen = await _productoAlmacenRepository.GetByIdAsync(id);
            if (productoAlmacen == null)
            {

                return null;
            }

            productoAlmacen.Stock = dto.Stock;
            productoAlmacen.StockMinimo = dto.StockMinimo;

            await _productoAlmacenRepository.UpdateAsync(productoAlmacen);

            var conDetalles = await _productoAlmacenRepository.GetByIdWithDetailsAsync(id);
            return new ProductoAlmacenDTO
            {
                Id = conDetalles.Id,
                NombreProducto = conDetalles.Producto.Nombre,
                NombreAlmacen = conDetalles.Almacen.Nombre,
                Stock = conDetalles.Stock,
                StockMinimo = conDetalles.StockMinimo

            };


        }

        public async Task DeleteAsync(int id)
        {
            var productoAlmacen = await _productoAlmacenRepository.GetByIdAsync(id);
            if (productoAlmacen == null) return;

            await _productoAlmacenRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductoAlmacenDTO>> GetByAlmacenIdAsync(int almacenId)
        {
            var productosAlmacen = await _productoAlmacenRepository.GetByAlmacenIdAsync(almacenId);

            var productosAlmacenDto = productosAlmacen.Select(productoAlmacen => new ProductoAlmacenDTO
            {
                Id = productoAlmacen.Id,
                NombreProducto = productoAlmacen.Producto.Nombre,
                NombreAlmacen = productoAlmacen.Almacen.Nombre,
                Stock = productoAlmacen.Stock,
                StockMinimo = productoAlmacen.StockMinimo

            });

            return productosAlmacenDto;

        }

        public async Task<ProductoAlmacenDTO?> GetByProductoYAlmacenAsync(int productoId, int almacenId)
        {
            var productoAlmacen = await _productoAlmacenRepository.GetByProductoYAlmacenAsync(productoId, almacenId);
            if (productoAlmacen == null) return null;

            return new ProductoAlmacenDTO
            {

                Id = productoAlmacen.Id,
                NombreProducto = productoAlmacen.Producto.Nombre,
                NombreAlmacen = productoAlmacen.Almacen.Nombre,
                Stock = productoAlmacen.Stock,
                StockMinimo = productoAlmacen.StockMinimo

            };



        }

 } }
