using ParserAPI.BL.Interfaces;
using ParserAPI.DAL.Context;
using ParserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Task = ParserAPI.Models.Task;

namespace ParserAPI.BL.Implementations
{
    public class UserRepository : IUserRepository
    {
        private ContextAPI context;
        public UserRepository(ContextAPI context)
        {
            this.context = context;
        }

        public User Get(int id)
        {
            return context.Users.SingleOrDefault(x => x.UserId == id);
        }

        public IndexViewModel GetUsers(int page = 1)
        {
            int pageSize = 3; // количество объектов на страницу
            IEnumerable<User> usersPerPages = context.Users.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = context.Users.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Users = usersPerPages };
            return ivm;
        }

        public void Post(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void PostTask(Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        public void Put(User user)
        {
            var item = context.Users.SingleOrDefault(x => x.UserId == user.UserId);
            if (item != null)
            {
                item.Name = user.Name;
                item.Surname = user.Surname;
                item.DateChanged = DateTime.Now;
                context.Users.Update(item);
                context.SaveChanges();
            }
        }
    }
}
