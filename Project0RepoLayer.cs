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

        /// <summary>
        /// Finds User given unique name
        /// </summary>
        /// <param name="uname"></param>
        /// <returns></returns>
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

#nullable enable
/// <summary>
/// Finds whether there is a tour with the given Location Name and Row Number
/// </summary>
/// <param name="locCodeName"></param>
/// <param name="rowNum"></param>
/// <returns></returns>

        public Tour? FindTour(string locCodeName, int rowNum){

                Tour u = new Tour();
                try
                {
                    u = tours.Where(x => (x.LocationCodeName==locCodeName && x.RowNum==rowNum)).FirstOrDefault();
                    if(u!=null ){
                         return u;  
                    }
   
                }
                catch (System.Exception)
                {
                    
                    throw new Exception("No tour found.");
                }
            return null;

        }
#nullable disable




/// <summary>
/// Retrieve all floor as a set of strings
/// </summary>
/// <returns></returns>
        public List<string> FindAllFloors(){

                try
                {
                List<string> lst=new List<string>();
                lst=floors.Select(item => item.LocationCodeName).ToList();
                return lst;
                }
    
                catch (System.Exception)
                {
                    
                    throw new Exception("Nothing found.");
                }
            

        }



        //doesnt need to be nullable no way for it to go wrong
        /// <summary>
        /// Persists painting object to the database. For now this is technically a point on a 2x2 matrix
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cost"></param>
        /// <param name="paingtingName"></param>
        /// <param name="locCodeName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Persist a User to the database
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Persist a Tour to the databse.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="locCodeName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add FloorTourLine entry. Row here defines a row of paintings in database.
        /// </summary>
        /// <param name="locCodeName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Adds FloorTourUsrLine entry. A row here signifies a user visit to the museum.
        /// </summary>
        /// <param name="locCodeName"></param>
        /// <param name="tId"></param>
        /// <param name="uId"></param>
        /// <returns></returns>        
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

    /// <summary>
    /// Temporary way to populate base database. Will be an admin feature for p1.
    /// </summary>
    public void ManualCreateFloor(){
        //Manually create a floor for database.
        Console.WriteLine("About to create default data, Exit if this is not to populate db.");
        Console.ReadLine();


        DBCreateBaseFloor("NewExhbit", 1, 30);
        DBCreateBaseFloor("New2Exhbit", 3, 48);
        DBCreateBaseFloor("New3Exhbit", 5, 57);
       
    

//^^ creates new floor
    }


    /// <summary>
    /// Creates a base floor. This is, creates a list of linked list of paintings. these objects are the virtual room
    /// </summary>
    /// <param name="locCodeName"></param>
    /// <param name="locSize"></param>
    /// <param name="remTours"></param>
    /// <returns></returns>
    public BaseFloor DBCreateBaseFloor(string locCodeName, int locSize, int remTours){

    

    BaseFloor t = new BaseFloor();


            t = floors.Where(t =>  t.LocationCodeName==locCodeName).FirstOrDefault();

            if (t == null)
            {
                List<LinkedList<Painting>> tmpfloor = new List<LinkedList<Painting>>();
                t = new BaseFloor()
                {
                    LocationCodeName=locCodeName,
                    LocationSize=locSize,
                    LocationRemainingTours=remTours
                };

                tmpfloor=t.CreateBaseTours(locSize,locCodeName);
                floors.Add(t);
                DbContext.SaveChanges();
            }
            return t;

    }

    /// <summary>
    /// Allows users to go on tour (reduces remaining tours on the tour Floor taken), consequently create a new FloorTourUsrLine entry.
    /// </summary>
    /// <param name="locCodeName"></param>
    /// <returns></returns>
    public bool UserGoesOnTour(string locCodeName){

    
            BaseFloor t = new BaseFloor();


            t = floors.Where(t =>  t.LocationCodeName==locCodeName).FirstOrDefault();

            if (t == null)
            {
                return false;
                
            }else{
                --t.LocationRemainingTours;
                DbContext.SaveChanges();
                return true;
            }
            


        
    }
}
}