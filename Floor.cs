using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
        //in order to create a new "store" you have to allocate it in memory!
        //this is why it has to be hard-coded. just like you'd need to get mroe real estate
        //to expand a museum you need "virtual" real estate to add another Abstract Museum floor!
    public class BaseFloor{
         static Project0RepoLayer p0Context = new Project0RepoLayer(); 

        //constructors
        public BaseFloor(){}
        public BaseFloor(
                     string locCodeName = "0",
                     int locSize = 0,
                     int locRemainingTours=0)
                     
                {
                    this.LocationCodeName=locCodeName;
                    this.LocationSize=locSize;
                    this.LocationRemainingTours=locRemainingTours;
                
                }


 
        //private variable init

        
        private string locationCodeName;
        private int locationSize;
        private int locationRemainingTours;

        //public 
        
        [Key]   
        public string LocationCodeName { get {return locationCodeName;} set {
                    
                if (value is string && value.Length < 20 && value.Length > 0)
                    {
                        locationCodeName = value;
                    }
                else
                    {
                        throw new Exception("The parameters given to do not match a Floor's properties...");
                    }} }
        public int LocationSize { get {return locationSize;} set {

                    
                if ( value > 0)
                    {
                        locationSize = value;
                    }
                else
                    {
                        throw new Exception("The parameters given to do not match a Floor's properties...");
                    }} }
        public int LocationRemainingTours { get {return locationRemainingTours;} set {

                    
                if ( value > 0)
                    {
                        locationRemainingTours = value;
                    }
                else
                    {
                        throw new Exception("The parameters given to do not match a Floor's properties...");
                    }} }




        //unique methods

        public List<LinkedList<Painting>> CreateBaseTours(int locSize, string floorName){
            List<LinkedList<Painting>> floorArr=new List<LinkedList<Painting>>();
            int rowCount=0;
            for (int i = 0; i < locSize; i++)
            {
                LinkedList<Painting> rowList = new LinkedList<Painting>(); 
                for (int j = 0; j < locSize; j++)
                {

                    var p= p0Context.CreatePainting(i+1 , j+1, 20,$" <={i}--{j}=> ", floorName );
                    rowList.AddLast(p);   
                }
                var tour=p0Context.CreateTour(++rowCount, floorName);
                p0Context.CreateFloorTourLine(floorName,tour.TourID);
                


            }
        return floorArr;
        
        }


//display linked list helper
        public static void DisplayTour(LinkedList<Painting> paintings)
    {
        foreach (Painting p in paintings)
        {
            Console.Write(p.ToString());
        }
    } 







    }//endl base class

} //endl namespace



