// Correct class name: JidelnickyController
using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;

public class JidelnickyController : Controller
{
	private readonly IJidelnicekService _jidelnicekService;

	public JidelnickyController(IJidelnicekService jidelnicekService)
	{
		_jidelnicekService = jidelnicekService ?? throw new ArgumentNullException(nameof(jidelnicekService));
	}

	public IActionResult Index(string searchTerm)
	{
		JidelnickyViewModel viewModel;

		if (string.IsNullOrEmpty(searchTerm))
		{
			viewModel = _jidelnicekService.GetAllJidelnicky();
		}
		else
		{
			viewModel = _jidelnicekService.SearchJidelnicky(searchTerm);
		}

		return View(viewModel);
	}
}
