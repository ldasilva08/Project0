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


        //repo methods

        /// <summary>
        /// Creates a user after verifying that the player does not already exist. returns the user obj
        /// </summary>
        /// <returns></returns>
        /// 
        /// 
        /// 
        /// 
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
        









        
    }
}
