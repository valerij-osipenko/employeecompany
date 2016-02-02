using System;
using System.Text;
using System.Web.Mvc;

namespace EmployeeCompany.Helper {
    public static class PagingHelpers {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
        PageInfo pageInfo, Func<int, string> pageUrl ) {
            // определение границ навигации
            int startPage = pageInfo.PageNumber - 3 > 0 ? pageInfo.PageNumber - 2 : 1;
            int finishPage = pageInfo.PageNumber + 4 < pageInfo.TotalPages
                ? pageInfo.PageNumber + 4
                : pageInfo.TotalPages;

            var result = new StringBuilder();
            var resultLi = new StringBuilder();
            var tagUl = new TagBuilder("ul");
            tagUl.AddCssClass("pagination");

            // переход вначало
            var tagLi = new TagBuilder("li");
            if (pageInfo.PageNumber == 1) {
                tagLi.AddCssClass("disabled");
            }
            var tag = new TagBuilder("a");
            tag.MergeAttribute("href", pageUrl(1));
            tag.InnerHtml = "<<";
            tagLi.InnerHtml = tag.ToString();
            resultLi.Append(tagLi);
            for (var i = startPage; i <= finishPage; i++)
            {
                tagLi = new TagBuilder("li");
                // если текущая страница, то выделяем ее,
                if (i == pageInfo.PageNumber)
                {
                    tagLi.AddCssClass("active");
                }
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                tagLi.InnerHtml = tag.ToString();
                resultLi.Append(tagLi);
            }

            // переход в конец
            tagLi = new TagBuilder("li");
            if (pageInfo.PageNumber == pageInfo.TotalPages)
            {
                tagLi.AddCssClass("disabled");
            }
            tag = new TagBuilder("a");
            tag.MergeAttribute("href", pageUrl(pageInfo.TotalPages));
            tag.InnerHtml = ">>";
            tagLi.InnerHtml = tag.ToString();
            resultLi.Append(tagLi);
            tagUl.InnerHtml = resultLi.ToString();

            result.Append(tagUl);
            return MvcHtmlString.Create(result.ToString());
        }
    }
}