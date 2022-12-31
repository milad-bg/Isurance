using Application.Servises.Cities;
using Application.Servises.Files;
using Application.Servises.Informaiton;
using Application.Servises.News;
using Application.Servises.Projects;
using Application.Servises.Users;
using AutoMapper;
using Domain.Domain.Entities;
using Domain.Interfaces.IGenericRepositores;
using Domain.Interfaces.IRepository.Files;
using Domain.Interfaces.IRepository.Informations;
using Domain.Interfaces.IRepository.News;
using Domain.Interfaces.IRepository.Projects;
using Domain.Interfaces.IRepository.Users;
using Domain.Interfaces.IUnitOfWork;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Infrastructure.Repositories.Files;
using Infrastructure.Repositories.Information;
using Infrastructure.Repositories.News;
using Infrastructure.Repositories.Projects;
using Infrastructure.Repositories.Users;
using Infrastructure.UnitOFWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;

namespace Insurance_Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddDbContext<DataBaseDbcontext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("Db"));
            });
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DataBaseDbcontext>().AddDefaultTokenProviders();

            services.AddTransient<INewsCastService, NewsCastServise>();
            services.AddTransient<INewsCastRepository, NewsCastRepository>();

            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IFileRepository, FileRepository>();

            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICityService, CityServise>();


            services.AddTransient<IAboutUsRepository, AboutUsRepository>();
            services.AddTransient<IAboutUsService, AboutUsServise>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserservice, UserService>();

            ConfigureCors(services);

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<ApplicationLogs>>();
            services.AddSingleton(typeof(ILogger), logger);

            ////GenericRepository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            ////unitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IProjectAppService, ProjectAppService>();
            services.AddTransient<IProjectRepository, ProjectRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Implement Swagger UI",
                    Description = "A simple example to Implement Swagger UI",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("Policy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
            });
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(s => s.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowAnyOrigin();
            }));
        }
    }
}
