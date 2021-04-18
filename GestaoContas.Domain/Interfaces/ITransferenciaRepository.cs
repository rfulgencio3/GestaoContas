using GestaoContas.Domain.Entities;

namespace GestaoContas.Domain.Interfaces
{
    public interface ITransferenciaRepository
    {
        void Adicionar(Transferencia transferencia);
    }
}
