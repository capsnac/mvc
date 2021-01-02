using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPIApplicaiton.Controllers
{
    public class RegisterController : ApiController
    {
        private UserRepository ur;

        public RegisterController()
        {
            ur = new UserRepository();
        }

        [Route("api/AddUser")]
        [HttpPost]
        public ResponseModel AddUser(UserModel userData)
        {
            ResponseModel response = ur.AddUser(userData);
            return response;
        }

        [Route("api/GetCityList")]
        [HttpGet]
        public IHttpActionResult GetCityList()
        {
            var response = ur.GetCityList();
            return Json(response);
        }

        [Route("api/GetStateList")]
        [HttpGet]
        public IHttpActionResult GetStateList()
        {
            var response = ur.GetStateList();
            return Json(response);
        }

        [Route("api/GetCountryList")]
        [HttpGet]
        public IHttpActionResult GetCountryList()
        {
            var response = ur.GetCountryList();
            return Json(response);
        }

        [Route("api/CheckUserExist")]
        [HttpGet]
        public IHttpActionResult CheckUserExist(string email)
        {
            bool isExist = ur.CheckUserExist(email);
            return Json(isExist);
        }
    }
}
