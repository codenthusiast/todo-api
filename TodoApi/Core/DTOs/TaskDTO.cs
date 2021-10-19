using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.Enums;

namespace TodoApi.Core.DTOs
{
    public class CreateTaskDTO
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public TaskState TaskState { get; set; }
    }    
    
    public class GetTaskDTO
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public TaskState TaskState { get; set; }
    }



    
}
