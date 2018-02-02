using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PanfletoCursos.Dados;
using Swashbuckle.AspNetCore.Swagger;

namespace PanfletoCursos
{
    public class Startup
    {
        IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PanfletoContexto>(options => options.UseSqlServer(configuration.GetConnectionString("CursoEF")));
            //adicionando os serviço de contexto de BD, o que eu criei personalizado... Lojacontexto.
            //No exemplo anterior, eu usei o UsingDataMemory ou algo assim, pq queria usar o BD em memória.
            //Pegue a connection string, no arquivo de configurações (apping settings JSON, ou algo assim)
            //App.Settings
            //NavigationExtensions construtor eu to chamando o configuration pra me trazer essas settings
            //E o nome de ref que eu dei é "BancoLojaEF"
            services.AddMvc();

            //Pela primeira vez, vamos criar um SWAGGER. 
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("V1", new Info{
                    Version = "V1",
                    Title = "Cursos Online",
                    Description = "Documentação da Api Cursos Online",
                    TermsOfService = "none",
                    Contact = new Contact{
                        Name = "Fernando Henrique",
                        Email = "fernando.guerra@corujasdev.com.br",
                        Url = "www.corujasdev.com.br"
                    }
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "PanfletoCursos.xml");

                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }
    }
}