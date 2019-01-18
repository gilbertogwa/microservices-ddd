using System;
using System.Collections.Generic;
using System.Text;

namespace ContaCorrente.Dominio.Transferencia.Entidades
{
    public class ContaCorrente
    {
        public int Banco { get; set; }

        public int Agencia { get; set; }

        public int Conta { get; set; }

        public override bool Equals(object obj)
        {

            if (!(obj is ContaCorrente conta)) return false;

            return conta.Banco == Banco && 
                   conta.Agencia == conta.Agencia && 
                   conta.Conta == Conta;
        }
    }
}
