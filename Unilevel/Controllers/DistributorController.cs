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
    public class DistributorController : ApiController
    {
        UnilevelDbContext dbContext = new UnilevelDbContext();

        //GET
        [Route("api/Distributor")]
        [HttpGet]
        public IHttpActionResult GetAllDistributor()
        {
            using (var db = new UnilevelDbContext())
            {
                var listDistributor = (from d in db.Distributors
                                  select new Distributors()
                                  {
                                      Id = d.DistributorID,
                                      DistributorName = d.DistributorName,
                                      DistributorAddress = d.DistributorAddress,
                                      DistributorEmail = d.DistributorEmail,
                                      DistributorPhone = d.DistributorPhone
                                  }).ToList();
                return Json(listDistributor);
            }
        }

        //GET
        [Route("api/Distributor/{id}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            using (var db = new UnilevelDbContext())
            {
                var distributor = db.Distributors
                    .Where(s => s.DistributorID == id)
                    .SingleOrDefault();

                if(distributor != null)
                {
                    return Json(distributor);
                }
                else
                {
                   return NotFound();
                }
            }
        }

        // POST
        [Route("api/Distributor")]
        [HttpPost]
        public IHttpActionResult Post(Distributors d)
        {
            var distributor = new Distributor();
            distributor.DistributorName = d.DistributorName;
            distributor.DistributorAddress = d.DistributorAddress;
            distributor.DistributorEmail = d.DistributorEmail;
            distributor.DistributorPhone = d.DistributorPhone;
            dbContext.Distributors.Add(distributor);
            dbContext.SaveChanges();
            return Json(d);
        }

        // PUT
        [Route("api/Distributor")]
        [HttpPut]
        public IHttpActionResult Put(Distributors d)
        {
            using (var db = new UnilevelDbContext())
            {
                var editDistributor = db.Distributors
                    .Where(s => s.DistributorID == d.Id)
                    .FirstOrDefault();

                if (editDistributor != null)
                {
                    editDistributor.DistributorName = d.DistributorName;
                    editDistributor.DistributorAddress = d.DistributorAddress;
                    editDistributor.DistributorEmail = d.DistributorEmail;
                    editDistributor.DistributorPhone = d.DistributorPhone;
                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Json(d);
        }

        // DELETE
        [Route("api/Distributor")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid service id");

            using (var db = new UnilevelDbContext())
            {
                var deleteDistributor = db.Distributors
                    .Where(s => s.DistributorID == id)
                    .FirstOrDefault();

                db.Distributors.Remove(deleteDistributor);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
