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
using ProjetoSocialAPI.Repository;
using ProjetoSocialAPI.Hypermedia.Filters;
using System;
using ProjetoSocialAPI.Repository.Generic;
using Serilog;
using Microsoft.Net.Http.Headers;
using ProjetoSocialAPI.Hypermedia.Enhancer;

namespace ProjetoSocialAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .CreateLogger();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // MySql connection context
            var connection = Configuration["ConnectionStrings:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

            // Controllers
            services.AddControllers();

            // MVC Versioning
            services.AddApiVersioning();

            // MVC Add suport for XML and JSON
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
                .AddXmlSerializerFormatters();

            // HATEOAS
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnhancerList.Add(new StudentEnhancer());
            filterOptions.ContentResponseEnhancerList.Add(new AddressEnhancer());
            filterOptions.ContentResponseEnhancerList.Add(new PersonEnhancer());

            services.AddSingleton(filterOptions);

            // Dependency injection
            // -Business's
            services.AddScoped<IAddressBusiness, AddressBusinessImplementation>();
            services.AddScoped<IStudentBusiness, StudentBusinessImplementation>();
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            
            // -Repository's
            // --Generic Repository
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo 
                    { 
                        Title = "ProjetoSocialAPI",
                        Version = "v1",
                        Description = "Destinado ao projeto social 'Crescendo no esporte'.",
                        Contact = new OpenApiContact
                        {
                            Name = "Thomas Kimberly",
                            Url  = new Uri("https://github.com/dodietks")
                        }
                    });
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
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
