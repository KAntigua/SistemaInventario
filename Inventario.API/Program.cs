
using Inventario.Application.Services.Implementations;
using Inventario.Application.Services.Interfaces;
using Inventario.Domain.Interfaces;
using Inventario.Infrastructure.Persistencia;
using Inventario.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventario.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); 

            //DbContext
            builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Repositorios
            builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
            builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            //Servicios
            builder.Services.AddScoped<IProductoService, ProductoService>();
            builder.Services.AddScoped<ICategoriaService, CategoriaService>();
            builder.Services.AddScoped<IProveedorService, ProveedorService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IFacturaService, FacturaService>();
            builder.Services.AddScoped<IMovimientoService, MovimientoService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
             

            app.MapControllers();

            app.Run();
        }
    }
}
