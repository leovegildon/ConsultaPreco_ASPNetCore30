using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaPreco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaPrecoController : ControllerBase
    {


        private readonly ILogger<ConsultaPrecoController> _logger;

        public ConsultaPrecoController(ILogger<ConsultaPrecoController> logger)
        {
            _logger = logger;
        }

        string Codigo;
        string Loja;
        Mercadoria mercadoria = new Mercadoria();
        void AdicionarDados(string loja, string codbarras)
        {

            Codigo = codbarras;
            Loja = loja;
        }

        [HttpGet("{loja}/{codbarras}")]
        public ActionResult<IEnumerable<Mercadoria>> GetMercadoria()
        {
            string loja = "loja";
            string codbarras = "codbarras";
            AdicionarDados(loja, codbarras);
            return new[]
            {
                new Mercadoria {CodSap = Codigo},
                new Mercadoria {Descricao = Loja}
            };
        }
    }
    public class Mercadoria
    {
        public string CodSap { get; set; }
        public string Descricao { get; set; }
        public string PrecoRegular { get; set; }
        public string PrecoMinhaLe { get; set; }

    }
}
