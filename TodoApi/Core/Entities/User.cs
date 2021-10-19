using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserTask> Tasks { get; set; }
    }
}
