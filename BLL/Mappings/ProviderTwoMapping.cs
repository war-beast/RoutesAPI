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

		CreateMap<ProviderTwoSearchResponse, SearchResponse>()
			.ForMember(d => d.MinPrice, opt => opt.MapFrom(s => GetMinPrice(s.Routes)))
			.ForMember(d => d.MaxPrice, opt => opt.MapFrom(s => GetMaxPrice(s.Routes)))
			.ForMember(d => d.MinMinutesRoute, opt => opt.MapFrom(s => GetFastestRoute(s.Routes)))
			.ForMember(d => d.MaxMinutesRoute, opt => opt.MapFrom(s => GetLongestRoute(s.Routes)));

		CreateMap<ProviderTwoRoute, Route>()
			.ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
			.ForMember(d => d.Origin, opt => opt.MapFrom(s => s.Departure.Point))
			.ForMember(d => d.Destination, opt => opt.MapFrom(s => s.Arrival.Point))
			.ForMember(d => d.OriginDateTime, opt => opt.MapFrom(s => s.Departure.Date))
			.ForMember(d => d.DestinationDateTime, opt => opt.MapFrom(s => s.Arrival.Date))
			.ForMember(d => d.TimeLimit, opt => opt.MapFrom(s => s.TimeLimit));
	}

	private static decimal GetMinPrice(IEnumerable<ProviderTwoRoute> routes) => routes.Min(x => x.Price);

	private static decimal GetMaxPrice(IEnumerable<ProviderTwoRoute> routes) => routes.Max(x => x.Price);

	private static int GetFastestRoute(IEnumerable<ProviderTwoRoute> routes) => routes.Select(x => (x.Arrival.Date - x.Departure.Date).Minutes)
		.Min();

	private static int GetLongestRoute(IEnumerable<ProviderTwoRoute> routes) => routes.Select(x => (x.Arrival.Date - x.Departure.Date).Minutes)
		.Max();
}