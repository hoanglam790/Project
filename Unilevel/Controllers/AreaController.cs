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
            var listArea = (from a in dbContext.Areas
                            select new AreaDTO()
                            {
                                Id = a.AreaID,
                                AreaCode = a.AreaCode,
                                AreaName = a.AreaName,
                            }).ToList();
            return Json(listArea);
        }

        //GET
        [Route("api/Area/{id}")]
        [HttpGet]
        public IHttpActionResult GetAreaByID(int id)
        {
            var listArea = (from a in dbContext.Areas
                                //join c in db.Area_Details on a.AreaID equals c.AreaID
                            select new AreaDTO()
                            {
                                Id = a.AreaID,
                                AreaCode = a.AreaCode,
                                AreaName = a.AreaName,
                                //DistributorQty = c.DistributorID
                            }).Where(a => a.Id == id).FirstOrDefault();
            if (listArea != null)
            {
                return Json(listArea);
            }
            else
            {
                return BadRequest("Area is not exist.");
            }
        }

        //POST
        [Route("api/Area")]
        [HttpPost]
        public IHttpActionResult CreateNewArea(AreaDTO area)
        {
            if(area.AreaCode == null)
            {
                return BadRequest("Area code is required fields.");
            }
            if(area.AreaName == null)
            {
                return BadRequest("Area name is required fields.");
            }

            var addArea = new Area();
            addArea.AreaCode = area.AreaCode;
            addArea.AreaName = area.AreaName;
            dbContext.Areas.Add(addArea);
            dbContext.SaveChanges();
            return Ok("New Area has been created successful.");
        }

        // PUT
        [Route("api/Area/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateArea(int id, AreaDTO area)
        {
            var editArea = dbContext.Areas.Where(a => a.AreaID == id).FirstOrDefault();

            if (editArea != null)
            {
                editArea.AreaCode = area.AreaCode;
                editArea.AreaName = area.AreaName;
                dbContext.SaveChanges();
            }
            else
            {
                return BadRequest("Area is not exists !!!");
            }

            return Ok("Area has been updated successful.");
        }

        // DELETE
        [Route("api/Area/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteArea(int id)
        {
            using (var db = new UnilevelDbContext())
            {
                var deleteArea = db.Areas.Where(a => a.AreaID == id).FirstOrDefault();
                if (deleteArea != null)
                {
                    db.Areas.Remove(deleteArea);
                    db.SaveChanges();
                }
                else
                {
                    return BadRequest("Not a valid area id");
                }
            }

            return Ok("Area has been deleted successful.");
        }
    }
}
