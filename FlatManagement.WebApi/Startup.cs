using System;
using System.Collections.Generic;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Extensions;
using FlatManagement.Common.Services;
using FlatManagement.Common.WebApi;
using FlatManagement.WebApi.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlatManagement.WebApi
{
	public class Startup
	{
		public const string CorsPolicyName = "AllowSpecificOrigin";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

			ServiceLocator.Instance.SetConfiguration(configuration);
			ModelSerialiser.Instance.Configuration = configuration;
			TokenHelper.Configure(configuration);
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			string[] origins = Configuration.GetStringArray("Cors:Origins:{0}");

			services.AddCors(options =>
				options.AddPolicy(CorsPolicyName, builder =>
					builder.AllowAnyHeader()
						.AllowAnyMethod()
						.WithOrigins(origins)
						.AllowCredentials())
				);
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddMvc();
			services.Add(new ServiceDescriptor(typeof(IConfiguration), Configuration));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
		{
			ServiceLocator.Instance.AddService<UserInfo>(() => GetUserInfo(svp));

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors(CorsPolicyName);

			app.UseDefaultFiles(new DefaultFilesOptions
			{
				DefaultFileNames = new List<string> { "index.html" }
			});

			app.UseStaticFiles();

			app.UseMvc();
		}

		private UserInfo GetUserInfo(IServiceProvider svp)
		{
			IHttpContextAccessor accessor = svp.GetService<IHttpContextAccessor>();
			return accessor.HttpContext.Items["token"] as UserInfo;
		}
	}
}
