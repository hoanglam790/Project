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
            var listDistributor = (from d in dbContext.Distributors
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

        //GET
        [Route("api/Distributor/{id}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var listDistributor = (from d in dbContext.Distributors
                                   select new Distributors()
                                   {
                                       Id = d.DistributorID,
                                       DistributorName = d.DistributorName,
                                       DistributorAddress = d.DistributorAddress,
                                       DistributorEmail = d.DistributorEmail,
                                       DistributorPhone = d.DistributorPhone
                                   }).Where(s => s.Id == id).FirstOrDefault();

            if (listDistributor != null)
            {
                return Json(listDistributor);
            }
            else
            {
                return BadRequest("Distributor is not exist.");
            }
        }

        // POST
        [Route("api/Distributor")]
        [HttpPost]
        public IHttpActionResult CreateNewDistributor(DistributorDTO d)
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
            if(dbContext.Distributors.Any(n => n.DistributorEmail == d.DistributorEmail))
            {
                return BadRequest("Email already exist.");
            }
            if (dbContext.Distributors.Any(n => n.DistributorPhone == d.DistributorPhone))
            {
                return BadRequest("Phone number already exist.");
            }

            var distributor = new Distributor();
            distributor.DistributorName = d.DistributorName;
            distributor.DistributorAddress = d.DistributorAddress;
            distributor.DistributorEmail = d.DistributorEmail;
            distributor.DistributorPhone = d.DistributorPhone;
            distributor.AreaID = d.Area;
            dbContext.Distributors.Add(distributor);

            var ct_distributor = new Area_Distributors();
            ct_distributor.AreaID = (int)distributor.AreaID;
            ct_distributor.DistributorID = distributor.DistributorID;
            dbContext.Area_Distributors.Add(ct_distributor);

            dbContext.SaveChanges();
            return Ok("New Distributor has been created successful.");
        }

        // PUT
        [Route("api/Distributor/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateDistributor(int id, Distributors d)
        {
            var editDistributor = dbContext.Distributors.Where(s => s.DistributorID == id).FirstOrDefault();

            if (editDistributor != null)
            {
                editDistributor.DistributorName = d.DistributorName;
                editDistributor.DistributorAddress = d.DistributorAddress;
                editDistributor.DistributorEmail = d.DistributorEmail;
                editDistributor.DistributorPhone = d.DistributorPhone;
                dbContext.SaveChanges();
            }
            else
            {
                return BadRequest("Distributor is not exist !!!");
            }

            return Ok("Distributor has been updated successful.");
        }

        // DELETE
        [Route("api/Distributor")]
        [HttpDelete]
        public IHttpActionResult DeleteDistributor(int id)
        {
            var deleteDistributor = dbContext.Distributors.Where(s => s.DistributorID == id).FirstOrDefault();
            if (deleteDistributor != null)
            {
                dbContext.Distributors.Remove(deleteDistributor);
                dbContext.SaveChanges();
            }
            else
            {
                return BadRequest("Not a valid distributor id");
            }

            return Ok("Distributor has been deleted successful.");
        }
    }
}
