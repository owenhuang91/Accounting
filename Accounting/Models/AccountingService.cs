using System.Collections.Generic;
using System.Linq;
using Accounting.Models.BusinessModel;

namespace Accounting.Models {

    public class AccountingService {
        private AccountingEntities _db;

        public AccountingService() {
            _db = new AccountingEntities();
        }

        public IList<AccountingDetailModel> GetAllAccountingDetail() {
            return _db.AccountBook.OrderByDescending(m => m.Dateee)
               .Select(m => new AccountingDetailModel() {
                   Date = m.Dateee,
                   Price = m.Amounttt,
                   Type = ((CategoryEumn)m.Categoryyy).ToString(),
               }).ToList();
        }
    }
}