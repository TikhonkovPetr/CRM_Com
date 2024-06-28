using API_CRM.DataBase;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.ComponentModel;

namespace API_CRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        DB dbcont = new DB();
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return dbcont.Users;
        }
        [HttpPost]
        public void PostUserId([FromBody] User user)
        {
            dbcont.Users.Add(user);
            dbcont.SaveChanges();
        }
        [HttpPost("{login}/{password}")]
        public async Task<bool> CreateUser(string login, string password)
        {
            int co= dbcont.Users.Count();
            User us = new User() {Id= Guid.NewGuid(),Login=login,Password=password };
            dbcont.Users.Add(us);
            dbcont.SaveChanges();
            if(co+1 == dbcont.Users.Count())
            {
                return true;
            }
            return false;
        }
        [HttpGet("{login}/{password}")]
        public async Task<Guid> Auth(string login,string password)
        {
            List<User> users = dbcont.Users.Where(u => u.Login == login && u.Password == password).ToList();
            if (users.Count==1)
            {
                return users[0].Id;
            }
            return Guid.Empty;
        }
        [HttpGet("{login}")]
        public async Task<bool> AuthCheck(string login)
        {
            List<User> users = dbcont.Users.Where(u => u.Login == login).ToList();
            if (users.Count == 1)
            {
                return true;
            }
            return false;
        }
    }
}
