using System;
using System.Linq;
using Accounting.Models.ViewModels;
using Accounting.Repository;

namespace Accounting.Models
{

    public class AccountingService
    {
        private IRepository<AccountBook> _accountBookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountBookRepository = new GenericRepository<AccountBook>(_unitOfWork);
        }

        public IQueryable<AccountingDetailViewModel> GetAllAccountingDetail()
        {

            var result = _accountBookRepository.Lookup().OrderByDescending(m => m.Dateee).Select(m => new AccountingDetailViewModel()
            {
                Date = m.Dateee,
                Price = m.Amounttt,
                Category = (CategoryEumn)m.Categoryyy,
                Description = m.Remarkkk,
                id = m.Id,
            });
            return result;
        }

        public void CreateAccountingDetail(AccountingDetailViewModel createModel)
        {

            var accountBook = new AccountBook()
            {
                Id = Guid.NewGuid(),
                Amounttt = (int)createModel.Price,
                Categoryyy = (int)createModel.Category,
                Dateee = createModel.Date,
                Remarkkk = createModel.Description,
            };

            _accountBookRepository.Create(accountBook);

        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}