using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Assignment4.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Data
{
    public class SqliteUserService : IUserService
    {
        private AdultContext adultContext;

        public SqliteUserService(AdultContext adultContext)
        {
            this.adultContext = adultContext;
        }

        public async Task<User> GetUserAsync(string userName)
        {
            User first = await adultContext.users.FirstOrDefaultAsync(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            return first;
        }
    }
}
