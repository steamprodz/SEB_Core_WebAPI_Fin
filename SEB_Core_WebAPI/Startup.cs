using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using SEB_Core_WebAPI.Contexts;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Repositories;
using SEB_Core_WebAPI.Services;

namespace SEB_Core_WebAPI
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
            // Default context
            services.AddDbContext<DefaultContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase")));

            // Repositories
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IBundlesRepository, BundlesRepository>();

            // Services
            services.AddTransient<IQuestionsService, QuestionsService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IBundlesService, BundlesService>();

            // MVC
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
