using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class AppDataContext : DbContext
{
	public DbSet<RouteInfo> Routes { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.ApplyConfigurationsFromAssembly(typeof(AppDataContext).Assembly);

		modelBuilder.Entity<RouteInfo>().HasData(
		{
			new RouteInfo { Destination = "Sochi", Price = 100.10m, Origin = "Moscow", OriginDateTime = DateTime.UtcNow.AddDays(1), DestinationDateTime = DateTime.UtcNow.AddMonths(1), Id = Guid.NewGuid(), TimeLimit = DateTime.UtcNow.AddMonths(1)};
			new RouteInfo { Destination = "Piter", Price = 50.00m, Origin = "Kirov", OriginDateTime = DateTime.UtcNow.AddDays(10), DestinationDateTime = DateTime.UtcNow.AddMonths(2), Id = Guid.NewGuid(), TimeLimit = DateTime.UtcNow.AddMonths(2) };
			new RouteInfo { Destination = "Ekat", Price = 100.10m, Origin = "Kazan", OriginDateTime = DateTime.UtcNow.AddDays(15), DestinationDateTime = DateTime.UtcNow.AddMonths(3), Id = Guid.NewGuid(), TimeLimit = DateTime.UtcNow.AddMonths(3) };
		}
	}
}