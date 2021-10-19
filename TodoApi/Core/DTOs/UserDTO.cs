using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Core.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
    }
    
    public class GetUserDTO
    {
        public GetUserDTO()
        {
            Tasks = new List<GetTaskDTO>();
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public IEnumerable<GetTaskDTO> Tasks { get; set; }
    }


}
