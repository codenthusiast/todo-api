using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.Entities;

namespace TodoApi.Core.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
