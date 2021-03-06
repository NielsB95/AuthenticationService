﻿using AuthenticationService.Api;
using AuthenticationService.DataLayer;
using AuthenticationService.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthenticationService
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddApiTools();
			services.AddCors();
			services.AddSecurity(Configuration);
			services.AddDataLayer();
			services.AddMvc()
				// Include controllers from the Api assembly.
				.AddApplicationPart(Assembly.Load("AuthenticationService.Api"))
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
			   .AddJsonOptions(
					options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
				);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			//app.UseHttpsRedirection();
			app.UseSecurity();

			app.UseCors(builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyHeader()
					   .AllowAnyMethod();
			});

			// Add an endpoint for health checking.
			app.UseHealthChecks("/health");

			app.UseMvc();
		}
	}
}
