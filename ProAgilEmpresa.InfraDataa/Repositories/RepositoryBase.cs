using Microsoft.EntityFrameworkCore;
using ProAgilEmpresa.Domain.Interfaces.IRepositories;
using ProAgilEmpresa.InfraData.Context;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProAgilEmpresa.InfraData.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : class
    {
        private  readonly ProAgilEmpresaContext Db;
        private DbSet<TEntity> DbSet;


        public RepositoryBase(ProAgilEmpresaContext Context)
        {
            Db = Context;
            DbSet = Db.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void Remover(TEntity obj)
        {
            DbSet.Remove(obj);
        }
       
        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterPorNome(string nome)
        {
            return DbSet.ToList();
        }

        public TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }
        
         public int SaveChanges()
        {
            return Db.SaveChanges();
        }
      
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
    

