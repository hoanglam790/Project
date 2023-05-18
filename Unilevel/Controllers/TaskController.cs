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
    public class TaskController : ApiController
    {
        UnilevelDbContext dbContext = new UnilevelDbContext();

        //GET
        [Route("api/Task")]
        [HttpGet]
        public IHttpActionResult GetAllTask()
        {
            var listTask = (from t in dbContext.Tasks
                            join c in dbContext.Task_Details on t.TaskID equals c.TaskID
                            select new Tasks()
                            {
                                Id = t.TaskID,
                                TaskTitle = t.Title,
                                TaskDescription = t.Description,
                                User = c.User.FullName,
                                TaskStartDate = t.StartDate,
                                TaskStartEnd = t.StartEnd,
                                CreatedAt = t.CreatedAt,
                                Rating = c.Rating,
                                Comment = c.Comment
                            }).ToList();
            return Json(listTask);
        }

        //GET task by id
        [Route("api/Task/{id}")]
        [HttpGet]
        public IHttpActionResult GetTaskByID(int id)
        {
            var listTask = (from t in dbContext.Tasks
                            join c in dbContext.Task_Details on t.TaskID equals c.TaskID
                            select new Tasks()
                            {
                                Id = t.TaskID,
                                TaskTitle = t.Title,
                                TaskDescription = t.Description,
                                User = c.User.FullName,
                                TaskStartDate = t.StartDate,
                                TaskStartEnd = t.StartEnd,
                                CreatedAt = t.CreatedAt,
                                Rating = c.Rating,
                                Comment = c.Comment
                            }).Where(n => n.Id == id).FirstOrDefault();
            if(listTask != null)
            {
                return Json(listTask);
            }
            else
            {
                return BadRequest("Task is not exist.");
            }
        }

        // Create a new task
        [Route("api/Task")]
        [HttpPost]
        public IHttpActionResult CreateNewTask(TaskDTO task)
        {
            if(task.TaskTitle == null)
            {
                return BadRequest("Task title is required fields.");
            }
            if (task.TaskDescription == null)
            {
                return BadRequest("Task description is required fields.");
            }

            DateTime date = DateTime.Now;
            var newTask = new Task();
            newTask.Title = task.TaskTitle;
            newTask.Description = task.TaskDescription;
            newTask.StartDate = date;
            newTask.StartEnd = task.TaskStartEnd;
            newTask.CreatedAt = date;
            dbContext.Tasks.Add(newTask);
            dbContext.SaveChanges();
            return Ok("New task has been created successful.");
        }

        // Create a task detail
        [Route("api/Task-Detail")]
        [HttpPost]
        public IHttpActionResult CreateTaskDetail(TaskDetails task)
        {
            if (task.Comment == null)
            {
                return BadRequest("Task comment is required fields.");
            }

            var ct_task = new Task_Details();
            ct_task.Status = 0;
            ct_task.Rating = task.Rating;
            ct_task.Comment = task.Comment;
            ct_task.TaskID = task.Task;
            ct_task.UserID = task.User;
            dbContext.Task_Details.Add(ct_task);
            dbContext.SaveChanges();
            return Ok("Task detail has been created successful.");
        }

        // Update the task
        [Route("api/Task/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateTask(int id, TaskDTO task)
        {
            var editTask = dbContext.Tasks.Where(t => t.TaskID == id).FirstOrDefault();
            if (editTask != null)
            {
                editTask.Title = task.TaskTitle;
                editTask.Description = task.TaskDescription;
                editTask.StartDate = task.TaskStartDate;
                editTask.StartEnd = task.TaskStartEnd;
                editTask.CreatedAt = DateTime.Now;
                dbContext.SaveChanges();
            }
            else
            {
                return BadRequest("Task is not exist.");
            }
            return Ok("Task has been updated successful.");
        }
    }
}
