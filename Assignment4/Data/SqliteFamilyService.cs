using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Assignment4.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Data
{
    public class SqliteFamilyService : IFamilyService
    {
        private AdultContext adultContext;

        public SqliteFamilyService(AdultContext adultContext)
        {
            this.adultContext = adultContext;
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Family>> GetFamilytAsync()
        {
            /*List<Family> tmp = new List<Family>(adultContext.families);
            return tmp;*/


            IList<Family> families = adultContext.families.
                 Include(family => family.Adults).
                 Include(family => family.Children).
                 Include(family => family.Children).
                 Include(family => family.Pets).
                 ToList();

            return families; 


        }

        public async Task RemoveFamilyAsync(int houseNumber, string streetName)
        {
            Family toDelete = await adultContext.families.FirstOrDefaultAsync(t => t.HouseNumber == houseNumber && t.StreetName.Equals(streetName));
            if (toDelete != null)
            {
                adultContext.families.Remove(toDelete);
                await adultContext.SaveChangesAsync();
            }
        }

        public async Task<Family> UpdateFamilyAsync(Family family)
        {
            try
            {
                Family toUpdate = await adultContext.families.FirstAsync(t => t.StreetName == family.StreetName);
                toUpdate.Adults = family.Adults;
                toUpdate.Children = family.Children;
                toUpdate.HouseNumber = family.HouseNumber;
                toUpdate.Pets = family.Pets;
                toUpdate.StreetName = family.StreetName;
                adultContext.Update(toUpdate);
                await adultContext.SaveChangesAsync();
                return toUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find family with streetname{family.StreetName}");
            }
        }
    }
}
