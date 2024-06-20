using DVDRentalAPI.Application.Abstractions.Services;
using DVDRentalAPI.Application.Repositories;
using DVDRentalAPI.Domain.Entities.Identity;
using DVDRentalAPI.Persistence.Context;
using DVDRentalAPI.Persistence.Repositories;
using DVDRentalAPI.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<DVDRentalAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
           


            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<DVDRentalAPIDbContext>();


            services.AddScoped<IActorWriteRepository, ActorWriteRepository>();
            services.AddScoped<IActorReadRepository, ActorReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<IFilmActorWriteRepository, FilmActorWriteRepository>();
            services.AddScoped<IFilmActorReadRepository, FilmActorReadRepository>();
            services.AddScoped<IFilmWriteRepository, FilmWriteRepository>();
            services.AddScoped<IFilmReadRepository, FilmReadRepository>();
            services.AddScoped<IFilmCategoryWriteRepository, FilmCategoryWriteRepository>();
            services.AddScoped<IFilmCategoryReadRepository, FilmCategoryReadRepository>();
            services.AddScoped<ILanguageWriteRepository, LanguageWriteRepository>();
            services.AddScoped<ILanguageReadRepository, LanguageReadRepository>();


            services.AddScoped<IFilmActorService, FilmActorService>();
            services.AddScoped<IFilmCategoryService, FilmCategoryService>();
            
        }
    }
}
