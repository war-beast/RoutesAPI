using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Interfaces
{
    public interface IContext
    {
	    DbSet<RouteInfo> Routes { get; set; }
	}
}