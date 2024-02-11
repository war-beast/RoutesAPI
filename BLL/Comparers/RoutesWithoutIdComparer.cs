using BLL.Model;

namespace BLL.Comparers
{
	internal class RoutesWithoutIdComparer : IEqualityComparer<Route>
	{
		public bool Equals(Route x, Route y)
		{
			if (ReferenceEquals(x, y)) return true;
			if (ReferenceEquals(x, null)) return false;
			if (ReferenceEquals(y, null)) return false;
			if (x.GetType() != y.GetType()) return false;
			return x.Origin == y.Origin && x.Destination == y.Destination && x.OriginDateTime.Equals(y.OriginDateTime) && x.DestinationDateTime.Equals(y.DestinationDateTime) && x.Price == y.Price && x.TimeLimit.Equals(y.TimeLimit);
		}

		public int GetHashCode(Route obj)
		{
			return HashCode.Combine(obj.Origin, obj.Destination, obj.OriginDateTime, obj.DestinationDateTime, obj.Price, obj.TimeLimit);
		}
	}
}
