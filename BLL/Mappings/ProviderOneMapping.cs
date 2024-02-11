using AutoMapper;
using BLL.Model;
using DAL.Model;

namespace BLL.Mappings;

public class ProviderOneMapping : Profile
{
	public ProviderOneMapping()
	{
		CreateMap<SearchRequest, ProviderOneSearchRequest>()
			.ForMember(d => d.DateFrom, opt => opt.MapFrom(s => s.OriginDateTime))
			.ForMember(d => d.To, opt => opt.MapFrom(s => s.Destination))
			.ForMember(d => d.From, opt => opt.MapFrom(s => s.Origin));

		CreateMap<ProviderOneRoute, Route>()
			.ForMember(d => d.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
			.ForMember(d => d.Origin, opt => opt.MapFrom(s => s.From))
			.ForMember(d => d.Destination, opt => opt.MapFrom(s => s.To))
			.ForMember(d => d.OriginDateTime, opt => opt.MapFrom(s => s.DateFrom))
			.ForMember(d => d.DestinationDateTime, opt => opt.MapFrom(s => s.DateTo));
	}
}