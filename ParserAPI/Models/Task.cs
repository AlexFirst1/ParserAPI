using ParserAPI.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParserAPI.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateChanged { get; set; }
        public StatusTask Status { get; set; }        
        public virtual User Director { get; set; }        
        public virtual User Executor { get; set; }
        public int? DirectorUserId { get; set; }
        public int? ExecutorUserId { get; set; }
    }    
}
