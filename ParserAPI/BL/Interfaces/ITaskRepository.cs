using ParserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ParserAPI.Models.Task;

namespace ParserAPI.BL.Interfaces
{
    public interface ITaskRepository
    {
        IndexViewModel GetTasksExecutor(int executorId, int page = 1);
        IndexViewModel GetTasksDirector(int directorId, int page = 1);
        Task Get(int id);
        void Post(Task Task);
        void Put(Task Task);
        void ChangeStatus(Task task);
        void ChangeDirector(Task task);
    }
}
