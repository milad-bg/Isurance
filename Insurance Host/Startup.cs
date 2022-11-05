using Application.Servises.News;
using Application.Servises.Projects;
using AutoMapper;
using Domain.Domain.Entities;
using Domain.Interfaces.AppService_Interfaces;
using Domain.Interfaces.IGenericRepositores;
using Domain.Interfaces.IRepository.News;
using Domain.Interfaces.IRepository.Projects;
using Domain.Interfaces.IUnitOfWork;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Infrastructure.Repositories.News;
using Infrastructure.Repositories.Projects;
using Infrastructure.UnitOFWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
