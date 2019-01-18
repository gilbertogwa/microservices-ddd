using System;
using System.Collections.Generic;
using System.Text;

namespace ContaCorrente.Dominio.Transferencia.Interfaces
{
    public interface ITransferenciaService
    {
        void Transferir(Entidades.ContaCorrente contaOrigem, 
                        Entidades.ContaCorrente contaDestino, 
                        double valor);
    }
}
