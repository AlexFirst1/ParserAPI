using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParserAPI.BL.Interfaces;
using ParserAPI.Models;
using Task = ParserAPI.Models.Task;

namespace ParserAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IndexViewModel GetTasksExecutor(int executorId, int page = 1)
        {
            return _taskRepository.GetTasksExecutor(executorId, page);
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IndexViewModel GetTasksDirector(int directorId, int page = 1)
        {
            return _taskRepository.GetTasksDirector(directorId, page);
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}", Name = "GetTask")]
        public Task Get(int id)
        {
            return _taskRepository.Get(id);
        }

        // POST api/<TasksController>
        [HttpPost]
        public void Post([FromBody] Task task)
        {
            _taskRepository.Post(task);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Task task)
        {
            _taskRepository.Put(task);
        }

        [HttpPut("{id}", Name = "ChangeStatus")]
        public void ChangeStatus([FromBody] Task task)
        {
            _taskRepository.ChangeStatus(task);
        }

        [HttpPut("{id}", Name = "ChangeDirector")]
        public void ChangeDirector([FromBody] Task task)
        {
            _taskRepository.ChangeDirector(task);
        }
    }
}
