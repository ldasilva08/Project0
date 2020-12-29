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
                    this.FloorArray=this.CreateBaseTours(this.locationSize, this.LocationCodeName);
                }


 
        //private variable init

        [Key]
        public Guid LocationID { get; set; } = Guid.NewGuid();

        [Key]
        private string locationCodeName;
        private int locationSize;
        private int locationRemainingTours;

        public List<LinkedList<Painting>> FloorArray;
        //public properties

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
        public LinkedList<Painting> getTourAtIndex(int index){ //ultimately get row
            LinkedList<Painting> temp=new LinkedList<Painting>();
            temp=this.FloorArray[index];
            return temp;}

        public List<LinkedList<Painting>> CreateBaseTours(int locSize, string floorName){
            List<LinkedList<Painting>> floorArr=new List<LinkedList<Painting>>();
            

            for (int i = 0; i < locSize; i++)
            {
                LinkedList<Painting> rowList = new LinkedList<Painting>(); 
                for (int j = 0; j < locSize; j++)
                {
            Console.WriteLine($"{i}");
            Console.ReadLine();
                    var p= p0Context.CreatePainting(i+1 , j+1, 20,$" <={i}--{j}=> ", floorName );
                    
                    rowList.AddLast(p);   
                }

                floorArr.Add(rowList);
                

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



