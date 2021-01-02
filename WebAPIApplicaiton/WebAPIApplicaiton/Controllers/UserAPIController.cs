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
    [Authorize]
    public class UserAPIController : ApiController
    {
        private UserRepository ur;

        public UserAPIController()
        {
            ur = new UserRepository();
        }

        [Route("api/GetUserList")]
        [HttpGet]
        public ResponseModel GetUserList()
        {
            ResponseModel response = ur.GetUserList();
            return response;
        }

        [Route("api/UpdateUserStatus")]
        [HttpPost]
        public ResponseModel UpdateUserStatus(UserModel userData)
        {
            ResponseModel response = ur.UpdateUserStatus(userData);
            return response;
        }
    }
}
