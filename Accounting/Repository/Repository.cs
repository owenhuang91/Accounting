using System.Data.Entity;
using System.Linq;

namespace Accounting.Repository {

    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class {
        public IUnitOfWork UnitOfWork { get; set; }

        private DbSet<TEntity> _Objectset;

        private DbSet<TEntity> ObjectSet {
            get {
                if (_Objectset == null) {
                    _Objectset = UnitOfWork.Context.Set<TEntity>();
                }
                return _Objectset;
            }
        }

        public GenericRepository(IUnitOfWork unitOfWork) {
            UnitOfWork = unitOfWork;
        }

        public IQueryable<TEntity> Lookup() {
            return ObjectSet;
        }

        public void Create(TEntity entity) {
            ObjectSet.Add(entity);
        }
    }
}