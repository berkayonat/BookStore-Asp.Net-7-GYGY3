using BookStore.Application.Interfaces;
using BookStore.Persistence.Data;
using BookStore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence
{
    public static class DependecyInjection
    {

        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddScoped<IAuthorRepository, EFAuthorRepository>();
            services.AddScoped<IGenreRepository, EFGenreRepository>();
            services.AddScoped<IPublisherRepository, EFPublisherRepository>();
        }

    }
}
