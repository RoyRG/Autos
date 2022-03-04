using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Data
{
    public static class Kernel
    {
        const string cadenaConexion = @"Data Source=DESKTOP-EIGQN0C; Initial Catalog=Autos; User ID=sa; Password=royale681018";
        public static IServiceCollection RegistrarRepositorios<TContexto>(this IServiceCollection services) where TContexto : DbContext
        {
            services.AddDbContext<Contexto>(
            options => options.UseSqlServer(cadenaConexion));
            return services;
        }
    }
}

