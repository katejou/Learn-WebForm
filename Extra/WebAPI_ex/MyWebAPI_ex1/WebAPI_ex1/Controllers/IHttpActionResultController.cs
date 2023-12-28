using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_ex1.Models;

namespace WebAPI_ex1.Controllers
{

    public class ihttpController : ApiController
    {
        // 這個是 CandidateController 的 Get 之中的做法，依賴來自 ApiController 的 Content() 和 Ok()
        [HttpGet]
        public IHttpActionResult Get(bool isError, string name, int age, string id, string email)
        {

            var responseModel = new ResponseModel<Candidate>();

            if (isError)
            {
                responseModel.Code = "0001";
                responseModel.Message = "你要我回傳的Error訊息";
                return Content(HttpStatusCode.BadRequest, responseModel);
            }

            responseModel.Data = new Candidate()
            {
                Name = name,
                Age = age,
                Id = id,
                Email = email
            };

            return Ok(responseModel);
        }
    }

}
