using FluentValidation.AspNetCore;
using AutoMapper;
using GoCamping.BLL.Mapping;
using GoCamping.BLL.Services;
using GoCamping.BLL.Services.Interface;
using GoCamping.DAL.Data;
using GoCamping.DAL.DBModel;
using GoCamping.DAL.Dtos;
using GoCamping.DAL.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoCamping.DAL.Repository;
using GoCamping.BLL.Exceptions;
using GoCamping.BLL.Validations;
using Microsoft.AspNetCore.Http;
using GoCamping.BLL.Helper;
using Microsoft.AspNetCore.Identity;

namespace GoCamping.WebAdmin
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
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            // Add AutoMapper
            services.AddAutoMapper(typeof(CustomMapping));

            //services
            services.AddScoped<IGenericService<ProductDto, Product>, GenericService<ProductDto, Product>>();
            services.AddScoped<IGenericService<ContactDto, Contact>, GenericService<ContactDto, Contact>>();
            
            //repos
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //exception
            services.AddSingleton<CustomException>();


            //validation
            services.AddControllersWithViews();
            services.AddFluentValidation(fv => {
                    fv.RegisterValidatorsFromAssemblyContaining<ContactValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<ProductValidation>();
                });



            services.AddControllersWithViews();
                services.AddIdentity<AppUser, AppRole>(opts =>
                {

                    opts.User.RequireUniqueEmail = true;
                    opts.User.AllowedUserNameCharacters = "abcçdefgðhýijklmnoöpqrsþtuüvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";

                    opts.Password.RequiredLength = 4;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;

                }).AddPasswordValidator<CustomPasswordValidator>()
  .AddUserValidator<CustomUserValidator>()
  .AddErrorDescriber<CustomIdentityErrorDescriber>()
  .AddEntityFrameworkStores<AppDbContext>()
  .AddDefaultTokenProviders();

            CookieBuilder cookieBuilder = new CookieBuilder();
            cookieBuilder.Name = "FinalProject";
            cookieBuilder.HttpOnly = false;
            cookieBuilder.SameSite = SameSiteMode.Lax;
            cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;

            services.ConfigureApplicationCookie(opts =>
            {

                opts.Cookie = cookieBuilder;
                opts.SlidingExpiration = true;
                opts.ExpireTimeSpan = System.TimeSpan.FromDays(60);

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
