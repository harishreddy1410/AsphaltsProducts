﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsphaltsProducts.Domain.Models;
using AsphaltsProducts.Infrastructure.Contexts;
using AsphaltsProducts.Service.Layer.ECommerce.ProductsService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using AsphaltsProducts.Presentation.Layer.App_Start;
using AsphaltsProducts.Presentation.Layer.Helpers.Session;
using AsphaltsProducts.Service.Layer;

namespace AsphaltsProducts
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
            //services.AddDbContext<AsphaltsDbContext>(
            //    options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<ApplicationUser, ApplicationUserRole>()
            //    .AddEntityFrameworkStores<AsphaltsDbContext>()
            //    .AddDefaultTokenProviders();

            //services.AddScoped<IAsphaltsDbContext, AsphaltsDbContext>();
            //services.AddScoped<IProductService, ProductService>();
            services.AddTransient<ISessionFactory,SessionFactory>();
            services.AddTransient<IEmailService, EmailService>();
            var config = new MapperConfiguration(c => {
                c.AddProfile<AutoMapperConfig>();
                c.ValidateInlineMaps = false;
            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());

            //AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperConfig>());
            //services.AddAutoMapper();
            
            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Password settings
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequiredUniqueChars = 6;

            //    // Lockout settings
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //    options.Lockout.MaxFailedAccessAttempts = 10;
            //    options.Lockout.AllowedForNewUsers = true;

            //    // User settings
            //    options.User.RequireUniqueEmail = true;
            //});

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.Expiration = TimeSpan.FromDays(150);
            //    options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
            //    options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
            //    options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
            //    options.SlidingExpiration = true;
            //});
            services.AddSession();
            services.AddMvc();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession(new SessionOptions()
            {
                IdleTimeout = TimeSpan.FromDays(1)
            });
            app.UseStaticFiles();


            app.UseMvcWithDefaultRoute();
        }
    }
}
