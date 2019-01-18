using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaCorrente.Api.Transferencia.ViewModels
{
    public class ContaViewModel
    {
        public int Banco { get; set; }

        public int Agencia { get; set; }

        public int Conta { get; set; }
    }
}
