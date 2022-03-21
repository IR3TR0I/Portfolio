using CodeTour.Dominio.Commands.Usuario;
using CodeTour.Dominio.Handlers.Pacote;
using CodeTour.Dominio.Queries.Commands.Pacote;
using CodeTour.Dominio.Queries.Commands.Usuario;
using CodeTour.Dominio.Queries.Pacote;
using CodeTour.Dominio.Queries.Usuarios;
using CodeTour.Dominio.Repositorios;
using CodeTour.Infra.Context;
using CodeTour.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Api
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
            services.AddDbContext<CodeTourContext>(o => o.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodeTour.Api", Version = "v1" });
            });

            #region Injeção De Dependencia Usuario
            services.AddTransient<IUsuarioRepositorio, UsuarioRepository>();
            services.AddTransient<CriarContaCommandHandler, CriarContaCommandHandler>();
            services.AddTransient<AlterarSenhaCommandHandler, AlterarSenhaCommandHandler>();
            services.AddTransient<LogarCommandHandler, LogarCommandHandler>();
            services.AddTransient<EsqueciSenhaCommand, EsqueciSenhaCommand>();
            services.AddTransient<AlterarUsuarioCommandHandler, AlterarUsuarioCommandHandler>();
            services.AddTransient<ListarUsuarioQueryHandler, ListarUsuarioQueryHandler>();
            services.AddTransient<BuscarUsuarioPorIdQueryHandler, BuscarUsuarioPorIdQueryHandler>();
            #endregion

            #region Injeção De Dependencia Pacote
            services.AddTransient<IPacoteRepositorio, PacoteRepository>();
            services.AddTransient<AdicionarPacoteHandler, AdicionarPacoteHandler>();
            services.AddTransient<AlterarPacoteHandler, AlterarPacoteHandler>();
            services.AddTransient<AlterarImagemHandler, AlterarImagemHandler>();
            services.AddTransient<AlterarStatusHandler, AlterarStatusHandler>();
            services.AddTransient<ListarPacoteQueryHandler, ListarPacoteQueryHandler>();
            services.AddTransient<BuscarPacotePorIdQueryHandler, BuscarPacotePorIdQueryHandler>();
            #endregion


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Token:issuer"],
                        ValidAudience = Configuration["Token:audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenSecreto"]))
                    };
                });

            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader());

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeTour.Api v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
