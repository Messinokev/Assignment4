using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;

namespace Assignment4.Data
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string userName);
        
    }
}
