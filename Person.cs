using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
    
    abstract public class Person

    {
        static Project0RepoLayer p0Context = new Project0RepoLayer(); 
            public abstract string Username{get;set;}
            public abstract string Fname{get;set;}
            public abstract string Lname{get;set;}
            public abstract Guid UserID{get;set;}
  
    }

    

    public class User: Person

        
        {
         //constructors
         public User(){}
         public User(string uname= "0", string fname = "0", string lname = "0")
                {
                    this.Username=uname;
                    this.Fname = fname;
                    this.Lname = lname;
                }
                //private variable init

                [Key]
                public override Guid UserID { get; set; } = Guid.NewGuid();
                private string username;
                private string fname;
                private string lname;
                

                //properties for private variables
                public override string Username { get {return username;} set {
                    
                if (value is string && value.Length < 20 && value.Length > 0)
                    {
                        username = value;
                    }
                else
                    {
                        throw new Exception("The player name you sent is not valid");
                    }} }
                public override string Fname { get {return username;} set {
                    
                if (value is string && value.Length < 20 && value.Length > 0)
                    {
                        fname = value;
                    }
                else
                    {
                        throw new Exception("The player name you sent is no valid");
                    }} }
                public override string Lname { get {return username;} set {
                    
                if (value is string && value.Length < 20 && value.Length > 0)
                    {
                        lname = value;
                    }
                else
                    {
                        throw new Exception("The player name you sent is no valid");
                    }} }

            //methods
                

    }

    //this setup allows for: Class Admin : User, IAdmin
}