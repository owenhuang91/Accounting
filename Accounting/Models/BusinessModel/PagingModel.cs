using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounting.Models.BusinessModel {
    public class PagingModel<T> {

        /// <summary>
        /// 目前頁數
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 最後一夜
        /// </summary>
        public int LastPage{ get; set; }

        /// <summary>
        /// table要顯示的資料
        /// </summary>
        public List<T> Data { get; set; }
    }
}