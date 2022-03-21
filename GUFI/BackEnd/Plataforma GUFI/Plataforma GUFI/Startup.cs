using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Plataforma_GUFI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //ADICIONANDO CONTROLADORES
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {   
                    //IGNORA O LOOPING DE CONSULTAS
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //IGNORA VALORES NULOS AO FAZER JUNÇÕES NAS CONSULTAS
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // Adicionando a Política De CORS
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                        builder => {
                            builder.WithOrigins("http://localhost:3000", "http://localhost:19006")
                                                                                .AllowAnyHeader()
                                                                                .AllowAnyMethod();
                        }
                    );
            });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gufi.webApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services
               // Define a forma de autentica��o
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })

               .AddJwtBearer("JwtBearer", options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                        // define que o issuer esta validado
                        ValidateIssuer = true,

                       // define que o audience esta validado
                       ValidateAudience = true,

                       // define que o tempo de vida esta validado
                       ValidateLifetime = true,

                        // forma de criptografia e a chave de autentica��o
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao")),

                        // verifica o tempo de expiracaoo do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // define o nome da issuer, de onde est� vindo
                        ValidIssuer = "Gufi.webApi",

                        // define o nome da audience, para onde est� indo
                        ValidAudience = "Gufi.webApi"
                   };
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(C => 
            {
                C.SwaggerEndpoint("/swagger/v1/swagger.json", "GuFi.webApi");
                C.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            // Habilita autenticacao
            app.UseAuthentication();

            // Habilita autorizacao
            app.UseAuthorization();

            // Habilita o CORS
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
