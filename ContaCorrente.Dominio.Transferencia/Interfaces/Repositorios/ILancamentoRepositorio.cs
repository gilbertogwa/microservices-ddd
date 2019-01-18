using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContaCorrente.Dominio.Transferencia.Entidades;
using ContaCorrente.Dominio.Transferencia.ObjetosValor;

namespace ContaCorrente.Dominio.Transferencia.Interfaces.Repositorios
{
    public interface ILancamentoRepositorio
    {

        Task<RegistroLancamento> Registrar(Lancamento lancamentoContaDestino, 
                                            RegistroLancamento dependencia = null);
        void Cancelar(RegistroLancamento registro);
    }
}
