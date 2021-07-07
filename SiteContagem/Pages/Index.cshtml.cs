using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SiteContagem.Logging;

namespace SiteContagem.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly Contador _CONTADOR = new();

        public void OnGet([FromServices] ILogger<IndexModel> logger,
            [FromServices] IConfiguration configuration)
        {
            int valorAtual;
            lock (_CONTADOR)
            {
                _CONTADOR.Incrementar();
                valorAtual = _CONTADOR.ValorAtual;
            }

            logger.LogValorAtual(valorAtual);

            TempData["Contador"] = valorAtual;
            TempData["Local"] = _CONTADOR.Local;
            TempData["Kernel"] = _CONTADOR.Kernel;
            TempData["TargetFramework"] = _CONTADOR.TargetFramework;
            TempData["MensagemFixa"] = "Teste";
            TempData["MensagemVariavel"] = configuration["MensagemVariavel"];
        }
    }
}