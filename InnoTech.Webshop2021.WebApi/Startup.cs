using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnoTech.Webshop2021.Core.IServices;
using InnoTech.Webshop2021.DataAccess;
using InnoTech.Webshop2021.DataAccess.Entities;
using InnoTech.Webshop2021.DataAccess.Repositories;
using InnoTech.Webshop2021.Domain.IRepositories;
using InnoTech.Webshop2021.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace InnoTech.Webshop2021.WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InnoTech.Webshop2021.WebApi", Version = "v1" });
            });
            services.AddCors(opt => opt
                .AddPolicy("dev-policy", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddDbContext<MainDbContext>(opt =>
            {
                opt.UseSqlite("Data Source=main.db");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MainDbContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InnoTech.Webshop2021.WebApi v1"));
                app.UseCors("dev-policy");
                //Dinko
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                
                //ostergodt
                //Nuurfi
                ctx.Products.AddRange(new List<ProductEntity>
                {
                    new () {Name = "Product1"},
                    new () {Name = "Product2"},
                    new ProductEntity{Name = "Product3"},
                });
                ctx.SaveChanges();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}