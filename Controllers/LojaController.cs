using LojaDiversidadesFront.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace LojaDiversidadesFront.Controllers;

public class LojaController : Controller
{
	public IActionResult Loja() => View();
	public IActionResult Produtos() => View();

	string baseUrl = "https://localhost:7207";

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

	public async Task<ActionResult> Index()
	{
		var tab = new DataTable();
		
		try
		{
			using var client = new HttpClient();
			client.BaseAddress = new Uri(baseUrl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage getData = await client.GetAsync("Produtos");

			if(getData.IsSuccessStatusCode)
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
}