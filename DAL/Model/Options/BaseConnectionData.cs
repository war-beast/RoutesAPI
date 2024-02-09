namespace DAL.Model.Options;

public abstract class BaseConnectionData
{
	/// <summary>
	/// Базовый адрес провайдера
	/// </summary>
	public string BaseUrl { get; set; }

	/// <summary>
	/// Эндпоинт проверки работоспособности
	/// </summary>
	public string PingEndpoint { get; set; }

	/// <summary>
	/// Эндоинт получения данных
	/// </summary>
	public string SearchEndpoint { get; set; }
}
