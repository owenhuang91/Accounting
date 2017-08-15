using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Accounting.Extensions {

    public static class HtmlHelperExtension {

        public static MvcHtmlString Pagger(this HtmlHelper helper, int currentPage, int lastPage) {
            TagBuilder divBuilder = new TagBuilder("div");

            var pagger = GetPage(currentPage, lastPage);

            foreach (var item in pagger) {
                TagBuilder aBuilder = new TagBuilder("a");
                aBuilder.Attributes["href"] = "?page=" + item.Value;

                if (item.Key == currentPage.ToString()) {
                    aBuilder.Attributes["style"] = "background-color: yellow";
                }

                aBuilder.InnerHtml = $"  {item.Key}  ";
                divBuilder.InnerHtml += aBuilder;
            }

            return MvcHtmlString.Create(divBuilder.ToString());
        }

        private static Dictionary<string, int> GetPage(int currentPage, int lastPage) {
            var result = new Dictionary<string, int>();
            var tempResult = new Dictionary<string, int>() { [currentPage.ToString()] = currentPage };

            //設定最大頁數
            int maxPage = 10;

            //若總頁數不到最大頁數，直接回傳總頁數
            if (lastPage <= maxPage) {
                return Enumerable.Range(1, lastPage).ToDictionary(m => m.ToString(), m => m);
            }

            //以目前的頁數為中心，輪流加1與減1
            //但若已經到第一筆或是最後一筆，接下來就只往相反的另一邊加
            int max = currentPage;
            int min = currentPage;
            for (int i = 0; i < maxPage - 1; i++) {
                if (i % 2 == 0) {
                    if (max != lastPage) {
                        max++;
                        tempResult.Add(max.ToString(), max);
                    } else {
                        min--;
                        tempResult.Add(min.ToString(), min);
                    }
                } else {
                    if (min != 1) {
                        min--;
                        tempResult.Add(min.ToString(), min);
                    } else {
                        max++;
                        tempResult.Add(max.ToString(), max);
                    }
                }
            }
            tempResult = tempResult.OrderBy(m => m.Value).ToDictionary(m => m.Key, m => m.Value);

            //加上 << <
            if (tempResult.Min(m => m.Value) != 1) {
                result.Add("<<", 1);
                result.Add("<", currentPage - 1);
            }

            foreach (var item in tempResult) {
                result.Add(item.Key, item.Value);
            }

            //加上 > >>
            if (tempResult.Max(m => m.Value) != lastPage) {
                result.Add(">", currentPage + 1);
                result.Add(">>", lastPage);
            }

            return result;
        }
    }
}