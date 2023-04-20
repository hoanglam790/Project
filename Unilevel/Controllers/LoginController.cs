using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unilevel.Models;
using Unilevel.DTO;

namespace Unilevel.Controllers
{
    public class LoginController : ApiController
    {
        UnilevelDbContext dbContext = new UnilevelDbContext();

        //GET
        [Route("api/TaiKhoan")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var db = new UnilevelDbContext())
            {
                var dsTaiKhoan = (from tk in db.Accounts
                                  select new Login()
                                  {
                                      Id = tk.AccountID,
                                      UserName = tk.UserName,
                                      Password = tk.Password,
                                      DisplayName = tk.DisplayName
                                  }).ToList();
                return Json(dsTaiKhoan);
            }
        }
    }
}
