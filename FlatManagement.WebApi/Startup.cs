using System.Collections.Generic;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Extensions;
using FlatManagement.Common.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlatManagement.WebApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			ServiceLocator.Instance.SetConfiguration(configuration);
			ModelSerialiser.Instance.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			string[] origins = Configuration.GetStringArray("Cors:Origins:{0}");
			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin", builder =>
				{
					builder.WithOrigins(origins);
					builder.AllowCredentials();
					builder.AllowAnyHeader();
					builder.AllowAnyMethod();
				});
			});

			services.AddMvc();
			services.Configure<MvcOptions>(options =>
			{
				options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
			});
			services.Add(new ServiceDescriptor(typeof(IConfiguration), Configuration));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors("AllowSpecificOrigin");
			app.UseDefaultFiles(new DefaultFilesOptions
			{
				DefaultFileNames = new List<string> { "index.html" }
			});

			app.UseStaticFiles();

			app.UseMvc();
		}
	}
}
