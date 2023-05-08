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
    public class RoleController : ApiController
    {
        UnilevelDbContext dbContext = new UnilevelDbContext();

        //GET
        [Route("api/Role")]
        [HttpGet]
        public IHttpActionResult GetAllRole()
        {
            using (var db = new UnilevelDbContext())
            {
                var listRole = (from r in db.Roles
                                select new Roles()
                                {
                                   RoleID = r.RoleID,
                                   RoleName = r.RoleName
                                }).ToList();
                return Json(listRole);
            }
        }

        //GET by ID
        [Route("api/Role/{id}")]
        [HttpGet]
        public IHttpActionResult GetRoleByID(int id)
        {
            using (var db = new UnilevelDbContext())
            {
                var listRole = (from r in db.Roles
                                select new Roles()
                                {
                                    RoleID = r.RoleID,
                                    RoleName = r.RoleName
                                }).Where(r => r.RoleID == id).FirstOrDefault();
                
                if(listRole != null)
                {
                    return Json(listRole);
                }
                else
                {
                    return BadRequest("Role is not exists");
                }
            }
        }

        // POST
        [Route("api/Role")]
        [HttpPost]
        public IHttpActionResult Post(Roles r)
        {
            var role = new Role();
            role.RoleName = r.RoleName;
            dbContext.Roles.Add(role);
            dbContext.SaveChanges();
            return Json(r);
        }

        // PUT
        [Route("api/Role/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, Roles role)
        {
            using (var db = new UnilevelDbContext())
            {
                var editRole = db.Roles.Where(r => r.RoleID == id).FirstOrDefault();

                if (editRole != null)
                {
                    editRole.RoleName = role.RoleName;
                    db.SaveChanges();
                }
                else
                {
                    return BadRequest("Role is not exists");
                }
            }
            return Ok();
        }

        // DELETE
        [Route("api/Role/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid role id");
            }
            using (var db = new UnilevelDbContext())
            {
                var deleteRole = db.Roles.Where(s => s.RoleID == id).FirstOrDefault();
                db.Roles.Remove(deleteRole);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
