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
    public class AreaController : ApiController
    {
        UnilevelDbContext dbContext = new UnilevelDbContext();
        //GET
        [Route("api/Area")]
        [HttpGet]
        public IHttpActionResult GetAllArea()
        {
            using (var db = new UnilevelDbContext())
            {
                var listArea = (from a in db.Areas
                                //join c in db.Area_Details on a.AreaID equals c.AreaID
                                select new AreaDTO()
                                {
                                    Id = a.AreaID,
                                    AreaCode = a.AreaCode,
                                    AreaName = a.AreaName,
                                    //DistributorQty = c.DistributorQty
                                }).ToList();
                return Json(listArea);
            }
        }

        //GET
        [Route("api/Area/{id}")]
        [HttpGet]
        public IHttpActionResult GetAreaByID(int id)
        {
            using (var db = new UnilevelDbContext())
            {
                var listArea = (from a in db.Areas
                                //join c in db.Area_Details on a.AreaID equals c.AreaID
                                select new AreaDTO()
                                {
                                    Id = a.AreaID,
                                    AreaCode = a.AreaCode,
                                    AreaName = a.AreaName,
                                    //DistributorQty = c.DistributorQty
                                }).Where(a => a.Id == id).FirstOrDefault();
                if (listArea != null)
                {
                    return Json(listArea);
                }
                else
                {
                    return BadRequest("Area is not exists");
                }
            }
        }

        //POST
        [Route("api/Area")]
        [HttpPost]
        public IHttpActionResult Post(AreaDTO area)
        {
            var addArea = new Area();
            addArea.AreaCode = area.AreaCode;
            addArea.AreaName = area.AreaName;
            dbContext.Areas.Add(addArea);
            dbContext.SaveChanges();
            return Json(area);
        }

        // PUT
        [Route("api/Area/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, AreaDTO area)
        {
            using (var db = new UnilevelDbContext())
            {
                var editArea = db.Areas.Where(a => a.AreaID == id).FirstOrDefault();

                if (editArea != null)
                {
                    editArea.AreaCode = area.AreaCode;
                    editArea.AreaName = area.AreaName;
                    db.SaveChanges();
                }
                else
                {
                    return BadRequest("Area is not exists");
                }
            }
            return Ok();
        }

        // DELETE
        [Route("api/Area/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (var db = new UnilevelDbContext())
            {
                if(id <= 0)
                {
                    return BadRequest("Not a valid area id");
                }

                var deleteArea = db.Areas.Where(a => a.AreaID == id).FirstOrDefault();
                db.Areas.Remove(deleteArea);
            }
            return Ok();
        }
    }

    // Add user into area

    // Add distributor into area
}
