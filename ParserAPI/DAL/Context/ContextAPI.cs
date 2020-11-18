using Microsoft.EntityFrameworkCore;
using ParserAPI.DAL.Enums;
using ParserAPI.Models;
using System;
using Task = ParserAPI.Models.Task;

namespace ParserAPI.DAL.Context
{
    public class ContextAPI : DbContext
    {
        public ContextAPI(DbContextOptions<ContextAPI> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                new User { UserId=1, Name="Tom", Surname="Tom", DateCreated = DateTime.Now, Status=Status.Active},
                new User { UserId=2, Name="Alice", Surname="Tom", DateCreated = DateTime.Now, Status=Status.Active},
                new User { UserId=3, Name="Sam", Surname="Tom", DateCreated = DateTime.Now, Status=Status.Active},
                new User { UserId=4, Name="Sam", Surname="Tom", DateCreated = DateTime.Now, Status=Status.Locked},
                new User { UserId=5, Name="Sam", Surname="Tom", DateCreated = DateTime.Now, Status=Status.Disabled}
                });

            modelBuilder.Entity<Task>().HasData(
               new Task[]
               {
                   new Task { TaskId=1, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=2, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 2, ExecutorUserId=3},
                   new Task { TaskId=3, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=4, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=5, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=6, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=7, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 4, ExecutorUserId=5},
                   new Task { TaskId=8, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=9, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=10, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=5},
                   new Task { TaskId=11, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=12, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=13, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=14, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 3, ExecutorUserId=1},
                   new Task { TaskId=15, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=16, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=2},
                   new Task { TaskId=17, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 5, ExecutorUserId=2},
                   new Task { TaskId=18, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=1},
                   new Task { TaskId=19, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 5, ExecutorUserId=1},
                   new Task { TaskId=20, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 3, ExecutorUserId=2},
                   new Task { TaskId=21, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 1, ExecutorUserId=5},
                   new Task { TaskId=22, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 3, ExecutorUserId=1},
                   new Task { TaskId=23, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 5, ExecutorUserId=2},
                   new Task { TaskId=24, Name="Создать задачу", Content="Описание", DateCreated = DateTime.Now, Status=StatusTask.InProcess, DirectorUserId = 3, ExecutorUserId=2}
               });
        }
    }
}
