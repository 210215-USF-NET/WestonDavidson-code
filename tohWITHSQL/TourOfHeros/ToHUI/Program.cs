using System;
using ToHModels;
using ToHBL;
using ToHDL;
using ToHDL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

//dotnet add reference ../ToHModels
//when would you choose to create a new project vs a new namespace?
namespace ToHUI
{
    class Program
    {

        static void Main(string[] args)
        {
            //get the config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();


            //setting up DB connection
            string connectionString = configuration.GetConnectionString("HeroDB");
            DbContextOptions<HeroDBContext> options = new DbContextOptionsBuilder<HeroDBContext>()
            .UseSqlServer(connectionString)
            .Options;

            //this is a using statement, using statements can be used to dispose of the context when it's no longer used
            using var context = new HeroDBContext(options);



            IMenu menu = new HeroMenu(new HeroBL(new HeroRepoDB(context, new HeroMapper())));
            menu.Start();


        }
    }
}
