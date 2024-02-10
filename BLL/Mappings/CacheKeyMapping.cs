using AutoMapper;
using BLL.Model;

namespace BLL.Mappings;

public class CacheKeyMapping : Profile
{
	public CacheKeyMapping()
	{
		CreateMap<SearchRequest, MemoryCacheKey>();
	}
}