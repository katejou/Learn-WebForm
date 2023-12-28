using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_ex1.Models
{
    public class ResponseModel<T>
    {
        public string Code { get; set; } = "0000";

        public string Message { get; set; } = "Success";

        // 泛型的進階應用！！
        // 就告訴你這個屬性不限型別！！
        // 但我在產生這個物件的時候，我才會把這個屬性型別定下來！！(見 class 旁邊的 T)
        public T Data { get; set; }
    }
}