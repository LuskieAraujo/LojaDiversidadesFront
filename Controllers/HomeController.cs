using LojaDiversidadesFront.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace LojaDiversidadesFront.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		string baseUrl = "https://localhost:7207/api/";

		public async Task<IActionResult> Index()
		{
			var tab = new DataTable();

			try
			{
				using var client = new HttpClient();
				client.BaseAddress = new Uri(baseUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage getData = await client.GetAsync("Produtos");

				if (getData.IsSuccessStatusCode)
				{
					string retorno = getData.Content.ReadAsStringAsync().Result;
					tab = JsonConvert.DeserializeObject<DataTable>(retorno);
				}
				else
				{

				}
			}
			catch (Exception)
			{

			}
			return View();
		}
		public IActionResult Privacy() => View();

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}