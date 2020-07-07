using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DealerAPI.Data;
using DealerAPI.Data.Repository;
using DealerAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DealerAPI
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
            services.AddTransient<IDealerService, DealerService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IDealerRepository, DealerRepository>();
            services.AddScoped<IUserService, UserService>();

            //Entity Framework Core config
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<DealerDbContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("DealerConnection")); }
            );

            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
            }).AddEntityFrameworkStores<DealerDbContext>()
            .AddDefaultTokenProviders();

            //JWT config
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["AuthSettings:Audience"],
                    ValidIssuer = Configuration["AuthSettings:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthSettings:Key"])),
                    ValidateIssuerSigningKey = true
                };
            });



            //automapper configuration
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => { options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader(); });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(options => { options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader(); });
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
