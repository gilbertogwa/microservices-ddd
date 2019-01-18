using ContaCorrente.Dominio.Transferencia.Entidades;
using ContaCorrente.Dominio.Transferencia.Exceptions;
using ContaCorrente.Dominio.Transferencia.Interfaces.Repositorios;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ContaCorrente.Dominio.Transferencia.Testes
{
    public class TransferenciaTest
    {
        private Mock<ISaldoRepositorio> _saldoMock;
        private Mock<ILancamentoRepositorio> _lancMock;
        private Entidades.ContaCorrente _contaSemSaldo;
        private Entidades.ContaCorrente _contaComSaldo;

        public TransferenciaTest()
        {
            _saldoMock = new Mock<ISaldoRepositorio>();
            _lancMock = new Mock<ILancamentoRepositorio>();

            _contaSemSaldo = new Entidades.ContaCorrente()
            {
                 Banco = 1, Agencia = 1, Conta = 1
            };

            _contaComSaldo = new Entidades.ContaCorrente()
            {
                Banco = 2,
                Agencia = 2,
                Conta = 2
            };

            _saldoMock.Setup(a => a.Consulta(It.Is<Entidades.ContaCorrente>( c=> c == _contaSemSaldo), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(0.0));

            _saldoMock.Setup(a => a.Consulta(It.Is<Entidades.ContaCorrente>(c => c == _contaComSaldo), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(10000.0));

        }


        [Fact]
        public void Tranferencia_ContaOrigem_SemSaldo()
        {
            var service = new Transferencia.TransferenciaService(_saldoMock.Object, _lancMock.Object);
    
            var ex = Record.Exception(()=> service.Transferir(_contaSemSaldo, _contaComSaldo, 100));
 
            Assert.IsType<SaldoInsuficienteException>(ex);
        }

        [Fact]
        public void Tranferencia_ContaOrigem_ComSaldo()
        {
            var service = new Transferencia.TransferenciaService(_saldoMock.Object, _lancMock.Object);
        }

        private static Task<double> GerarSaldo()
        {
            var random = new Random();

            return Task.FromResult(random.NextDouble() * 100.0);
        }

    }
}
