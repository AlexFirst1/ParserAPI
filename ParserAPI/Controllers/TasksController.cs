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
    public class TasksController : ControllerBase
    {
        private readonly ContextAPI _contex;
        public TasksController(ContextAPI contex)
        {
            _contex = contex;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return _contex.Tasks;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IndexViewModel GetTasksExecutor(int executorId, int page = 1)
        {
            int pageSize = 3; // количество объектов на страницу
            var tasksExecutor = _contex.Tasks.Where(x => x.ExecutorUserId == executorId);
            IEnumerable<Task> tasksPerPages = tasksExecutor.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = tasksExecutor.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Tasks = tasksPerPages };
            return ivm;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IndexViewModel GetTasksDirector(int directorId, int page = 1)
        {
            int pageSize = 3; // количество объектов на страницу
            var tasksDirector = _contex.Tasks.Where(x => x.DirectorUserId == directorId);
            IEnumerable<Task> tasksPerPages = tasksDirector.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = tasksDirector.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Tasks = tasksPerPages };
            return ivm;
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}", Name = "GetTask")]
        public Task Get(int id)
        {
            return _contex.Tasks.SingleOrDefault(x => x.TaskId == id);
        }

        // POST api/<TasksController>
        [HttpPost]
        public void Post([FromBody] Task Task)
        {
            _contex.Tasks.Add(Task);
            _contex.SaveChanges();
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Task Task)
        {
            var item = _contex.Tasks.SingleOrDefault(x => x.TaskId == Task.TaskId);
            if (item != null)
            {
                item.Name = Task.Name;
                item.Content = Task.Content;
                item.DateChanged = DateTime.Now;
                item.ExecutorUserId = Task.ExecutorUserId;

                _contex.Tasks.Update(item);
                _contex.SaveChanges();
            }
        }


        [HttpPut("{id}", Name = "ChangeStatus")]
        public void ChangeStatus([FromBody] Task task)
        {
            var item = _contex.Tasks.SingleOrDefault(x => x.TaskId == task.TaskId);
            if (item != null)
            {
                item.Status = task.Status;
                _contex.Tasks.Update(item);
                _contex.SaveChanges();
            }
        }

        [HttpPut("{id}", Name = "ChangeDirector")]
        public void ChangeDirector([FromBody] Task task)
        {
            var item = _contex.Tasks.SingleOrDefault(x => x.TaskId == task.TaskId);
            if (item != null)
            {
                item.DirectorUserId = task.DirectorUserId;
                _contex.Tasks.Update(item);
                _contex.SaveChanges();
            }
        }

        // DELETE api/<TasksController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var item = _contex.Tasks.SingleOrDefault(x => x.TaskId == id);
        //    if (item != null)
        //    {
        //        _contex.Tasks.Remove(item);
        //        _contex.SaveChanges();
        //    }
        //}
    }
}
