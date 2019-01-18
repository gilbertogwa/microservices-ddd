using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContaCorrente.Dominio.Transferencia.Entidades;

namespace ContaCorrente.Dominio.Transferencia.Interfaces.Repositorios
{
    public interface ISaldoRepositorio
    {
        Task<double> Consulta(Entidades.ContaCorrente conta, DateTime data);
    }
}
