using System;
using System.Linq;
using Accounting.Models.BusinessModel;
using Accounting.Repository;

namespace Accounting.Models {

    public class AccountingService {
        private IRepository<AccountBook> _accountBookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountingService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _accountBookRepository = new GenericRepository<AccountBook>(_unitOfWork);
        }

        public PagingModel<AccountingDetailModel> GetAllAccountingDetail(int page, int count) {

            var result = new PagingModel<AccountingDetailModel>() {
                Data = _accountBookRepository.GetAll().OrderByDescending(m => m.Dateee)
                .Skip((page - 1) * count).Take(count)
                .Select(m => new AccountingDetailModel() {
                    Date = m.Dateee,
                    Price = m.Amounttt,
                    Type = ((CategoryEumn)m.Categoryyy).ToString(),
                }).ToList(),
                CurrentPage = page,
                LastPage = Convert.ToInt32(Math.Ceiling(_accountBookRepository.GetAll().Count() / (double)count)),
            };
            return result;
        }

        public void Save() {
            _unitOfWork.Save();
        }
    }
}