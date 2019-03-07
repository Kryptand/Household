using Kryptand.ChefMaster.Infrastructure.Disposal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Disposal.Web
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
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			var connectionString = @"Server=disposal.storage;User ID=root;Password=p4ssw0r#;Database=disposal;";

			services.AddDbContext<DisposalDbContext>(options => options.UseMySql(connectionString));
			services.AddTransient<IDisposalLocationRepository, DisposalLocationRepository>();
			services.AddTransient<IDisposeCategoryRepository, DisposeCategoryRepository>();
			services.AddTransient<IGarbageCollectionDateRepository,GarbageCollectionDateRepository>();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ChefMaster/Disposal", Version = "v1" });
			});
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
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
