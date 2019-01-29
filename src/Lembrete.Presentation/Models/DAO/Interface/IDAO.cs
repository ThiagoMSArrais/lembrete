using System;
using System.Collections.Generic;

namespace Lembrete.Presentation.Models.DAO.Interface
{
    public interface IDAO<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(Guid id);
    }
}