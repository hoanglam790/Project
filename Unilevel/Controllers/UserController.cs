using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unilevel.Models;
using Unilevel.DTO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Unilevel.Controllers
{
    public class UserController : ApiController
    {
        UnilevelDbContext dbContext = new UnilevelDbContext();

        // Get user
        [Route("api/Area/User/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserByID(int id)
        {
            var listUser = (from u in dbContext.Users
                            //join a in dbContext.Area_Users on u.AreaID equals a.AreaID
                            join b in dbContext.Areas on u.AreaID equals b.AreaID
                            select new UserDTO()
                            {
                                UserId = u.UserID,
                                Name = u.FullName,
                                Email = u.Email,
                                Role = u.Role.RoleName,
                                Area = b.AreaName,
                                Status = u.Status
                            }).Where(a => a.UserId == id).FirstOrDefault();
            if (listUser != null)
            {
                return Json(listUser);
            }
            else
            {
                return BadRequest("User is not exists");
            }
        }

        // Register a new account
        [Route("api/User/Register")]
        [HttpPost]
        public IHttpActionResult RegisterUser(UserRegister user)
        {
            if(dbContext.Users.Any(n => n.Email == user.Email))
            {
                return BadRequest("User already exist.");
            }

            CreatePasswordHashing(user.Password, out byte[] passHash, out byte[] passSalt);

            var userRequest = new User();
            userRequest.Email = user.Email;
            userRequest.FullName = user.Name;
            userRequest.PasswordHashing = passHash;
            userRequest.PasswordSalting = passSalt;
            userRequest.RoleID = user.Role;
            userRequest.AreaID = user.Area;
            userRequest.Status = 0;
            userRequest.VerifyToken = CreateRandomToken();
            dbContext.Users.Add(userRequest);

            var ct_area_user = new Area_Users();
            ct_area_user.AreaID = (int)userRequest.AreaID;
            ct_area_user.UserID = userRequest.UserID;
            dbContext.Area_Users.Add(ct_area_user);
            
            dbContext.SaveChanges();
            return Ok("New user has been created successful.");
        }

        // Login account
        [Route("api/User/Login")]
        [HttpPost]
        public IHttpActionResult LoginUser(UserLogin user)
        {
            if(user.Email == null)
            {
                return BadRequest("Please enter your email.");
            }
            if (user.Password == null)
            {
                return BadRequest("Please enter your password.");
            }
            
            var userLogin = dbContext.Users.FirstOrDefault(n => n.Email == user.Email);
            if (userLogin == null)
            {
                return BadRequest("User is not found.");
            }

            if (!VerifyPasswordHashing(user.Password, userLogin.PasswordHashing, userLogin.PasswordSalting))
            {
                return BadRequest("Password is invalid. Please check again !!!");
            }

            if (userLogin.VerifiedAt == null)
            {
                return BadRequest("Unauthenticated user.");
            }           
            return Ok($"Login successful. Your name: {userLogin.FullName}");
        }

        // Verify successfull, the user is allowed to login
        [Route("api/User/Verify")]
        [HttpPost]
        public IHttpActionResult VerifyUser(string token)
        {
            var userLogin = dbContext.Users.FirstOrDefault(n => n.VerifyToken == token);
            if (userLogin == null)
            {
                return BadRequest("Invalid token.");
            }
            userLogin.VerifiedAt = DateTime.Now;
            dbContext.SaveChanges();           
            return Ok("User has been verified successful.");
        }

        // Forget password
        [Route("api/User/Forget-Password")]
        [HttpPost]
        public IHttpActionResult ForgetPassword(string email)
        {
            var user = dbContext.Users.FirstOrDefault(n => n.Email == email);
            if (user == null)
            {
                return BadRequest("User is not found.");
            }
            user.PasswordReset = CreateRandomToken();
            user.ResetToken = DateTime.Now.AddDays(1);
            dbContext.SaveChanges();
            return Ok("You can reset your password now.");
        }

        // Reset the password
        [Route("api/User/Reset-Password")]
        [HttpPost]
        public IHttpActionResult ResetPassword(ResetPassword password)
        {
            var user = dbContext.Users.FirstOrDefault(n => n.PasswordReset == password.Token);
            if (user == null || user.ResetToken < DateTime.Now)
            {
                return BadRequest("Invalid token.");
            }

            CreatePasswordHashing(password.Password, out byte[] passHash, out byte[] passSalt);

            user.PasswordHashing = passHash;
            user.PasswordSalting = passSalt;
            user.PasswordReset = null;
            user.ResetToken = null;
            dbContext.SaveChanges();
            return Ok("Reset your password successful.");
        }

        // Create a hash password, it use to save the database
        private void CreatePasswordHashing(string password, out byte[] passHash, out byte[] passSalt)
        {
            using(var ph = new HMACSHA512())
            {
                passSalt = ph.Key;
                passHash = ph.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHashing(string password, byte[] passHash, byte[] passSalt)
        {
            using (var ph = new HMACSHA512(passSalt))
            {
                var computhHash = ph.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computhHash.SequenceEqual(passHash);
            }
        }

        private string CreateRandomToken()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 64)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            //return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
