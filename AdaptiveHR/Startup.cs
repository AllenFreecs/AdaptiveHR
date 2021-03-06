﻿using System;
using System.Text;
using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using AdaptiveHR.Util.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using NLog.Web;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AdaptiveHR
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Camel Casing
            //services.AddMvc().AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //});

            //Pascal casing
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());



        services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddDbContext<AdaptiveHRContext>(options =>
                          options.UseSqlServer(Configuration.GetConnectionString("AdaptiveDB")));

            services.AddHttpContextAccessor();
            Mapper.Initialize(x =>
                x.AddProfile<AutoMapperProfile>()
                );

            SwaggerConfig.ConfigureSwagger(services);
            Services.ConfigureServices(services, Configuration);

            //Addd configuration validation to ensure all the mappings are done appropriately, any exeception will be thrown at runtime
            Mapper.AssertConfigurationIsValid();


            //Authentication

            services.AddCors();


            // configure jwt authentication
            AppSettings appSettings = new AppSettings();
            appSettings.Secret = Configuration["Secret"];
            appSettings.Issuer = Configuration["Issuer"];
            appSettings.Audience = Configuration["Audience"];
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = appSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = appSettings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "XSRF-TOKEN";
                options.FormFieldName = "X-XSRF-TOKEN";
                options.Cookie.Name = "CXSRF";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IAntiforgery antiforgery)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            loggerFactory.AddNLog();
            env.ConfigureNLog("NLog.config");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.None);
            });

            //Auth

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseMvc();


        }
    }
}
