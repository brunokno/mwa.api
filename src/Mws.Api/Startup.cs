using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services;
using ModernStore.Infra.Contexts;
using ModernStore.Infra.Repositories;
using ModernStore.Infra.Services;
using ModernStore.Infra.Transaction;
using ModernStore.Shared;

namespace Mws.Api
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                .Build());
            });

            services.AddMvc(); //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddResponseCompression();

            //Transient - toda vez que vc chamar um construtor ele vai gerar uma nova interface
            //Scoped - ele vai criar uma interface só para todo o contexto
            //Então o banco de dados que vamos passar de uma classe para outra não é legal criar um transient, é  melhor criar um scoped
            services.AddScoped<ModernStoreDataContext, ModernStoreDataContext>();
            services.AddTransient<IUow, Uow>();
            //Então assim:
            //Toda vez que alguém pedir um ModernStoreDataContext eu vou dar um ModernStoreDataContext que já existe, e se não existir nenhum eu vou criar um novo.
            //Toda vez que alguém pedir um ICustomerRepository, eu vou dar uma nova instância de CustomerRepository.
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IEmailService, EmailService>();

            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
            services.AddTransient<OrderCommandHandler, OrderCommandHandler>();

            //Scoped é singleton *Vai ser instanciado uma vez por request
            //transient é uma nova instancia *vai ser instanciado toda vez que for preciso
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors("CorsPolicy");

            //app.UseHttpsRedirection();
            app.UseMvc();
            app.UseResponseCompression();

            Runtime.ConnectionString = Configuration["ConnectionStrings:CnnStr"];
        }
    }
}
