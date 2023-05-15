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
    public class PlanController : ApiController
    {
        UnilevelDbContext dbContext = new UnilevelDbContext();

        //GET
        [Route("api/Plan")]
        [HttpGet]
        public IHttpActionResult GetAllPlan()
        {
            var listPlan = (from p in dbContext.Plans
                            select new PlanDetail()
                            {
                                PlanID = p.PlanID,
                                Calendar = p.Calendar,
                                TimeName = p.Time.Name,
                                DistributorName = p.Distributor.DistributorName,
                                Purpose = p.PurposeVisit,
                                Guest = p.Guest
                            }).ToList();
            return Json(listPlan);
        }

        //GET
        [Route("api/Plan/{id}")]
        [HttpGet]
        public IHttpActionResult GetPlanByID(int id)
        {
            var listPlan = (from p in dbContext.Plans
                            select new PlanDetail()
                            {
                                PlanID = p.PlanID,
                                Calendar = p.Calendar,
                                TimeName = p.Time.Name,
                                DistributorName = p.Distributor.DistributorName,
                                Purpose = p.PurposeVisit,
                                Guest = p.Guest
                            }).Where(n => n.PlanID == id).FirstOrDefault();

            if (listPlan != null)
            {
                return Json(listPlan);
            }
            else
            {
                return BadRequest("Plan is not exist.");
            }
        }

        //POST
        [Route("api/Plan")]
        [HttpPost]
        public IHttpActionResult CreateNewPlan(PlanDTO plan)
        {
            if (plan.Purpose == null)
            {
                return BadRequest("Purpose of the visit is required fields.");
            }

            if (plan.Guest == null)
            {
                return BadRequest("Guest is required fields.");
            }
            var addPlan = new Plan();
            addPlan.Calendar = plan.Calendar;
            addPlan.TimeID = plan.Time;
            addPlan.DistributorID = plan.Distributor;
            addPlan.PurposeVisit = plan.Purpose;
            addPlan.Guest = plan.Guest;
            addPlan.Status = 0;
            dbContext.Plans.Add(addPlan);
            dbContext.SaveChanges();
            return Ok("New plan has been created successful.");
        }

        //PUT
        [Route("api/Plan/{id}")]
        [HttpPut]
        public IHttpActionResult UpdatePlan(int id, PlanDTO plan)
        {
            var updatePlan = dbContext.Plans.Where(n => n.PlanID == id).FirstOrDefault();
            if(updatePlan != null)
            {
                updatePlan.Calendar = plan.Calendar;
                updatePlan.TimeID = plan.Time;
                updatePlan.DistributorID = plan.Distributor;
                updatePlan.PurposeVisit = plan.Purpose;
                updatePlan.Guest = plan.Guest;
                updatePlan.Status = plan.Status;
                dbContext.SaveChanges();              
            }
            else
            {
                return BadRequest("Plan is not exists !!!");
            }
            return Ok("Plan has been updated successful.");
        }
    }
}
