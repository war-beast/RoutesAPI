using AutoMapper;
using BLL.Model;
using DAL.Model;

namespace BLL.Mappings;

public class ProviderTwoMapping : Profile
{
	public ProviderTwoMapping()
	{
		CreateMap<SearchRequest, ProviderTwoSearchRequest>()
			.ForMember(d => d.Arrival, opt => opt.MapFrom(s => s.Destination))
			.ForMember(d => d.Departure, opt => opt.MapFrom(s => s.Origin))
			.ForMember(d => d.DepartureDate, opt => opt.MapFrom(s => s.OriginDateTime))
			.ForMember(d => d.MinTimeLimit, opt => opt.MapFrom(s => s.Filters == null ? null : s.Filters.MinTimeLimit));

		CreateMap<ProviderTwoRoute, Route>()
			.ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
			.ForMember(d => d.Origin, opt => opt.MapFrom(s => s.Departure.Point))
			.ForMember(d => d.Destination, opt => opt.MapFrom(s => s.Arrival.Point))
			.ForMember(d => d.OriginDateTime, opt => opt.MapFrom(s => s.Departure.Date))
			.ForMember(d => d.DestinationDateTime, opt => opt.MapFrom(s => s.Arrival.Date))
			.ForMember(d => d.TimeLimit, opt => opt.MapFrom(s => s.TimeLimit));
	}
}