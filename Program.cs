using System;
using System.Collections.Generic;

namespace Project0
{
    class Program
    {

        static Project0RepoLayer p0Context = new Project0RepoLayer(); // create the context here to acceess it in all methods of this class
        static void Main(string[] args)

        
        {
//Manually create a floor for database. You cannot add a user until database has at least one BaseFloor

        // BaseFloor smallExhbit = new BaseFloor("SoriaMoriaExhibit", 5, 40);


        //  Console.WriteLine("Exit");
        // Console.ReadLine();

//^^ creates new floor

            // variables
            Console.Clear();
            string usrChoice;

            do {//enter program

            //greet user and see where they need to go. quit if an option listed isn't inputted
            Console.WriteLine
            ("Welcome to the Abstract Museum, where we abstract out abstract art! What would you like to do?\n"+
            "1. Create User \n2. Login\n-1. Quit");
         
            usrChoice = Console.ReadLine();//get user choice

            //initializing user inputs
            string un="0";  //globawe uname outside loop to use later


            while(usrChoice=="1")
            { 
                //init ui
                string fn="0";
                string ln="0";
                while (usrChoice!="-2")
                    {while((un=="0" || fn=="0" || ln=="0") && (usrChoice!="-2")) { 
                        
                    //loop create player until acceptable values are given
                    ///prompt for information to create player
                        Console.Clear();
                        Console.WriteLine("We need some information before we can proceed: "+
                        "\nPlease make sure that that all three inputs contain at least 3 characters and no more than 20!");
                                                    
                        Console.Write("\nEnter a unique username: ");
                        un=ValidationOptions.ValidateInput(Console.ReadLine()); 
                        Console.Write("\nEnter your first name: ");
                        fn=ValidationOptions.ValidateInput(Console.ReadLine()); 
                        Console.Write("\nEnter your last name: ");
                        ln =ValidationOptions.ValidateInput(Console.ReadLine()); 
                        
                        Console.Write("\nIf you entered less than 2 or more than 20 characters for any inputs, we will prompt you to enter your information again. \nPress enter to continue...");
                        Console.ReadLine();
                        
                        Console.Clear();
                        Console.WriteLine("We are creating user with"+
                        $"\nUsername: {un} \nFirst Name: {fn} \nLast Name: {ln}");
                        
                        Console.Write("\nIf you'd like to cancel, enter -2:");
                        usrChoice=Console.ReadLine();
                        if (usrChoice=="-2"){
                            un="0";
                            ln="0";
                            fn="0";
                        }
                }usrChoice="-2";}
                
    
                
            if(un!="0"||fn!="0"||ln!="0"){
                User user=p0Context.CreateUser(un,fn,ln);
                SignedIn.FirstMenu(user);
                usrChoice="-1";
            }

            }

            
            while(usrChoice=="2"){


            Console.Write("Great to see you again! You can quit to the main menu by entering '-1'. Enter your unique username: ");
            un = Console.ReadLine(); 
               if(un!="-1"){
                try
                {
                un=ValidationOptions.ValidateInput(un); 
                User user= p0Context.FindUser(un);
                
                usrChoice=SignedIn.FirstMenu(user);
                }
                catch (System.Exception)
                {   
                    Console.Clear();
                    Console.WriteLine("We were not able to locate that user.\n We will return you to the previous screen. Press enter to continue: ");
                    Console.ReadLine();
                    usrChoice="2";
                }}
                else{
                    Console.Clear();
                    usrChoice="-1";
                }







            }
        }while(usrChoice!="-1");//end program

        Console.Clear();
        Console.Write("Thank you for your virtual stay at the Abstract Museum!");
        
        


    }//end main


//helper to generate matrix
    public static int[,] generateMatrix(int x){
        int[,] array = new int[x, x];
        return array;

}//end generator helper


//helper to print matrix
     public static void Print2DArray<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }// matrix printer helper

    //helper class to assist with options passed sing up/in
    static class SignedIn

    {   
        public static string FirstMenu(User u){
        string usrChoice;

        do{
            Console.Clear();
            Console.WriteLine($"Welcome {u.Username}! Enter -1 to quit. "+
            "What would you like to do?"+
            "\n3. View Floor"+
            "\n4. Book a tour"+
            "\n-1. Logout" );
            usrChoice=Console.ReadLine();
            
            if(usrChoice=="3"){
                Console.WriteLine("How many rows does the floor you want to look at have? No more than 6! ");
                int n = ValidationOptions.ValidateStringToInt(Console.ReadLine());
                Console.Clear();
                if (n<7 && n>0){
                Print2DArray(generateMatrix(n));}

                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                usrChoice="-1";
            }
            if(usrChoice=="4"){


            }


        }while(usrChoice!="-1");
            
        return "-2";

            
        }

    }//end sign in helper


//helper class to validate inputs
    static class ValidationOptions 

    {
    static public int ValidateStringToInt(string arg)
            {
                try
                {
                    int result;
                    bool usrOut=int.TryParse(arg, out result);
                    return result;   
                }
                catch (System.Exception)
                {
                    return -1;
                }
                

            }

    static public string ValidateInput(string arg)
     {
            try
                
            { 
                   arg = string.Join("", arg.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                   if((arg.Length>2 && arg.Length<20)) 
                    { return arg; 
                    } else{return "0";}
            }catch (System.Exception)

                {   Console.Clear();
                    throw new Exception("\nYou did not enter a correct a input please try again.");}
    }
}//end validation helper


    

}}
