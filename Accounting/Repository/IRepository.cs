using System.Linq;

namespace Accounting.Repository {

    public interface IRepository<TEntity> where TEntity : class {

        /// <summary>
        /// unit of work
        /// </summary>
        IUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns>目的資料 (多筆)</returns>
        IQueryable<TEntity> Lookup();
    }
}