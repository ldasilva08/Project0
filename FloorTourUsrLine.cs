using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Project0
{

    public class FloorTourUsrLine
    {
         private Guid userID;
        private string locationCodeName;

        private Guid tourIDGuid;
        [Key]
        public  Guid FloorTourLineID { get;set;} = Guid.NewGuid();
        public string LocationCodeName { get{return locationCodeName;} set{locationCodeName= value;} } 
        public  Guid TourID { get{return tourIDGuid;} set{tourIDGuid= Guid.NewGuid();} } 

        
        public Guid UserID {get{return userID;} set{userID=value;}}
        
        public  Guid FloorTourUsrLineID { get;set;} = Guid.NewGuid();


        public FloorTourUsrLine(){}
        public FloorTourUsrLine(
                     string locationCodeName = "0",
                     Guid tId = new Guid(),
                     Guid uID = new Guid())
                     
                {
                    this.LocationCodeName=locationCodeName;
                    this.TourID= tId;
                    this.UserID=uID;
                }
    }



    
}























