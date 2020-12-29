using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Project0
{ 
    public class Project0DbContext : DbContext
 {

        

     public DbSet<FloorTourLine> FloorTourLines{get;set;}
     public DbSet<FloorTourUsrLine> FloorTourUsrLines{get;set;}

        public DbSet<User> Users { get; set; }
        public DbSet<Painting> Paintings {get;set;}
        public DbSet<Tour> Tours{get;set;}
        public DbSet<BaseFloor> Floors{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
      {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;"
            +"Database=AbstractMuseum;"
           + "Trusted_Connection=True;");
        }

            
    }
}
   