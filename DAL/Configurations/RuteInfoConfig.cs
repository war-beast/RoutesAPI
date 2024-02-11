using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class RuteInfoConfig : IEntityTypeConfiguration<RouteInfo>
{
	public void Configure(EntityTypeBuilder<RouteInfo> builder)
	{
		builder.HasKey(x => x.Id);
	}
}