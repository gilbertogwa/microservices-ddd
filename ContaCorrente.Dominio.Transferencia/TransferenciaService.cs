using ContaCorrente.Dominio.Transferencia.ObjetosValor;
using ContaCorrente.Dominio.Transferencia.Interfaces.Repositorios;
using ContaCorrente.Dominio.Transferencia.Infra;
using ContaCorrente.Dominio.Transferencia.Interfaces;
using System;
using ContaCorrente.Dominio.Transferencia.Exceptions;

namespace ContaCorrente.Dominio.Transferencia
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ISaldoRepositorio _saldoRepositorio;

        private readonly ILancamentoRepositorio _lancamentoRepositorio;

        public TransferenciaService(ISaldoRepositorio saldoService, ILancamentoRepositorio lancamentoService)
        {
            _saldoRepositorio = saldoService;
            _lancamentoRepositorio = lancamentoService;
        }

        public void Transferir(Entidades.ContaCorrente contaOrigem, Entidades.ContaCorrente contaDestino, double valor)
        {

            var dataAtual = DateTime.UtcNow;

            var saldo = _saldoRepositorio.Consulta(contaOrigem, dataAtual).Result;

            try
            {
                Validar(saldo, valor);
            }
            catch (Exception)
            {
                throw;
            }


            var lancContaOrigem = Fabrica.Transferencia(dataAtual, contaOrigem, contaDestino, valor, true);
            var lancContaDestino = Fabrica.Credito(dataAtual, contaDestino, valor, $"Recebimento de {contaOrigem}");

            RegistroLancamento registro;

            try
            {
                registro = _lancamentoRepositorio.Registrar(lancContaOrigem).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Falhar ao registrar transferência.", ex);
            }

            try
            {
                _lancamentoRepositorio.Registrar(lancContaDestino, registro).Start();
            }
            catch (Exception ex)
            {
                _lancamentoRepositorio.Cancelar(registro);
                throw new Exception("Falhar ao registrar transferência para conta destino.", ex);
            }

        }

        private static void Validar(double saldo, double valor)
        {

            if (saldo < valor)
            {
                throw new SaldoInsuficienteException("A conta não possui saldo suficiente para transferência.");
            }
        }

    }
}
