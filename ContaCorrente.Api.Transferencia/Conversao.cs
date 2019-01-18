using System;
using System.Collections.Generic;
using System.Text;
using ContaCorrente.Api.Transferencia.ViewModels;
using ContaCorrente.Dominio.Transferencia;

namespace ContaCorrente.Api.Transferencia
{
    static class Conversao
    {
        public static Dominio.Transferencia.Entidades.ContaCorrente ParaEntidade(this ContaViewModel conta)
        {
            var ret = new Dominio.Transferencia.Entidades.ContaCorrente
            {
                Banco = conta.Banco,
                Agencia = conta.Agencia,
                Conta = conta.Conta
            };

            return ret;
        }
    }
}
