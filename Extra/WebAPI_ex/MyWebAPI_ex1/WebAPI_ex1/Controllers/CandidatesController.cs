using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_ex1.Controllers
{
    public class CandidatesController : ApiController
    {
        Models.Candidate[] Candidates = new Models.Candidate[] {
            new Models.Candidate { Name="peter", Id="a000000000", Age=30, Email="peter@gmail.com" },
            new Models.Candidate { Name="justin", Id="a11111111", Age=28, Email="justin@gmail.com" },
            new Models.Candidate { Name="terry", Id="a222222222", Age=32, Email="terry@gmail.com" }
        };

        //取得所有應徵者的資料清單
        //(方法的名稱不重要，呼叫時都是用Controller前方的名字"Candidates"來叫
        //差別在收多少個參數(也就是後方有沒有斜線後的詞語))


        public IEnumerable<Models.Candidate> GetAllCandidates()
        {
            return Candidates;
        }

        //取得特定名稱應徵者的資料
        public IHttpActionResult GetCandidate(string Name)
        {
            var myCandidate = Candidates.FirstOrDefault((c) => c.Name == Name);
            if (myCandidate == null)
                return StatusCode(HttpStatusCode.NotFound);
            else
                return Ok(myCandidate);
        }

        // 有了上面的這個[]才可以被Post ? 
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string DATA)
        {
            // 只是可以看看，沒什麼意思
            //string controllerName = ControllerContext.RouteData.Values["controller"].ToString();

            JObject jo = JObject.Parse(DATA);

            Models.Candidate newCandidate = new Models.Candidate()
            {
                Name = jo["Name"].ToString(),
                Age = int.Parse(jo["Age"].ToString()),
                Id = jo["Id"].ToString(),
                Email = jo["Email"].ToString(),
            };

            // 回單結果的寫法︰
            return Request.CreateResponse(HttpStatusCode.OK, newCandidate); 
            // 回多結果的寫法︰
            //List<Models.Candidate> new_ca = new List<Models.Candidate> { newCandidate};
            //return Request.CreateResponse(HttpStatusCode.OK, new_ca);
        }

    }
}
