using System.Data.Entity;
using Accounting.Models;

namespace Accounting.Repository {
    public class UnitOfWork : IUnitOfWork {

        public DbContext Context { get; set; }

        public UnitOfWork() {
            Context = new AccountingEntities();
        }

        public void Save() {
            Context.SaveChanges();
        }

        public void Dispose() {
            Context.Dispose();
        }
    }
}