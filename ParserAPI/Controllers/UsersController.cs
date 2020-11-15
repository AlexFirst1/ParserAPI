using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParserAPI.Context;
using ParserAPI.Models;
using Task = ParserAPI.Models.Task;

namespace ParserAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ContextAPI _contex;
        public UsersController(ContextAPI contex)
        {
            _contex = contex;
        }

        //public ActionResult Index(int page = 1)
        //{
        //    int pageSize = 3; // количество объектов на страницу
        //    IEnumerable<User> usersPerPages = _contex.Users.Skip((page - 1) * pageSize).Take(pageSize);
        //    PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = _contex.Users.Count()};
        //    IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Users = usersPerPages };
        //    return View(ivm);
        //}

        // GET: api/<UsersController>
        [HttpGet]
        public IndexViewModel GetUsers(int page = 1)
        {
            int pageSize = 3; // количество объектов на страницу
            IEnumerable<User> usersPerPages = _contex.Users.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = _contex.Users.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Users = usersPerPages };
            return ivm;//_contex.Users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _contex.Users.SingleOrDefault(x => x.UserId == id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _contex.Users.Add(user);
            _contex.SaveChanges();
        }

        [HttpPost(Name = "PostTask")]
        public void PostTask([FromBody] Task task)
        {
            _contex.Tasks.Add(task);
            _contex.SaveChanges();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] User user)
        {
            var item = _contex.Users.SingleOrDefault(x => x.UserId == user.UserId);
            if (item != null)
            {
                item.Name = user.Name;
                item.Surname = user.Surname;
                item.DateChanged = DateTime.Now;
                _contex.Users.Update(item);
                _contex.SaveChanges();
            }
        }

        // DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var item = _contex.Users.SingleOrDefault(x => x.UserId == id);
        //    if (item != null)
        //    {
        //        _contex.Users.Remove(item);
        //        _contex.SaveChanges();
        //    }
        //}
    }
}
