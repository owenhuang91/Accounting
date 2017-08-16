using System;
using System.Data.Entity;

namespace Accounting.Repository {

    public interface IUnitOfWork : IDisposable {

        /// <summary>
        /// context
        /// </summary>
        DbContext Context { get; set; }

        /// <summary>
        /// save change
        /// </summary>
        void Save();
    }
}