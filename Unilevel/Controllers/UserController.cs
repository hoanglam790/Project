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
    public class UserController : ApiController
    {
        // Get user
        [Route("api/Area/User/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserByID(int id)
        {
            using (var db = new UnilevelDbContext())
            {
                var listUser = (from u in db.Users
                                //join a in db.Areas on u.AreaID equals a.AreaID
                                select new UserDTO()
                                {
                                    UserId = u.UserID,
                                    Name = u.FullName,
                                    Email = u.Email,
                                    Role = u.Role.RoleName,
                                    Area = u.Area.AreaName,
                                    Status = u.Status
                                }).Where(a => a.UserId == id).FirstOrDefault();
                if (listUser != null)
                {
                    return Json(listUser);
                }
                else
                {
                    return BadRequest("User is not exists");
                }
            }
        }
    }
}
