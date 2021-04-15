using GestaoContas.Domain.Entities;
using System;
using Xunit;

namespace GestaoContas.Domain.Tests.Contas
{
    public class ContaTests
    {
        [Fact(DisplayName = "Associar Conta")]
        [Trait("Categoria", "Conta - Associar Conta Para o Correntista")]
        public void Conta_AssociarContaAoCorrentista_ValidarDadosResult()
        {
            // Arrange
            var correntista = Correntista.CorrentistaFactory.NovoCorrentista(Guid.NewGuid());
            var conta = new Conta(Guid.NewGuid(), "Conta Para Depósitos", Status.ACTIVE, Tipo.DEPOSIT);

            // Act
            correntista.AdicionarConta(conta);

            // Assert
            Assert.Equal(correntista.CorrentistaId, conta.CorrentistaId);
        }
    }

    //TO-DO
    //Associar conta já existente para outro correntista deve retornar Exception
    //Associar conta mesmo tipo para mesmo correntista deve retornar Exception
    //Associar nova conta para o mesmo correntista deve validar tipo diferente ao já existente
    
}
