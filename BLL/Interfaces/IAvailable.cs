namespace BLL.Interfaces;

public interface IAvailable
{
	Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
}