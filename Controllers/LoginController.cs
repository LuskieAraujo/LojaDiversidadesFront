using LojaDiversidadesFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaDiversidadesFront.Controllers;

public class LoginController : Controller
{
	private readonly ILogger<LoginController> _logger;

	public LoginController(ILogger<LoginController> logger)
	{
		_logger = logger;
	}

	public IActionResult Login() => View();

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}