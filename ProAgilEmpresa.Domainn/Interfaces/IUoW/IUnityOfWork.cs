using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.Domain.Interfaces.IUoW
{
    public interface IUnityOfWork
    {
        void Commit();
        void BeginTransaction();
        void RollBack();
        bool SaveChanges();
    }
}
