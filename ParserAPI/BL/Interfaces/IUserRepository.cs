using ParserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ParserAPI.Models.Task;

namespace ParserAPI.BL.Interfaces
{
    public interface IUserRepository
    {
        IndexViewModel GetUsers(int page = 1);
        User Get(int id);
        void Post(User user);
        void PostTask(Task task);
        void Put(User user);
    }
}
