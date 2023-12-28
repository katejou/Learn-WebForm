<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EX9_6.aspx.cs" Inherits="ASP.NET_EX9._2_.EX9_6" %>
<br/>
這裡的內容，不和 EX9_7 一般，會後綴在 HtmlPage1_EX9_6 的 div_result 之中，我也不知道為什麼。
<br/>
因為搞不清楚，所以不用為好，如果要 append 什麼的話，就到 HtmlPage1_EX9_6 的方法之中去寫吧，這裡不要放什麼東西了。
<br/>
會不會是因為 PageLoad 的 Response.End() 呢？;
<br/>
測試的結果是正確的
<br/>
不過，這堆不是 JSON 格式無法轉化的內容， 會讓之後的方法無法執行，所以我把  Response.End() 放回去。
<br/>
總之這一個版面的文字，是會 append 到 Response.Write( XXX)  之後的內容。
