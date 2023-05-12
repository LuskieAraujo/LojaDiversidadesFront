using LojaDiversidadesFront.Models;
using LojaDiversidadesFront.Services;
using LojaDiversidadesFront.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaDiversidadesFront.Controllers;

[Route("produtos")]
public class LojaController : Controller
{
	private readonly ProdutoService produtoService = new();

	public IActionResult Loja() => View(new List<Product>());

	[HttpGet]
	public async Task<IActionResult> Produtos()
	{
		try
		{
			ViewData.Model = await produtoService.Listar();
			return View(InternalRoutes.Estoque().ToString());
		}
		catch (Exception)
		{
			return StatusCode(500);
		}
	}

	[HttpPost]
	public async Task<ActionResult> SalvarProduto(Product produto)
	{
		try
		{
			return View(produto.Id == 0 ? await produtoService.Incluir(produto) : await produtoService.Alterar(produto));
		}
		catch (Exception)
		{
			return StatusCode(500);
		}
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> ExcluirProduto(int id)
	{
		try
		{
			return id != 0 ? View(await produtoService.Excluir(id)) : View();
		}
		catch (Exception)
		{
			return StatusCode(500);
		}
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}