﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ON.Authentication;
using ON.Content.SimpleCMS.Service.Data;
using ON.Content.SimpleCMS.Service.Models;
using ON.Content.SimpleCMS.Service.Services;

namespace ON.Content.SimpleCMS.Service
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton<IContentDataProvider, FileSystemContentDataProvider>();

            services.AddJwtAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseJwtAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<BackupService>();
                endpoints.MapGrpcService<ContentService>();
                endpoints.MapGrpcService<ServiceOpsService>();
            });
        }
    }
}
