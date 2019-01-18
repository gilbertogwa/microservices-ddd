using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContaCorrente.Dominio.Transferencia.Entidades;

namespace ContaCorrente.Dominio.Transferencia.Infra.Data.Repositorios
{
    public class SaldoRepositorio : Interfaces.Repositorios.ISaldoRepositorio
    {
        
        public Task<double> Consulta(Entidades.ContaCorrente conta, DateTime data)
        {

            var random = new Random();

            return Task.FromResult(random.NextDouble() * 100.0);

        }

    }
}
