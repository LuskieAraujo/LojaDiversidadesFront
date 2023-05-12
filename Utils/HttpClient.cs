using LojaDiversidadesFront.Settings;
using System.Net.Http.Headers;
using System.Net.Http;

namespace LojaDiversidadesFront.Utils;

public class Client
{
	public static HttpClient ClientConstructor()
	{
		HttpClient client = new HttpClient
		{
			BaseAddress = new Uri(ExternalRoutes.RotaAPI())
		};
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		return client;
	}
}