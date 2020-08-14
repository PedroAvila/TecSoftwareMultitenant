using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TecSoftware.Core;
using TecSoftware.Infrastructure;
using TecSoftware.Infrastructure.Data.Business;
using TecSoftware.Infrastructure.Data.Catalogo;

namespace TecSoftware.Api
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });



            var connectionString = Configuration.GetConnectionString("CatalogoInquilino");
            services.AddDbContext<CatalogoContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<BusinessContext>(ServiceLifetime.Scoped);
            //services.AddScoped<ITenantProvider, WebTenantProvider>();


            services.AddTransient<ISdServidor, SdServidor>();
            services.AddTransient<ISdBaseDato, SdBaseDato>();
            services.AddTransient<ISdInquilino, SdInquilino>();
            services.AddTransient<ISdUsuario, SdUsuario>();

            services.AddScoped(typeof(IInquilinoRepository<>), typeof(BaseInquilinoRepository<>));



            services.AddHttpContextAccessor();
            services.AddSingleton(new Startup(Configuration));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWebTenantProvider();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
