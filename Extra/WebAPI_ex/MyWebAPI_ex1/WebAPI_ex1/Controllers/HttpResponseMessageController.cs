using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_ex1.Models;

namespace WebAPI_ex1.Controllers
{
    public class httpRespController : ApiController
    {

        // 這個回傳，用 Request.CreateResponse() 和 HttpResponseException() 的方法
        // HttpResponseException 的好處是不易被攔載，而且帶有自定的HttpStatusCode內容
        [HttpGet]
        public HttpResponseMessage Get(bool isError, string name, int age, string id, string email)
        {
            var responseModel = new ResponseModel<Candidate>();

            if (isError)
            {
                responseModel.Code = "0001";
                responseModel.Message = "你要我回傳的Error訊息";
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, responseModel);
                throw new HttpResponseException(response);
            }

            responseModel.Data = new Candidate()
            {
                Name = name,
                Age = age,
                Id = id,
                Email = email
            };

            return Request.CreateResponse(HttpStatusCode.OK, responseModel);
        }


    }
}
