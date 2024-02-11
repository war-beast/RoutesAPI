using BLL.Services;
using DAL.Context;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RoutesAPI;
using RoutesAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(BLL.Interfaces.ISearchService).Assembly);

var connectionString = $"Host={builder.Configuration.GetSection("Database:ConnectionString").Value}";
builder.Services.InitDatabase(connectionString);


builder.Services.AddHealthChecks().AddCheck<DataProvidersHealthCheck>("data");

builder.Services.InitCustomServices(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler(new ExceptionHandlerOptions
{
	ExceptionHandler = new ExceptionMiddleware(app.Services.GetRequiredService<IHostEnvironment>(), app.Services.GetRequiredService<ILogger<ExceptionMiddleware>>()).Invoke
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.MigrateDatabase<AppDataContext>();

app.UseHttpsRedirection();

app.MapHealthChecks("/api/v1/ping", new HealthCheckOptions
{
	ResultStatusCodes =
	{
		[HealthStatus.Healthy] = StatusCodes.Status200OK,
		[HealthStatus.Unhealthy] = StatusCodes.Status500InternalServerError
	}
});

app.MapControllers();

app.Run();
