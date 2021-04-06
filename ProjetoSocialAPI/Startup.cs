using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoSocialAPI.Models.Context;
using ProjetoSocialAPI.Business;
using ProjetoSocialAPI.Business.Implementations;
using ProjetoSocialAPI.Repository.Implementations;
using ProjetoSocialAPI.Repository;

namespace ProjetoSocialAPI
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
            var connection = Configuration["ConnectionStrings:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

            services.AddControllers();

            services.AddApiVersioning();

            services.AddScoped<IAddressBusiness, AddressBusinessImplementation>();
            services.AddScoped<IStudentBusiness, StudentBusinessImplementation>();
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();

            services.AddScoped<IAddressRepository, AddressRepositoryImplementation>();
            services.AddScoped<IStudentRepository, StudentRepositoryImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoSocialAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoSocialAPI v1"));
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
