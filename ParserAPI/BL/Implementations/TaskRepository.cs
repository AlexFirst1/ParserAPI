using ParserAPI.BL.Interfaces;
using ParserAPI.DAL.Context;
using ParserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParserAPI.BL.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private ContextAPI context;
        public TaskRepository(ContextAPI context)
        {
            this.context = context;
        }

        public void ChangeDirector(Task task)
        {
            var item = context.Tasks.SingleOrDefault(x => x.TaskId == task.TaskId);
            if (item != null)
            {
                item.DirectorUserId = task.DirectorUserId;
                context.Tasks.Update(item);
                context.SaveChanges();
            }
        }

        public void ChangeStatus(Task task)
        {
            var item = context.Tasks.SingleOrDefault(x => x.TaskId == task.TaskId);
            if (item != null)
            {
                item.Status = task.Status;
                context.Tasks.Update(item);
                context.SaveChanges();
            }
        }

        public Task Get(int id)
        {
            return context.Tasks.SingleOrDefault(x => x.TaskId == id);
        }

        public IndexViewModel GetTasksDirector(int directorId, int page = 1)
        {
            int pageSize = 3; // количество объектов на страницу
            var tasksDirector = context.Tasks.Where(x => x.DirectorUserId == directorId);
            IEnumerable<Task> tasksPerPages = tasksDirector.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = tasksDirector.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Tasks = tasksPerPages };
            return ivm;
        }

        public IndexViewModel GetTasksExecutor(int executorId, int page = 1)
        {
            int pageSize = 3; // количество объектов на страницу
            var tasksExecutor = context.Tasks.Where(x => x.ExecutorUserId == executorId);
            IEnumerable<Task> tasksPerPages = tasksExecutor.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = tasksExecutor.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Tasks = tasksPerPages };
            return ivm;
        }

        public void Post(Task Task)
        {
            context.Tasks.Add(Task);
            context.SaveChanges();
        }

        public void Put(Task Task)
        {
            var item = context.Tasks.SingleOrDefault(x => x.TaskId == Task.TaskId);
            if (item != null)
            {
                item.Name = Task.Name;
                item.Content = Task.Content;
                item.DateChanged = DateTime.Now;
                item.ExecutorUserId = Task.ExecutorUserId;

                context.Tasks.Update(item);
                context.SaveChanges();
            }
        }
    }
}
