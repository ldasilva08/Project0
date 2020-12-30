using System;
using System.ComponentModel.DataAnnotations;
namespace Project0
{
    public class Tour
    {
        private string locationCodeName;
        private int rowNum;
        public int RowNum{get{return rowNum;}set{rowNum=value;}}

        public Guid TourID { get; set; } = Guid.NewGuid();
        public string LocationCodeName { get {return locationCodeName;} set {
                    
                if (value is string && value.Length < 20 && value.Length > 0)
                    {
                        locationCodeName = value;
                    }
                else
                    {
                        throw new Exception("The parameters given to do not match a Floor's properties...");
                    }} }
        

            //constructors
         public Tour(){}
         public Tour(int number, string locCodeName)
                {
                    this.RowNum=number;
                    this.LocationCodeName=locCodeName;
                }
    }
}