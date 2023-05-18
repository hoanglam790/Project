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
    public class SurveyController : ApiController
    {
        UnilevelDbContext dbContext = new UnilevelDbContext();

        // Get all survey
        [Route("api/Survey")]
        [HttpGet]
        public IHttpActionResult GetAllSurvey()
        {
            var listSurvey = (from s in dbContext.Surveys
                            select new Surveys()
                            {
                                Id = s.SurveyID,
                                Title = s.Title,
                                CreatedAt = s.CreatedAt
                            }).ToList();
            return Json(listSurvey);
        }

        // Get survey question
        [Route("api/Survey-Questionnaire")]
        [HttpGet]
        public IHttpActionResult GetAllSurveyQuestion()
        {
            var listSurveyQuestion = 
                (from s in dbContext.Surveys
                 join c in dbContext.Survey_Details on s.SurveyID equals c.SurveyID
                select new Survey_Questionnaire()
                {
                   SurveyId = s.SurveyID,
                   Title = s.Title,
                   Question = c.Question,
                   Answer_A = c.A,
                   Answer_B = c.B,
                   Answer_C = c.C,
                   Answer_D = c.D,
                   StartDate = (DateTime)c.StartDate,
                   EndDate = (DateTime)c.EndDate,
                }).ToList();
            return Json(listSurveyQuestion);
        }

        // Create a new survey question
        [Route("api/Survey-Questionnaire")]
        [HttpPost]
        public IHttpActionResult CreateSurveyQuestion(Surveys survey)
        {
            if (dbContext.Surveys.Any(s => s.SurveyID == survey.Id))
            {
                return BadRequest("This survey id already exist.");
            }
            if (survey.Title == null)
            {
                return BadRequest("Title is required fields.");
            }

            var newSurvey = new Survey();
            newSurvey.Title = survey.Title;
            newSurvey.CreatedAt = DateTime.Now;
            dbContext.Surveys.Add(newSurvey);
            dbContext.SaveChanges();
            return Ok("Survey question has been created successful.");
        }

        // Create a new survey question
        [Route("api/Survey-Question-Detail")]
        [HttpPost]
        public IHttpActionResult CreateSurveyQuestionDetail(Survey_Question_Details survey)
        {
            if (dbContext.Survey_Details.Any(s => s.Question == survey.Question))
            {
                return BadRequest("This question already exist.");
            }
            if (survey.Question == null)
            {
                return BadRequest("Question is required fields.");
            }
            if (survey.Answer_A == null)
            {
                return BadRequest("Answer A is required fields.");
            }
            if (survey.Answer_B == null)
            {
                return BadRequest("Answer B is required fields.");
            }
            if (survey.Answer_C == null)
            {
                return BadRequest("Answer C is required fields.");
            }
            if (survey.Answer_D == null)
            {
                return BadRequest("Answer D is required fields.");
            }

            var survey_question = new Survey_Details();            
            survey_question.Question = survey.Question;
            survey_question.A = survey.Answer_A;
            survey_question.B = survey.Answer_B;
            survey_question.C = survey.Answer_C;
            survey_question.D = survey.Answer_D;
            survey_question.Result = survey.Result;
            survey_question.StartDate = DateTime.Now;
            survey_question.EndDate = survey.EndDate;
            survey_question.SurveyID = survey.SurveyId;
            survey_question.UserID = survey.Creator;
            dbContext.Survey_Details.Add(survey_question);
            dbContext.SaveChanges();
            return Ok("Survey question detail has been created successful.");
        }
    }
}
