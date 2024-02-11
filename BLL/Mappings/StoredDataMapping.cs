using AutoMapper;
using BLL.Model;
using DAL.Entities;

namespace BLL.Mappings;

public class StoredDataMapping : Profile
{
	public StoredDataMapping()
	{
		CreateMap<RouteInfo, Route>().ReverseMap();
	}
}