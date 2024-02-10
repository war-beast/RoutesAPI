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

		CreateMap<ProviderOneSearchResponse, SearchResponse>()
			.ForMember(d => d.MinPrice, opt => opt.MapFrom(s => GetMinPrice(s.Routes)))
			.ForMember(d => d.MaxPrice, opt => opt.MapFrom(s => GetMaxPrice(s.Routes)))
			.ForMember(d => d.MinMinutesRoute, opt => opt.MapFrom(s => GetFastestRoute(s.Routes)))
			.ForMember(d => d.MaxMinutesRoute, opt => opt.MapFrom(s => GetLongestRoute(s.Routes)));

		CreateMap<ProviderOneRoute, Route>()
			.ForMember(d => d.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
			.ForMember(d => d.Origin, opt => opt.MapFrom(s => s.From))
			.ForMember(d => d.Destination, opt => opt.MapFrom(s => s.To))
			.ForMember(d => d.OriginDateTime, opt => opt.MapFrom(s => s.DateFrom))
			.ForMember(d => d.DestinationDateTime, opt => opt.MapFrom(s => s.DateTo));
	}

	private static decimal GetMinPrice(IEnumerable<ProviderOneRoute> routes) => routes.MinBy(x => x.Price)?.Price ?? default;

	private static decimal GetMaxPrice(IEnumerable<ProviderOneRoute> routes) => routes.MaxBy(x => x.Price)?.Price ?? default;

	private static int GetFastestRoute(IEnumerable<ProviderOneRoute> routes)
	{
		return routes.Select(x => (x.DateTo - x.DateFrom).Minutes)
			.Min();
	}

	private static int GetLongestRoute(IEnumerable<ProviderOneRoute> routes)
	{
		return routes.Select(x => (x.DateTo - x.DateFrom).Minutes)
			.Max();
	}
}