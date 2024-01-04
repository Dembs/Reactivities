using System.Collections.Generic;
using Application.Activities;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            //We add the CORS Policy to bypass the browser policy. We add the middleware of it just above the authorization
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
            //Service about the mediatr
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(List.Handler).Assembly));
            //Service about the mapping
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}