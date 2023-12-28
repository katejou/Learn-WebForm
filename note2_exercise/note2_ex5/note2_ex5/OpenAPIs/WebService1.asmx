

<html>

    <head><link rel="alternate" type="text/xml" href="/WebService1.asmx?disco" />

    <style type="text/css">
    
		BODY { color: #000000; background-color: white; font-family: Verdana; margin-left: 0px; margin-top: 0px; }
		#content { margin-left: 30px; font-size: .70em; padding-bottom: 2em; }
		A:link { color: #336699; font-weight: bold; text-decoration: underline; }
		A:visited { color: #6699cc; font-weight: bold; text-decoration: underline; }
		A:active { color: #336699; font-weight: bold; text-decoration: underline; }
		A:hover { color: cc3300; font-weight: bold; text-decoration: underline; }
		P { color: #000000; margin-top: 0px; margin-bottom: 12px; font-family: Verdana; }
		pre { background-color: #e5e5cc; padding: 5px; font-family: Courier New; font-size: x-small; margin-top: -5px; border: 1px #f0f0e0 solid; }
		td { color: #000000; font-family: Verdana; font-size: .7em; }
		h2 { font-size: 1.5em; font-weight: bold; margin-top: 25px; margin-bottom: 10px; border-top: 1px solid #003366; margin-left: -15px; color: #003366; }
		h3 { font-size: 1.1em; color: #000000; margin-left: -15px; margin-top: 10px; margin-bottom: 10px; }
		ul { margin-top: 10px; margin-left: 20px; }
		ol { margin-top: 10px; margin-left: 20px; }
		li { margin-top: 10px; color: #000000; }
		font.value { color: darkblue; font: bold; }
		font.key { color: darkgreen; font: bold; }
		font.error { color: darkred; font: bold; }
		.heading1 { color: #ffffff; font-family: Tahoma; font-size: 26px; font-weight: normal; background-color: #003366; margin-top: 0px; margin-bottom: 0px; margin-left: -30px; padding-top: 10px; padding-bottom: 3px; padding-left: 15px; width: 105%; }
		.button { background-color: #dcdcdc; font-family: Verdana; font-size: 1em; border-top: #cccccc 1px solid; border-bottom: #666666 1px solid; border-left: #cccccc 1px solid; border-right: #666666 1px solid; }
		.frmheader { color: #000000; background: #dcdcdc; font-family: Verdana; font-size: .7em; font-weight: normal; border-bottom: 1px solid #dcdcdc; padding-top: 2px; padding-bottom: 2px; }
		.frmtext { font-family: Verdana; font-size: .7em; margin-top: 8px; margin-bottom: 0px; margin-left: 32px; }
		.frmInput { font-family: Verdana; font-size: 1em; }
		.intro { margin-left: -15px; }
           
    </style>

    <title>
	WebService1 Web 服務
</title></head>

  <body>

    <div id="content">

      <p class="heading1">WebService1</p><br>

      

      <span>

          <p class="intro">下列作業受支援。如需正式定義，請參閱<a href="WebService1.asmx?WSDL">服務描述</a>。 </p>
          
          
              <ul>
            
              <li>
                <a href="WebService1.asmx?op=HelloWorld">HelloWorld</a>
                
                
              </li>
              <p>
            
              </ul>
            
      </span>

      
      

    <span>
        
    </span>
    
      <span>
          <hr>
          <h3>此 Web 服務以 http://tempuri.org/ 作為預設的命名空間。</h3>
          <h3>建議事項: 請在公開 XML Web 服務之前變更預設的命名空間。</h3>
          <p class="intro">每個 XML Web 服務都需要一個唯一的命名空間供用戶端應用程式辨認，以便和 Web 上的其他服務有所區別。開發中的 XML Web 服務可以使用 http://tempuri.org/，但是已經發行的 XML Web Service 應使用更具永久性的命名空間。</p>
          <p class="intro">您的 XML Web 服務應該以您所控制的命名空間加以辨認。例如，您可以使用貴公司的網際網路網域名稱做為命名空間的一部分。雖然許多 XML Web 服務的命名空間看起來像是 URL，但它們不需要指向實際的 Web 資源 (XML Web 服務命名空間是 URI)。</p>
          <p class="intro">對於使用 ASP.NET 建立 XML Web Service，可使用 WebService 屬性的 Namespace 來改變預設的命名空間。WebService 屬性是一種套用在類別上的屬性，其中的類別包含 XML Web 服務的方法。以下是一段設定命名空間為 http://microsoft.com/webservices/ 的程式碼範例:</p>
          <p class="intro">C#</p>
          <pre>[WebService(Namespace="http://microsoft.com/webservices/")]
public class MyWebService {
    // 實作
}</pre>
          <p class="intro">Visual Basic</p>
          <pre>&lt;WebService(Namespace:="http://microsoft.com/webservices/")&gt; Public Class MyWebService
    ' 實作
End Class</pre>

          <p class="intro">C++</p>
          <pre>[WebService(Namespace="http://microsoft.com/webservices/")]
public ref class MyWebService {
    // 實作
};</pre>
          <p class="intro">如需 XML 命名空間的詳細資訊，請參閱 <a href="http://www.w3.org/TR/REC-xml-names/">XML 中的命名空間</A> (英文) 中的 W3C 建議事項。</p>
          <p class="intro">如需 WSDL 的詳細資訊，請參閱 <a href="http://www.w3.org/TR/wsdl">WSDL 規格</a> (英文)。</p>
          <p class="intro">如需 URI 的詳細資訊，請參閱 <a href="http://www.ietf.org/rfc/rfc2396.txt">RFC 2396</a> (英文)。</p>
      </span>

      

    
  </body>
</html>
