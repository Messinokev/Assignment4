using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment4.Models;
using Assignment4.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Assignment4
{
#pragma warning disable CS1591
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (AdultContext adultContext = new AdultContext())
            {
                if (!adultContext.adults.Any())
                {
                    await SeedAdult(adultContext);
                }
                if (!adultContext.families.Any())
                {
                    await SeedFamily(adultContext);
                }
            }
            CreateHostBuilder(args).Build().Run();
        }

        private static async Task SeedFamily(AdultContext adultContext)
        {

            Family f1 = new Family
            {
                StreetName = "Vienna Street",
                HouseNumber = 1,
                Adults = { new Adult
                {
                    JobTitle = "Soldier",
                    Id = 0,
                    FirstName = "Eloise",
                    LastName = "Schneider",
                    EyeColor = "Brown",
                    HairColor = "Red",
                    Age = 56,
                    Weight = 61.4f,
                    Height = 166,
                    Sex = "F"
                },
                    new Adult
                    {
                        JobTitle = "Animal Geneticist",
                        Id = 1,
                        FirstName = "Max",
                        LastName = "Schneider",
                        EyeColor = "Brown",
                        HairColor = "Black",
                        Age = 36,
                        Weight = 61.4f,
                        Height = 166,
                        Sex = "M"
                    }
                },
                Children = { new Child
                {
                Id = 0,
                FirstName = "Honesty",
                LastName = "Schneider",
                EyeColor = "Grey",
                HairColor = "Black",
                Age = 15,
                Weight = 61.4f,
                Height = 166,
                Sex = "F",
                ChildInterests = {
                new ChildInterest{ChildId = 0, InterestId = "Board Games" },
                new ChildInterest{ChildId = 0,InterestId = "Frozen"},
                new ChildInterest{ChildId = 0,InterestId = "Scout"},
                new ChildInterest{ChildId = 0,InterestId = "Gaming"}
                },
                Pets = { }
                },
                new Child{
                Id = 1,
                FirstName = "Carmelo",
                LastName = "Schneider",
                EyeColor = "Brown",
                HairColor = "Brown",
                Age = 13,
                Weight = 61.4f,
                Height = 166,
                Sex = "M",
                ChildInterests = {
                new ChildInterest{ChildId = 1,InterestId = "Racing Cars" }
                },
                Pets = { }
                }
                },
                Pets = { 
                    new Pet{ 
                        Id = 0,
                        Species = "dog",
                        Name = "first",
                        Age = 0
                    },
                     new Pet{
                        Id = 1,
                        Species = "cat",
                        Name = "second",
                        Age = 0
                    },
                      new Pet{
                          Id = 2,
                        Species = "snake",
                        Name = "snake",
                        Age = 0
                    },
                }
            };

            await adultContext.families.AddAsync(f1);
            await adultContext.SaveChangesAsync();
        }

        private static async Task SeedAdult(AdultContext adultContext)
        {


            Adult a1 = new Adult
            {
                JobTitle = "Database Manager",
                FirstName = "Yeshua",
                LastName = "Magana",
                EyeColor = "Blue",
                HairColor = "Grey",
                Age = 44,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a2 = new Adult
            {
                JobTitle = "Captain",
                FirstName = "Jayden",
                LastName = "Harrell",
                EyeColor = "Hazel",
                HairColor = "Leverpostej",
                Age = 44,
                Weight = 61.4f,
                Height = 166,
                Sex = "F"
            };
            Adult a3 = new Adult
            {
                JobTitle = "Veterenarian",
                FirstName = "Titus",
                LastName = "England",
                EyeColor = "Brown",
                HairColor = "Red",
                Age = 45,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a4 = new Adult
            {
                JobTitle = "ITManager",
                FirstName = "Skylah",
                LastName = "Hernandez",
                EyeColor = "Green",
                HairColor = "Brown",
                Age = 38,
                Weight = 61.4f,
                Height = 166,
                Sex = "F"
            };
            Adult a5 = new Adult
            {
                JobTitle = "Personal Tranier",
                FirstName = "Zaid",
                LastName = "Dalton",
                EyeColor = "Blue",
                HairColor = "Black",
                Age = 38,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a6 = new Adult
            {
                JobTitle = "Talent Acquisition Coordinator",
                FirstName = "Ulises",
                LastName = "Lewis",
                EyeColor = "Brown",
                HairColor = "Black",
                Age = 51,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a7 = new Adult
            {
                JobTitle = "Electrical Engineer",
                FirstName = "Colt",
                LastName = "Lewis",
                EyeColor = "Grey",
                HairColor = "Black",
                Age = 42,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a8 = new Adult
            {
                JobTitle = "Front Desk Coordinator",
                FirstName = "Zaynab",
                LastName = "Schultz",
                EyeColor = "Grey",
                HairColor = "Black",
                Age = 34,
                Weight = 61.4f,
                Height = 166,
                Sex = "F"
            };
            Adult a9 = new Adult
            {
                JobTitle = "Aquatic Ecologist",
                FirstName = "Kaidence",
                LastName = "Ferguson",
                EyeColor = "Brown",
                HairColor = "Brown",
                Age = 37,
                Weight = 61.4f,
                Height = 166,
                Sex = "F"
            };
            Adult a10 = new Adult
            {
                JobTitle = "Casino Host",
                FirstName = "Magnus",
                LastName = "Rivas",
                EyeColor = "Brown",
                HairColor = "Brown",
                Age = 53,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a11 = new Adult
            {
                JobTitle = "Chemist",
                FirstName = "Zayne",
                LastName = "Douglas",
                EyeColor = "Grey",
                HairColor = "Black",
                Age = 48,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a12 = new Adult
            {
                JobTitle = "Business Development Manager",
                FirstName = "Mustafa",
                LastName = "Mckay",
                EyeColor = "Brown",
                HairColor = "Black",
                Age = 51,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a13 = new Adult
            {
                JobTitle = "Hairdresser",
                FirstName = "Landry",
                LastName = "Armstrong",
                EyeColor = "Blue",
                HairColor = "Brown",
                Age = 58,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            }; Adult a14 = new Adult
            {
                JobTitle = "Meeting Planner",
                FirstName = "Jace",
                LastName = "Orr",
                EyeColor = "Grey",
                HairColor = "Green",
                Age = 51,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a15 = new Adult
            {
                JobTitle = "Gardener",
                FirstName = "Kehlani",
                LastName = "Hernandez",
                EyeColor = "Brown",
                HairColor = "Black",
                Age = 45,
                Weight = 61.4f,
                Height = 166,
                Sex = "F"
            };

            await adultContext.adults.AddAsync(a1);
            await adultContext.adults.AddAsync(a2);
            await adultContext.adults.AddAsync(a3);
            await adultContext.adults.AddAsync(a4);
            await adultContext.adults.AddAsync(a5);
            await adultContext.adults.AddAsync(a6);
            await adultContext.adults.AddAsync(a7);
            await adultContext.adults.AddAsync(a8);
            await adultContext.adults.AddAsync(a9);
            await adultContext.adults.AddAsync(a10);
            await adultContext.adults.AddAsync(a11);
            await adultContext.adults.AddAsync(a12);
            await adultContext.adults.AddAsync(a13);
            await adultContext.adults.AddAsync(a14);
            await adultContext.adults.AddAsync(a15);
            await adultContext.SaveChangesAsync();
        }




        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
#pragma warning restore CS1591
}
