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
                var listDistributor = (from d in db.Distributors
                                       select new Distributors()
                                       {
                                           Id = d.DistributorID,
                                           DistributorName = d.DistributorName,
                                           DistributorAddress = d.DistributorAddress,
                                           DistributorEmail = d.DistributorEmail,
                                           DistributorPhone = d.DistributorPhone
                                       }).Where(s => s.Id == id).FirstOrDefault();

                if(listDistributor != null)
                {
                    return Json(listDistributor);
                }
                else
                {
                    return BadRequest("Distributor is not exists");
                }
            }
        }

        // POST
        [Route("api/Distributor")]
        [HttpPost]
        public IHttpActionResult CreateNewDistributor(Distributors d)
        {
            if(d.DistributorName == null)
            {
                return BadRequest("Distributor name is required fields.");
            }
            if (d.DistributorAddress == null)
            {
                return BadRequest("Distributor address is required fields.");
            }
            if (d.DistributorEmail == null)
            {
                return BadRequest("Distributor email is required fields.");
            }
            if (d.DistributorPhone == null)
            {
                return BadRequest("Distributor phone is required fields.");
            }

            var distributor = new Distributor();
            distributor.DistributorName = d.DistributorName;
            distributor.DistributorAddress = d.DistributorAddress;
            distributor.DistributorEmail = d.DistributorEmail;
            distributor.DistributorPhone = d.DistributorPhone;
            dbContext.Distributors.Add(distributor);
            dbContext.SaveChanges();
            return Ok("New Distributor has been created successful.");
        }

        // PUT
        [Route("api/Distributor/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateDistributor(int id, Distributors d)
        {
            using (var db = new UnilevelDbContext())
            {
                var editDistributor = db.Distributors.Where(s => s.DistributorID == id).FirstOrDefault();

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
                    return BadRequest("Distributor is not exists !!!");
                }
            }
            return Ok("Distributor has been updated successful.");
        }

        // DELETE
        [Route("api/Distributor")]
        [HttpDelete]
        public IHttpActionResult DeleteDistributor(int id)
        {                           
            using (var db = new UnilevelDbContext())
            {
                var deleteDistributor = db.Distributors.Where(s => s.DistributorID == id).FirstOrDefault();
                if (deleteDistributor != null)
                {
                    db.Distributors.Remove(deleteDistributor);
                    db.SaveChanges();
                }
                else
                {
                    return BadRequest("Not a valid distributor id");
                }
            }
            return Ok("Distributor has been deleted successful.");
        }
    }
}
