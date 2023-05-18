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
    public class NotificationController : ApiController
    {
        UnilevelDbContext dbContext = new UnilevelDbContext();

        //GET
        [Route("api/Notification")]
        [HttpGet]
        public IHttpActionResult GetAllNotification()
        {
            var listNotification = (from n in dbContext.Notifications
                                   select new Notify()
                                   {
                                       Id = n.NotificationID,
                                       Title = n.Title,
                                       Content = n.Contents,
                                       Sender = n.User.FullName,
                                       Receiver = n.Receiver,
                                       Date = n.Date
                                   }).ToList();
            return Json(listNotification);
        }

        //GET by ID
        [Route("api/Notification/{id}")]
        [HttpGet]
        public IHttpActionResult GetNotificationByID(int id)
        {
            var listNotification = (from n in dbContext.Notifications
                                    select new Notify()
                                    {
                                        Id = n.NotificationID,
                                        Title = n.Title,
                                        Content = n.Contents,
                                        Sender = n.User.FullName,
                                        Receiver = n.Receiver,
                                        Date = n.Date
                                    }).Where(n => n.Id == id).FirstOrDefault();
            if(listNotification != null)
            {
                return Json(listNotification);
            }
            else
            {
                return BadRequest("Notification is not exist.");
            }
        }

        // Create a new notification
        [Route("api/Notification")]
        [HttpPost]
        public IHttpActionResult CreateNewNotification(NotifyDTO notify)
        {
            if(notify.Title == null)
            {
                return BadRequest("Notification title is required fields.");
            }
            if (notify.Content == null)
            {
                return BadRequest("Notification content is required fields.");
            }

            var notification = new Notification();
            notification.Title = notify.Title;
            notification.UserID = notify.Sender;
            notification.Receiver = notify.Receiver;
            notification.Contents = notify.Content;
            notification.Date = DateTime.Now;
            notification.Status = 0;
            dbContext.Notifications.Add(notification);
            dbContext.SaveChanges();
            return Ok("New Notification has been created successful.");
        }

        // Edit the notification
        [Route("api/Notification/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateNotification(int id, NotifyDTO notify)
        {
            var editNotification = dbContext.Notifications.Where(n => n.NotificationID == id).FirstOrDefault();
            if(editNotification != null)
            {
                editNotification.Title = notify.Title;
                editNotification.UserID = notify.Sender;
                editNotification.Receiver = notify.Receiver;
                editNotification.Contents = notify.Content;
                editNotification.Date = DateTime.Now;
                editNotification.Status = notify.Status;
                dbContext.SaveChanges();
            }
            else
            {
                return BadRequest("Notification is not exist.");
            }
            return Ok("Notification has been updated successful.");
        }

        // Detele the notification
        [Route("api/Notification/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteNotification(int id)
        {
            var deleteNotification = dbContext.Notifications.Where(n => n.NotificationID == id).FirstOrDefault();
            if (deleteNotification != null)
            {
                dbContext.Notifications.Remove(deleteNotification);
                dbContext.SaveChanges();
            }
            else
            {
                return BadRequest("Not a valid notification id.");
            }
            return Ok("Notification has been deleted successful.");
        }
    }
}
