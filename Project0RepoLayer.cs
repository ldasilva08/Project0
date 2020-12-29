using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace Project0
{
    public class Project0RepoLayer
    {
        
        //set db repo vars
        static public Project0DbContext DbContext = new Project0DbContext();
        DbSet<User> users = DbContext.Users;
        DbSet<Painting> paintings= DbContext.Paintings;
        DbSet<Tour> tours= DbContext.Tours;
        DbSet<BaseFloor> floors= DbContext.Floors;
        DbSet<FloorTourLine> floorTourLines= DbContext.FloorTourLines;
        DbSet<FloorTourUsrLine> floorTourUsrLines= DbContext.FloorTourUsrLines;


        //repo methods

#nullable enable
        public User? FindUser(string uname){

                User u = new User();
                try
                {
                    u = users.Where(x => x.Username== uname ).FirstOrDefault();
                    if(u!=null ){
                         return u;  
                    }
   
                }
                catch (System.Exception)
                {
                    
                    throw new Exception("No one found.");
                }
            return null;

        }
#nullable disable
        //doesnt need to be nullable no way for it to go wrong
        public Painting CreatePainting(int x, int y, int cost, string paingtingName, string locCodeName){
                Painting p = new Painting();
                p=paintings.Where( x => x.PaintingName==paingtingName && x.LocationCodeName==locCodeName).FirstOrDefault();

                if(p==null)
                {
                    p=new Painting()
                    {
                        X=x,
                        Y=y,
                        Cost=cost,
                        PaintingName=paingtingName,
                        LocationCodeName=locCodeName
                    };
                    paintings.Add(p);
                    DbContext.SaveChanges();
                }
                return p;
        }

        public User CreateUser(string uName="null", string fName = "null", string lName = "null")
       
        {
            User u = new User();

            u = users.Where(x => x.Username== uName ).FirstOrDefault();

            if (u == null)
            {
                u = new User()
                {
                    Username=uName,
                    Fname = fName,
                    Lname = lName
                };
                users.Add(u);
                DbContext.SaveChanges();
            }
            return u;
        }
        
        public Tour CreateTour(int number, string locCodeName)
       
        {
            Tour t = new Tour();

            t = tours.Where(t => t.LocationCodeName== locCodeName && t.RowNum==number).FirstOrDefault();

            if (t == null)
            {
                t = new Tour()
                {
                    LocationCodeName=locCodeName,
                    RowNum=number
                };
                tours.Add(t);
                DbContext.SaveChanges();
            }
            return t;
        }

        public FloorTourLine CreateFloorTourLine(string locCodeName, Guid id)
       
        {
            FloorTourLine t = new FloorTourLine();


            t = floorTourLines.Where(t => t.LocationCodeName== locCodeName && t.TourID==id).FirstOrDefault();

            if (t == null)
            {
                t = new FloorTourLine()
                {
                    LocationCodeName=locCodeName,
                    TourID=id
                };
                floorTourLines.Add(t);
                DbContext.SaveChanges();
            }
            return t;
        }

        public FloorTourUsrLine CreateFloorTourUsrLine(string locCodeName, Guid tId, Guid uId )

       
        {
            FloorTourUsrLine t = new FloorTourUsrLine();


            t = floorTourUsrLines.Where(t =>  t.UserID==uId && t.LocationCodeName==locCodeName && t.TourID==tId).FirstOrDefault();

            if (t == null)
            {
                t = new FloorTourUsrLine()
                {
                    UserID=uId,
                    TourID=tId,
                    LocationCodeName=locCodeName
                };
                floorTourUsrLines.Add(t);
                DbContext.SaveChanges();
            }
            return t;
        }
    public BaseFloor DBCreateBaseFloor(string locCodeName, int locSize, int remTours){

    

BaseFloor t = new BaseFloor();


            t = floors.Where(t =>  t.LocationCodeName==locCodeName).FirstOrDefault();

            if (t == null)
            {
                t = new BaseFloor()
                {
                    LocationCodeName=locCodeName,
                    LocationSize=locSize,
                    LocationRemainingTours=remTours
                };
                floors.Add(t);
                DbContext.SaveChanges();
            }
            return t;

    }




        
    }
}
