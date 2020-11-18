using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParserAPI.BL.Interfaces;
using ParserAPI.DAL.Context;
using ParserAPI.Models;
using Task = ParserAPI.Models.Task;

namespace ParserAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;        
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;            
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IndexViewModel GetUsers(int page = 1)
        {
            return _userRepository.GetUsers(page);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userRepository.Post(user);
        }

        [HttpPost(Name = "PostTask")]
        public void PostTask([FromBody] Task task)
        {
            _userRepository.PostTask(task);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] User user)
        {
            _userRepository.Put(user);
        }
    }
}
