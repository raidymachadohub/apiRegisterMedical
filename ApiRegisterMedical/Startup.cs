using ApiRegisterMedical.Domain;
using ApiRegisterMedical.Repository.Interfaces;
using ApiRegisterMedical.Repository.Repository;
using ApiRegisterMedical.Services.Interfaces;
using ApiRegisterMedical.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ApiRegisterMedical
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddEntityFrameworkNpgsql()
                     .AddDbContext<RegisterMedicalContext>(options =>
                     options.UseNpgsql(Configuration.GetConnectionString("RegisterMedicalDB")));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Register Customer API",
                    Version = "v1",
                    Description = "Sample API Crud",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Raidy Machado",
                        Url = new System.Uri("https://github.com/raidymachadohub")
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json",
                "API Register Medical"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
