using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class AppDataContext : DbContext, IContext
{
	public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
	{

	}

	public DbSet<RouteInfo> Routes { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.ApplyConfigurationsFromAssembly(typeof(AppDataContext).Assembly);
	}
}