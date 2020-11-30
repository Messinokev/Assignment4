using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4.Models;
using Assignment4.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Assignment4.Data
{
    public class SqliteAdultService : IAdultService
    {
        private AdultContext adultContext;

        public SqliteAdultService(AdultContext adultContext)
        {
            this.adultContext = adultContext;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int max = adultContext.adults.Max(adult => adult.Id);
            adult.Id = (++max);
            EntityEntry<Adult> newlyAdded = await adultContext.adults.AddAsync(adult);
            await adultContext.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<IList<Adult>> GetAdultAsync(string name, int? age, int? id)
        {
            List<Adult> tmp = new List<Adult>(adultContext.adults);
            List<Adult> result = new List<Adult>();

            if (name == null && age == null && id == null)
            {
                return tmp;
            }
            if (name != null && age != null)
            {
                foreach (var adult in tmp)
                {
                    if ((adult.FirstName.ToLower().Contains(name.ToLower()) || adult.LastName.ToLower().Contains(name.ToLower())) && adult.Age >= age)
                    {
                        result.Add(adult);
                    }
                }
                return result;
            }
            if (age != null)
            {
                foreach (var adult in tmp)
                {
                    if (adult.Age >= age)
                    {
                        result.Add(adult);
                    }
                }
                return result;
            }
            if (name != null)
            {
                foreach (var adult in tmp)
                {
                    if ((adult.FirstName.ToLower().Contains(name.ToLower()) || adult.LastName.ToLower().Contains(name.ToLower())))
                    {
                        result.Add(adult);
                    }
                }
                return result;
            }
            if (id != null)
            {
                foreach (var adult in tmp)
                {
                    if (adult.Id == id)
                    {
                        result.Add(adult);
                    }
                }
                return result;
            }
            return null;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult toDelete = await adultContext.adults.FirstOrDefaultAsync(t => t.Id == adultId);
            if (toDelete != null)
            {
                adultContext.adults.Remove(toDelete);
                await adultContext.SaveChangesAsync();
            }
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            try
            {
                Adult toUpdate = await adultContext.adults.FirstAsync(t => t.Id == adult.Id);
                toUpdate.JobTitle = adult.JobTitle;
                toUpdate.Id = adult.Id;
                toUpdate.FirstName = adult.FirstName;
                toUpdate.LastName = adult.LastName;
                toUpdate.HairColor = adult.HairColor;
                toUpdate.EyeColor = adult.EyeColor;
                toUpdate.Age = adult.Age;
                toUpdate.Weight = adult.Weight;
                toUpdate.Height = adult.Height;
                toUpdate.Sex = adult.Sex;
                adultContext.Update(toUpdate);
                await adultContext.SaveChangesAsync();
                return toUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find adult with id{adult.Id}");
            }
        }
    }
}
