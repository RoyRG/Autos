using API.Negocios;
using API.Servicios.Interfaces;
using API.Servicios.Servicios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Servicios
{
    //Creación del kernel para registrar los servicios
    public static class Kernel
    {
        public static IServiceCollection RegistrarServicios(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IServicioLote, ServicioLote>();
            services.AddTransient<IServicioCarro, ServicioCarro>();
            services.AddTransient<IServicioEstado, ServicioEstado>();
            services.AddTransient<IServicioMarca, ServicioMarca>();
            services.AddTransient<IServicioModelo, ServicioModelo>();
            services.RegistrarNegocios(configuration);
            return services;
        }
    }
}
