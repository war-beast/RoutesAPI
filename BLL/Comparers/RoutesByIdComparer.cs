using BLL.Model;

namespace BLL.Comparers;

public class RoutesByIdComparer : IEqualityComparer<Route>
{
	public bool Equals(Route x, Route y)
	{
		if (ReferenceEquals(x, y)) return true;
		if (ReferenceEquals(x, null)) return false;
		if (ReferenceEquals(y, null)) return false;
		return x.GetType() == y.GetType() && x.Id.Equals(y.Id);
	}

	public int GetHashCode(Route obj)
	{
		return obj.Id.GetHashCode();
	}
}