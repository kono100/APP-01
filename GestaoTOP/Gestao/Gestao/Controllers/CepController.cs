using BuscaCEP.Service;
using Gestao.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuscaCEP.Controllers
{
    public class CepController : Controller
    {

        public readonly CorreiosService _correiosService;

        public CepController(CorreiosService correiosService)
        {
            _correiosService = correiosService;
        }
        [HttpPost]
        public async Task<IActionResult> BuscarEnderecoPorCep(string cep)
        {
            Visitante? visitante = await _correiosService.BuscarEnderecoPorCep(cep);
            if (visitante == null)
            {
                TempData["Mensagem"] = "CEP <strong> Não </strong> encontrado";
            }
            return View("Index", visitante);
        }
    }
}
