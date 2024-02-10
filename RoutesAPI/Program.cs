using BLL.Mappings;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RoutesAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(CacheKeyMapping).Assembly);

builder.Services.AddHealthChecks();

builder.Services.InitCustomServices(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler(new ExceptionHandlerOptions
{
	ExceptionHandler = new ExceptionMiddleware(app.Services.GetRequiredService<IHostEnvironment>(), app.Services.GetRequiredService<ILogger>()).Invoke
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

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
