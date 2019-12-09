using ProAgilEmpresa.Domain.Interfaces.IUoW;
using ProAgilEmpresa.InfraData.Context;

namespace ProAgilEmpresa.InfraData.UoW
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ProAgilEmpresaContext _context;

        public UnityOfWork(ProAgilEmpresaContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void RollBack()
        {
            _context.Database.CurrentTransaction.Rollback();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
