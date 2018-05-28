using System;
using System.Collections.Generic;
using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Extensions;
using FlatManagement.Common.Security;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
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
			AddCustom(services);

			services.AddMvc();
			services.Add(new ServiceDescriptor(typeof(IConfiguration), Configuration));
		}

		private void AddCustom(IServiceCollection services)
		{
			services.AddSingleton<IFlatService, FlatService>();
			services.AddSingleton<ITaskService, TaskService>();
			services.AddSingleton<IFlatmateService, FlatmateService>();
			services.AddSingleton<IPeriodTypeService, PeriodTypeService>();

			services.AddSingleton<IFlatDataAccess, FlatDataAccess>();
			services.AddSingleton<ITaskDataAccess, TaskDataAccess>();
			services.AddSingleton<IFlatmateDataAccess, FlatmateDataAccess>();
			services.AddSingleton<IPeriodTypeDataAccess, PeriodTypeDataAccess>();

			services.AddSingleton<IUserInfoProvider, UserInfoProvider>();

			services.AddSingleton<IDatacallsHandler, DatacallsHandler>();

			services.AddSingleton<ICryptoHelper, CryptoHelper>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
		{
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
	}
}
