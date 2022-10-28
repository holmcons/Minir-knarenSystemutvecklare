using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MiniräknarenSystemutvecklare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*General comments and analysis:
             * If this program follows a design pattern that would be great. But i have not enough knowledge and confident
               to adapt that or know if im using one design pattern.

               The program solves simpel countings with two numbers and multiplikation, division, addition and subtraction. 
               It can be more advanced than this calculator. I think the best way is to use bottons as an regular 
               calculator has and the input comes from the mouse.

               If the program would look like an regular calculator. For sure it is off the top of my head at the moment. 
               So its hard for me to contribute whit some creative solutions. 

               Over all im satisfied how the program went out. But i can see that i repeat myself in the code a bit when 
               the user are going to do the number input.
               I belive that i could do a method to make the code less repetitive so it follows the 
               "singel responsibility principle" better.

               Also the method that calculates and saves the calculations should be in two seperate metods 
               (one for calculating and one for saveing) or maybe even better in an own class whit method/properties.

               I think that i have solved all types of error handelings.
             */

            //A list to save the results from the calculations.
            List<string> list = new List<string>();

            //A bool as an button so you can quit the program from the first menu.
            bool programRunning = true;
            
            //Declaration of variables for claculation
            double nr1 = 0;
            double nr2 = 0;
            double answer = 0;
            Console.WriteLine("\n\n\n\n\t\tWelcome to the calculator!\n");
            Thread.Sleep(1800); //Just for fun and design. :)
            //An while-loop for the first menu that runs in a method.
            //It goes as long as the user choose to quit from the menu choice 3. 
            while (programRunning)
            {
                //Here runs method of the head menu
                HeadMenu();                

                //Handeling errors if the user dosnt write 1, 2 or 3.
                Int32.TryParse(Console.ReadLine(), out int menuChoice);
                
                // Switch statement to hold the head menu
                switch (menuChoice)
                {
                    case 1:
                        //Here runs method for calculation and save results
                        CalculateAndSave();
                        break;
                    
                    case 2:
                        //here runs method for showing results from the calculations
                        ShowResults();
                        break;

                    case 3:
                        Console.Clear(); //Clears the console window 
                        Console.WriteLine("\n\n\n\n\t\tThank you. Bye!");
                        Thread.Sleep(500);
                        Console.WriteLine("\t\t(Press any key to exit)");
                        Console.ReadKey(); //Waits for input from the user to go further
                        //Here quits the first while-loop and thereby the program
                        programRunning = false;
                        break;
                    
                    default:
                        //If something else than 1, 2, 3 or 4 writes when the HeadMenu shows this message appears
                        Console.WriteLine("\n\n\n\n\t\tYou need to write 1, 2 or 3.");
                        Console.ReadKey();
                        break;
                }
            }
            void HeadMenu()
            {
                Console.Clear(); //Clears the console window             
                Console.WriteLine("\n\n\n\n\t\tPress 1 for count with the calculator");
                Console.WriteLine("\n\t\tPress 2 to see old results/answers");
                Console.WriteLine("\n\t\tPress 3 for quit the program (answer/s are going to be deleted)\n");
                Console.Write("\n\t\t");
            }
            void CalculateAndSave ()
            {
                Console.Clear();
                Console.Write("\n\n\n\n\t\tThis calculator can do a calculations with two numbers (Press any key to go forward).");
                Console.ReadKey(); //Waits for input from the user to go further
                //A bool for condition and for break the while-loop.
                bool loopRunning = true;
                while (loopRunning)
                {
                    //Try catch for handeling errors/exeptions.
                    try
                    {
                        Console.Clear();
                        Console.Write("\n\n\n\n\t\tWrite your first number and then enter: ");
                        nr1 = double.Parse(Console.ReadLine());
                        loopRunning = false;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\tPress any key for go back and then please write your first number.\n");
                        Thread.Sleep(500);
                        Console.WriteLine("Error message:");
                        Console.WriteLine(ex);
                        Console.ReadKey();
                    }
                }
                //A bool for condition and for break the while-loop.
                bool loop2Running = true;
                while (loop2Running)
                {
                    try
                    {
                        Console.Clear();
                        Console.Write("\n\n\n\n\t\tWrite your second number and then enter: ");
                        nr2 = double.Parse(Console.ReadLine());
                        loop2Running = false;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\tPress any key for go back and then please write your second number.\n");
                        Thread.Sleep(500);
                        Console.WriteLine("Error message:");
                        Console.WriteLine(ex);
                        Console.ReadKey();
                    }
                }
                //A bool for condition and for break the while-loop.
                bool loop3Running = true;
                while (loop3Running)
                {
                    try
                    {
                        string saveAnswer = "";
                        char oper = '0';
                        Console.Clear();
                        Console.Write("\n\n\n\n\t\tChoose an operand (+, -, /, *) to count with: ");
                        oper = char.Parse(Console.ReadLine());
                        //I only whant to use +, -, *or / as an char.
                        //So i make an condition so the if-statement only runs fi the oper is equal to +, -, *or /.
                        if (oper == '+' || oper == '-' || oper == '/' || oper == '*')
                        {
                            //If-statement to give the user a error message when the user are trying to divide by zero.
                            if (nr2 == 0 && oper == '/')
                            {
                                Console.WriteLine("\t\tYou cant divide by 0 (zero).\n\t\tPlease try again.");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                //Calling method whit a switch for counting
                                CalculationSwitch(nr1, nr2, oper);
                            }
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\tYour calculation are as follow: {0} {1} {2} = {3}", nr1, oper, nr2, answer);
                        //Using string.Format to save the entire calculation as an string in variable saveAnswer
                        saveAnswer = string.Format("{0} {1} {2} = {3}", nr1, oper, nr2, answer);
                        //Adding the calculation (string saveAnswer) in the list<string>
                        list.Add(saveAnswer);
                        Console.WriteLine("\t\tYour answer is saved as " + saveAnswer + ". You can see it if you press 2 in the first menu.");
                        Console.ReadKey();
                        loop3Running = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\t\tPlease, press any key and then write an operand (+, -, / or *).");
                            Console.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\tPlease, press any key and then write an operand (+, -, / or *).\n");
                        Thread.Sleep(500);
                        Console.WriteLine("Error message:");
                        Console.WriteLine(ex);
                        Console.ReadKey();
                    }
                }
            }
            void ShowResults()
            {
                if (list.Any()) //Any() method checks if there are anyting in the list. if it is if-statment runs, if it isnt else-statment runs.
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\t\tYour results are as follow:\n");
                    //Here i create an for-loop that gose through the entire list and writes it out.
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine("\t\t-------------------------");
                        Console.Write("\t\tNr:" + (i + 1) + "  -  "); //Shows (index place + 1) for the order of calculations
                        Console.WriteLine(list[i]);//shows what in the index of the list
                        Thread.Sleep(200);
                    }
                    Console.WriteLine("\n\t\tPress any key to go back to the menu.");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\t\tThere are no calculation done yet. Please, do some calculations! " +
                        "\n\t\t(Press any key to go back to the menu)");
                    Console.ReadKey();
                }
            }
            //This metod is inside the CalculateAndSave-method under the "loop3running" while-loop.
            //It sends back answer as an double and it takes double as nr1, double as nr2 and char as oper.
            double CalculationSwitch(double nr1, double nr2, char oper)
            {
                switch (oper)
                {
                    case '+':
                        answer = nr1 + nr2;
                        return answer;

                    case '-':
                        answer = nr1 - nr2;
                        return answer;

                    case '/':
                        answer = nr1 / nr2;
                        return answer;

                    case '*':
                        answer = nr1 * nr2;
                        return answer;
                }
                return answer;
            }
        }
           
    }
}

    
