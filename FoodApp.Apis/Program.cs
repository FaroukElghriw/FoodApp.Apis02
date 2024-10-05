
using AutoMapper;
using FoodApp.Api.Extensions;
using FoodApp.Api.Helper;
using Microsoft.Extensions.Options;
using ProjectManagementSystem.Helper;

namespace FoodApp.Apis
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			//builder.Services.AddControllers();
			//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			//builder.Services.AddEndpointsApiExplorer();
			//builder.Services.AddSwaggerGen();
			builder.Services.AddApplicationService(builder.Configuration);
			var app = builder.Build();

			MapperHandler.mapper = app.Services.GetService<IMapper>();
			TokenGenerator.options = app.Services.GetService<IOptions<JwtOptions>>()!.Value;
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
