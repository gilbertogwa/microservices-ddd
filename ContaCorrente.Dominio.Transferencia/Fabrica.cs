using ContaCorrente.Dominio.Transferencia.Entidades;
using ContaCorrente.Dominio.Transferencia.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContaCorrente.Dominio.Transferencia.Infra
{
    class Fabrica
    {
        public static Lancamento Transferencia(DateTime data,
                                                Entidades.ContaCorrente contaOrigem,
                                                Entidades.ContaCorrente contaDestino, 
                                                double valor, bool ehContaOrigem)
        {

            var lancamento = new Lancamento()
            {
                ContaCorrente = contaOrigem,
                Data = data,
                EhEntrada = (ehContaOrigem == false),
                TipoOperacao = TipoOperacao.Transferencia,
                Valor = valor,
                ContaCorrenteDestino = contaDestino
            };

            return lancamento;
        }

        public static Lancamento Credito(DateTime data, Entidades.ContaCorrente conta, 
                                            double valor, string descricao)
        {
            var lancamento = new Lancamento()
            {
                ContaCorrente = conta,
                Data = data,
                EhEntrada = true,
                TipoOperacao = TipoOperacao.Credito,
                Valor = valor,
                Descricao = descricao 
            };

            return lancamento;
        }
    }
}
