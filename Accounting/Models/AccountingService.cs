using System;
using System.Collections.Generic;
using System.Linq;
using Accounting.Models.BusinessModel;

namespace Accounting.Models {

    public class AccountingService {
        private AccountingEntities _db;

        public AccountingService() {
            _db = new AccountingEntities();
        }

        public PagingModel<AccountingDetailModel> GetAllAccountingDetail(int page, int count) {

            var result = new PagingModel<AccountingDetailModel>() {
                Data = _db.AccountBook.OrderByDescending(m => m.Dateee)
                .Skip((page - 1) * count)
                .Take(count)
                .Select(m => new AccountingDetailModel() {
                    Date = m.Dateee,
                    Price = m.Amounttt,
                    Type = ((CategoryEumn)m.Categoryyy).ToString(),
                }).ToList(),
                CurrentPage = page,
                LastPage = Convert.ToInt32(Math.Ceiling(_db.AccountBook.Count() / (double)count)),
            };
            return result;
        }
    }
}