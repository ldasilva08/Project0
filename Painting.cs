using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project0
{
    public abstract class Node
    {
        //variables/props
        public abstract int X{get;set;}
        public abstract int Y{get;set;}
        public abstract int Cost{get;set;}

        

        public abstract Guid PaintingID{get;set;}


        //method
        public abstract void goRight();
        public abstract void goUp();
        public abstract void goLeft();
        public abstract void goDown();

    }

        public class Painting : Node
        {
        
 
         //constructors
         public Painting(){}
         public Painting(int x=0, int y=0, int cost=20, string paintingName = "0", string locCodeName="0")
                {
                    this.X=x;
                    this.Y=y;
                    this.Cost=cost;
                    this.PaintingName=paintingName;
                    this.LocationCodeName=locCodeName;
                }
                //private variable init +key

                [Key]
                public override Guid PaintingID { get; set; } = Guid.NewGuid();
                private int x;
                private int y;
                private int cost;

                private string paintingName;
                private string locationCodeName;

            //properties for private variables
            public string PaintingName { get {return paintingName;} set {
                    
                if (value is string && value.Length < 20 && value.Length > 0)
                    {
                        paintingName = value;
                    }
                else
                    {
                        throw new Exception("The player name you sent is no valid");
                    }} }
            public string LocationCodeName { get {return locationCodeName;} set {
                    
                if (value is string && value.Length < 20 && value.Length > 0)
                    {
                        locationCodeName = value;
                    }
                else
                    {
                        throw new Exception("The player name you sent is no valid");
                    }} }
                
            public override int X { get {return x;} set {
                    
                if (value > 0)
                    {
                        x = value;
                    }
                else
                    {
                        throw new Exception("XThis is the wrong parameter for a Painting");
                    }} }
            public override int Y { get {return y;} set {
                    
                if (value > 0)
                    {
                        y = value;
                    }
                else
                    {
                        throw new Exception("YThis is the wrong parameter for a Painting");
                    }} }
   
         
            public override int Cost { get {return cost;} set {
                    
                if (value > 0)
                    {
                        cost = value;
                    }
                else
                    {
                        throw new Exception("This is the wrong parameter for a Painting");
                    }} }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override string ToString()
            {
                return $"({this.X}, {this.Y}) => ";
            }


            

            public override void goRight()
            {
                throw new NotImplementedException();
            }

            public override void goUp()
            {
                throw new NotImplementedException();
            }

            public override void goLeft()
            {
                throw new NotImplementedException();
            }

            public override void goDown()
            {
                throw new NotImplementedException();
            }
        
        }


}