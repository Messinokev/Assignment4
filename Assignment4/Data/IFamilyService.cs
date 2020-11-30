using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;

namespace Assignment4.Data
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamilytAsync();
        Task<Family> AddFamilyAsync(Family family);
        Task RemoveFamilyAsync(int houseNumber,string streetName);
        Task<Family> UpdateFamilyAsync(Family family);
    }
}
