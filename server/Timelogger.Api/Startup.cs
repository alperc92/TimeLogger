using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Timelogger.Entities;
using Timelogger.Persistence;
using Timelogger.Api.Services;
using System.Collections.Generic;
using Timelogger.Api.DomainServices;

namespace Timelogger.Api
{
	public class Startup
	{
		private readonly IWebHostEnvironment _environment;
		public IConfigurationRoot Configuration { get; }

		public Startup(IWebHostEnvironment env)
		{
			_environment = env;

			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("e-conomic interview"));
			services.AddLogging(builder =>
			{
				builder.AddConsole();
				builder.AddDebug();
			});

			services.AddMvc(options => options.EnableEndpointRouting = false);

			if (_environment.IsDevelopment())
			{
				services.AddCors();
			}

			//Dependency Injection Definitions.
			services.AddScoped<IDayRepository, DayRepository>();
			services.AddScoped<IDayService, DayService>();

			services.AddScoped<IWeekRepository, WeekRepository>();
			services.AddScoped<IWeekDomainService, WeekDomainService>();
			services.AddScoped<IWeekService, WeekService>();

			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<IProjectService, ProjectService>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseCors(builder => builder
					.AllowAnyMethod()
					.AllowAnyHeader()
					.SetIsOriginAllowed(origin => true)
					.AllowCredentials());
			}

			app.UseMvc();


			var serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
			using (var scope = serviceScopeFactory.CreateScope())
			{
				SeedDatabase(scope);
			}
		}

		private static void SeedDatabase(IServiceScope scope)
		{
			var context = scope.ServiceProvider.GetService<ApiContext>();

			//Days
			Day day1 = new Day
			{
				Id = 1,
				WeekId = 1,
				DayOfWeek = DayOfWeek.MONDAY,
				Hours = 8.0
			};

			Day day2 = new Day
			{
				Id = 2,
				DayOfWeek = DayOfWeek.TUESDAY,
				Hours = 8.0
			};

			Day day3 = new Day
			{
				Id = 3,
				WeekId = 1,
				DayOfWeek = DayOfWeek.WEDNESDAY,
				Hours = 8.0
			};
			Day day4 = new Day
			{
				Id = 4,
				WeekId = 1,
				DayOfWeek = DayOfWeek.THURSDAY,
				Hours = 8.0
			};
			Day day5 = new Day
			{
				Id = 5,
				WeekId = 1,
				DayOfWeek = DayOfWeek.FRIDAY,
				Hours = 8.0
			};
			context.Days.Add(day1);
			context.Days.Add(day2);
			context.Days.Add(day3);
			context.Days.Add(day4);
			context.Days.Add(day5);


			//Weeks
			Week w1 = new Week
			{
				Id = 1,
				WeekNr = 1,
				ProjectId = 1,
				Days = new List<Day> { day1, day2, day3, day4, day5}
			};
			context.Weeks.Add(w1);

			//Projects
			var testProject1 = new Project
			{
				Id = 1,
				Name = "e-conomic Interview",
				Weeks = new List<Week> { w1 }
			};			
			context.Projects.Add(testProject1);

			context.SaveChanges();
		}
	}
}