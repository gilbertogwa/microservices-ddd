using ContaCorrente.Api.Transferencia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaCorrente.Api.Transferencia.ViewModels
{
    public class TransferenciaViewModel
    {
        public ContaViewModel ContaOrigem { get; set; }

        public ContaViewModel ContaDestino { get; set; }

        public double Valor { get; set; }
    }
}
