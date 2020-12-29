using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Project0
{

    public class FloorTourLine
    {

        private string locationCodeName;
        private Guid tourIDGuid;
        [Key]
        public  Guid FloorTourLineID { get;set;} = Guid.NewGuid();
        public string LocationCodeName { get{return locationCodeName;} set{locationCodeName= value;} } 
        public  Guid TourID { get{return tourIDGuid;} set{tourIDGuid= Guid.NewGuid();} } 


        public FloorTourLine(){}
        public FloorTourLine(
                     string locationCodeName = "0",
                     Guid tId = new Guid())
                     
                {
                    this.LocationCodeName=locationCodeName;
                    this.TourID= tId;
                }
    }



    
}