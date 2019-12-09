using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.Domain.Interfaces.IRepositories
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        int SaveChanges();

    }

}

