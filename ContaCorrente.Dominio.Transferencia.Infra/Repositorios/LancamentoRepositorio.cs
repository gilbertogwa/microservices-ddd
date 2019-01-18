using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContaCorrente.Dominio.Transferencia.Entidades;
using ContaCorrente.Dominio.Transferencia.ObjetosValor;

namespace ContaCorrente.Dominio.Transferencia.Infra.Data.Repositorios
{
    public class LancamentoRepositorio : Interfaces.Repositorios.ILancamentoRepositorio
    {
        public void Cancelar(RegistroLancamento registro)
        {
            return;
        }

        public Task<RegistroLancamento> Registrar(Lancamento lancamentoContaDestino, RegistroLancamento dependencia = null)
        {
            var ret = new RegistroLancamento();

            return Task.FromResult(ret);
        }
    }
}
