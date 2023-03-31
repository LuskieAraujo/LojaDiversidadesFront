using LojaDiversidadesFront.Models;
using LojaDiversidadesFront.Settings;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace LojaDiversidadesFront.Controllers;

public class LojaController : Controller
{
	public IActionResult Loja() => View(new List<Product>());
	public async Task<IActionResult> Produtos()
	{
		ViewData.Model = await ListarProdutos();
		return View(InternalRoutes.Estoque().ToString());
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

	public async Task<List<Product>> ListarProdutos()
	{
		try
		{
			using var client = new HttpClient();
			client.BaseAddress = new Uri(ExternalRoutes.RotaAPI());
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage getData = await client.GetAsync("produtos");

			return getData.IsSuccessStatusCode
				? JsonConvert.DeserializeObject<List<Product>>(getData.Content.ReadAsStringAsync().Result)
				: await new MockProduct().Products();

		}
		catch (Exception)
		{
			//return new List<Product>();
			return await new MockProduct().Products();
		}
	}

	public async Task<ActionResult> AdicionarProduto()
	{
		return View();
	}
}