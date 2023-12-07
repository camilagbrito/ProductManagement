using App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Errors(int id) {

            var modelError = new ErrorViewModel();

            if(id == 500) {
                modelError.Message = "Ocorreu um erro! Tente novamente mais tarde ou contate o suporte.";
                modelError.Title = "Ocorreu um erro!";
                modelError.ErrorCode = id;
            }

            else if(id == 404)
            {
                modelError.Message = "A página que você está procurando não existe! </br> Em caso de dúvidas entre em contatocom o suporte.";
                modelError.Title = "Ops! Página não encontrada.";
                modelError.ErrorCode = id;

            }
            else if (id == 403)
            {
                modelError.Message = "Você não tem permissão para fazer isto.";
                modelError.Title = "Acesso Nagado.";
                modelError.ErrorCode = id;

            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelError);
        }
    }
}