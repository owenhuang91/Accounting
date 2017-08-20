using System;
using System.Linq;
using Accounting.Models.ViewModels;
using Accounting.Repository;

namespace Accounting.Models {

    public class AccountingService {
        private IRepository<AccountBook> _accountBookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountingService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _accountBookRepository = new GenericRepository<AccountBook>(_unitOfWork);
        }

        public IQueryable<AccountingDetailViewModel> GetAllAccountingDetail() {

            var result = _accountBookRepository.Lookup().OrderByDescending(m=>m.Dateee).Select(m=>new AccountingDetailViewModel() {
                Date = m.Dateee,
                Price = m.Amounttt,
                Type = ((CategoryEumn)m.Categoryyy).ToString(),
            });
            return result;
        }

        public void Save() {
            _unitOfWork.Save();
        }
    }
}