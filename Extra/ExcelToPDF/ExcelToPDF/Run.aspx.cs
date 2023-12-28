using System;
using System.Drawing;
using System.IO;
using System.Web;
using Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Core;
using XlHAlign = Microsoft.Office.Interop.Excel.XlHAlign;

namespace ExcelToPDF
{
    public partial class Run : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 成功，但不是由 <直式> 的 Excel 「變成」 <橫式> 的 PDF
            // https://blog.yowko.com/excel-to-pdf/
            // 分頁 及 限範圍 的方法
            // https://weichiencoding.medium.com/c-vs2017-microsoft-office-interop-excel-%E7%94%A8%E6%B3%95-7a788e3d5b37
            // 改內容的方法
            // https://stackoverflow.com/questions/4811664/set-cell-value-using-excel-interop
            // https://stackoverflow.com/questions/47384634/unable-to-save-changes-to-excel-file-c
            // 如果遇上版權問題(雖然我們公司沒有這個問題)可以參考的解決方法(但是我實作出來有Error?)
            // https://ithelp.ithome.com.tw/articles/10229600

            // C# 開啟Excel，設定框線、字體對齊
            // https://a973624.pixnet.net/blog/post/191970853-c%23-%E9%96%8B%E5%95%9Fexcel%EF%BC%8C%E8%A8%AD%E5%AE%9A%E6%A1%86%E7%B7%9A%E3%80%81%E5%AD%97%E9%AB%94%E5%B0%8D%E9%BD%8A

        }

        protected void Btn1_Click(object sender, EventArgs e)
        {
            // Excel 檔案位置
            string sourcexlsx = HttpContext.Current.Server.MapPath("~/0503.xlsx");
            // PDF 儲存位置
            string targetpdf = HttpContext.Current.Server.MapPath("~/finish.pdf");
            //string targetpdf2 = HttpContext.Current.Server.MapPath("~/finish2.pdf");
            //建立 Excel application instance
            Application appExcel = new Application();
            

            //開啟 Excel 檔案
            var xlsxDocument = appExcel.Workbooks.Open(sourcexlsx);

            try
            {
                //分頁處理
                var Wsheet0 = xlsxDocument.Sheets[1];
                //var Wsheet1 = xlsxDocument.Sheets[2];
                
                //處理第一頁
                Wsheet0.Cells[11, 8] = "我自訂的內容";
                // 格字太小的時候，再要求他置中會剪去內容
                // 如果一定要置中要先 Wrap , 讓內容自動分行... (因為設好了欄寛不變，高變)
                Wsheet0.Cells[11, 8].WrapText = true;
                Wsheet0.Cells[11, 8].Style.VerticalAlignment = XlHAlign.xlHAlignCenter;
                Wsheet0.Cells[11, 8].Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // 邊框
                Range range1 = Wsheet0.Range[Wsheet0.Cells[1, 1], Wsheet0.Cells[4, 1]];
                AllBorders(range1.Borders);
                OutsideBorders(range1);

                // 字體和大小
                //range1.Font.Name = "標楷體";   //設定Excel資料字體字型
                range1.Font.Name = "Arial";
                range1.Font.Size = 15;        //設定Excel資料字體大小
                                
                Wsheet0.Cells[7, 1].Font.Bold = false;
                range1.Font.Bold = false;
                // 如果是轉化為 PDF 的話，
                // 我發現是所有字體都預設為粗體，除非特別說明不要粗體。


                //合併儲存格
                Wsheet0.Range[Wsheet0.Cells[14, 1], Wsheet0.Cells[17, 1]].Merge(Type.Missing);
                //文字上下左右置中 ( Range 的話，不要加 .Style 這個字 )
                Wsheet0.Range[Wsheet0.Cells[14, 1], Wsheet0.Cells[17, 1]].HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // 插入圖片
                Range oRange = (Range)Wsheet0.Cells[38, 5];
                float cellLeft = (float)((double)oRange.Left);
                float cellTop = (float)((double)oRange.Top);
                const float ImageSize = 90; // 正方形，長寛一樣
                string pic_path = Path.Combine(Server.MapPath("."), "pic1.jpg"); // 要完整路徑不能是相對路徑，所以只能這樣寫。
                Wsheet0.Shapes.AddPicture(pic_path, 0, 1, cellLeft, cellTop, ImageSize, ImageSize);
                
                // 自動調整行高，顯示儲存格過長內容 ( 不影響欄寛 )
                Wsheet0.Rows.AutoFit();


                // 列印範圍
                //Wsheet0 = Wsheet0.Range["A1: J100"];
                // 匯出 第一頁 PDF
                Wsheet0.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, targetpdf);
                // 匯出 第二頁 PDF
                //Wsheet1.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, targetpdf2);
                // 匯出<兩頁為一份>pdf
                //xlsxDocument.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, targetpdf);


            }
            catch (Exception ex)
            {
                string temp = ex.ToString();
            }
            finally
            {
                // 不要儲存我對Excel所作的變更
                xlsxDocument.Saved = true;
                //關閉 Excel 檔
                xlsxDocument.Close();
                //結束 Excel
                appExcel.Quit();
            }
        }

        /// <summary>
        /// 全部邊框(細)
        /// </summary>
        private void AllBorders(Borders _borders)
        {
            _borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            _borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            _borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            _borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            _borders.Color = Color.Black;
        }

        /// <summary>
        /// 外面邊框(粗)
        /// </summary>
        private void OutsideBorders(Range r)
        {
            r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium);
        }

    }
}