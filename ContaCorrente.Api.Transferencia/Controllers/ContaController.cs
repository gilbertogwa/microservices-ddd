using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaCorrente.Api.Transferencia.ViewModels;
using ContaCorrente.Dominio.Transferencia.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ContaCorrente.Dominio.Transferencia;

namespace ContaCorrente.Api.Transferencia.Controllers
{
    [Route("api/conta")]
    public class ContaController : Controller
    {
        private readonly ITransferenciaService _transferenciaService;

        public ContaController(ITransferenciaService transferenciaService)
        {
            _transferenciaService = transferenciaService;
        }

        [HttpPost("transferir")]
        public ActionResult Post([FromBody]TransferenciaViewModel transferencia)
        {

            var contaOrigem = transferencia.ContaOrigem?.ParaEntidade();
            var contaDestino = transferencia.ContaDestino?.ParaEntidade();

            _transferenciaService.Transferir(contaOrigem, contaDestino, transferencia.Valor);

            return Ok();

        }

    }
}
