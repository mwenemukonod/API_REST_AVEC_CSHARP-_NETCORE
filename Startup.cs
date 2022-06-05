using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MairieTaxeAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(x => // pour utiliser swagger comme testeur on ajouter ça
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "RAFIKI2TECH API", Version = "v1" });// 5.3.2
               
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())  //ici on recupere le teste offline
            {
                app.UseDeveloperExceptionPage();
                //ajouter l'utilisation de la version du swagger installer et retouver dans le meme dossier que le system avec AppContext.BaseDirectory
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/Swagger/v1/swagger.json", "RAFIKI2TECH API");
                    var filePath = Path.Combine(System.AppContext.BaseDirectory, "MyApi.xml");
                }
                    );
            }
            else
            {
                app.UseHsts();
                app.UseSwaggerUI(c =>
                {
                   
                    c.SwaggerEndpoint("/rafiki2techapi/Swagger/v1/swagger.json", "RAFIKI2TECH API");
                    var filePath = Path.Combine(System.AppContext.BaseDirectory, "MyApi.xml");

                }
                   );
            }
            app.UseSwagger(); // pour gestion de l'utilisation du Swagger proprement dit
            app.UseHttpsRedirection(); // pour gestion du serveur Http
            app.UseMvc(); // pour la gestion du MVC
        }
    }
}
