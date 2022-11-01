using Domain.Domain.Entities;
using Domain.Interfaces.IGenericRepositores;
using Domain.Interfaces.IUnitOfWork;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Infrastructure.UnitOFWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


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

            ////GenericRepository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            ////unitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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
