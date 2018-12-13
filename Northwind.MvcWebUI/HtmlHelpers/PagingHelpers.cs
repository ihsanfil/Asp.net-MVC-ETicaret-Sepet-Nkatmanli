using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Northwind.MvcWebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        //MvcHtmlString dönüş türümüzdür
        //this HtmlHelper html neyi extension edeceksek onu yazdık
        //Sayfa bilgilerinede ihtiyacımız var kaç eleman var gibi oda PageningInfo'da bulunuyor
        public static MvcHtmlString Pager(this HtmlHelper html, PageingInfo pageingInfo)
        {
            //sayfa sayısı bulcaz: toplam eleman sayısı bölü her sayfada olacak eleman sayısı
            int totalPage = (int)Math.Ceiling((decimal)pageingInfo.TotalItems / pageingInfo.ItemsPerpage); //yuvarlama yaptık

            var stringBuilder =new StringBuilder(); //her birini bir araya getir
            for (int i = 1; i <= totalPage; i++)
            {
            var tagBuilder = new TagBuilder("a"); //a tag'ini oluştur dedik.
            tagBuilder.MergeAttribute("href",string.Format("/Product/Index/?page={0}&category={1}", i,pageingInfo.CurrentCategory));

            //her döndüğün link oluşturacak
            tagBuilder.InnerHtml = i.ToString(); //a tag'inin içindeki sayıyı verdik
                if (pageingInfo.CurrentPage==i)
                {
                    tagBuilder.AddCssClass("selected");
                }
                else
                {
                    tagBuilder.AddCssClass("btn");
                }
            stringBuilder.Append(tagBuilder); //hepsini bir araya getir
            }
           
            return MvcHtmlString.Create(stringBuilder.ToString());

        }
    }
}