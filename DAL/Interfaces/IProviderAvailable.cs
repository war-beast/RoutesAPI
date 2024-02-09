namespace DAL.Interfaces;

public interface IProviderAvailable
{
	Task<bool> IsAvailable();
}
