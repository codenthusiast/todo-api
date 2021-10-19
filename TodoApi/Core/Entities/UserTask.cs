using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.Enums;

namespace TodoApi.Core.Entities
{
    public class UserTask : BaseEntity
    {
        public string Description { get; set; }
        public TaskState State { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
