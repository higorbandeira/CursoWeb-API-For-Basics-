using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuportAPI.Data;

namespace SuportAPI
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            // Configurações 
            _config = config;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Onde vamos colocar nossos serviços

            // Connection String
            string connString = "server=localhost;uid=sa;pwd=123456;database=DEV";

            // Serviços
            services.AddDbContextPool<BaseContext>(options => options.UseSqlServer(connString));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(config => {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });

            app.UseMvc();
        }
    }
}
