using ContaCorrente.Dominio.Transferencia.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContaCorrente.Dominio.Transferencia.Entidades
{
    public class Lancamento
    {
        public ContaCorrente ContaCorrente { get; set; }

        public bool EhEntrada { get; set; }

        public double Valor { get; set; }

        public DateTime Data { get; set; }
        
        public TipoOperacao TipoOperacao { get; set; }

        public ContaCorrente ContaCorrenteDestino { get; set; }
        public string Descricao { get; internal set; }
    }
}
