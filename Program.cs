using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MiniräknarenSystemutvecklare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*General comments
             * This program should follow a design pattern. But i have not enough knowledge and confident to adapt that.
             */

            //Creat a list to save the results from the calculations.
            List<string> list = new List<string>();

            //Creat a bool as an button so you can quit the program from the first menu.
            bool programRunning = true;
            
            double nr1 = 0;
            double nr2 = 0;
            double answer = 0;

            //Creat an while-loop for the first menu that runs in a method. it goes as long as the user choose to quit.
            while (programRunning)
            {
                //Here is the head menu
                FirstMenu();                

                //Handeling errors if the user dosnt write 1, 2 or 3.
                Int32.TryParse(Console.ReadLine(), out int menyVal);
                
                switch (menyVal)
                {
                    case 1:
                        CalculateAndSave();
                        break;
                    
                    case 2:
                        ShowResults();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("\n\n\n\n\t\tThank you. Bye!");
                        programRunning = false;
                        break;
                    
                    default:
                        Console.WriteLine("\n\n\n\n\t\tYou neeed to write 1, 2 or 3.");
                        Console.ReadKey();
                        break;
                }
            }
            void FirstMenu()
            {
                Console.Clear(); //Clears the console window             
                Console.WriteLine("\n\n\n\n\t\tWelcome to the calculator!\n");
                Thread.Sleep(1000);
                Console.WriteLine("\t\tPress 1 for count with the calculator");
                Console.WriteLine("\t\tPress 2 to see old results/answers");
                Console.WriteLine("\t\tPress 3 for quit the program (answer/s are going to be deleted)\n");
                Console.Write("\t\t");
            }
            //Maybe this method sould be better to have as an class and a method/propertie in the class that counts.
            //In that way i dont need to repeat myself and it should follow the "singel responsibility principle" better.
            void CalculateAndSave ()
            {
                Console.Clear();
                Console.Write("\n\n\n\n\t\tThis calculator can do a calculations with two numbers (Press any key to go forward).");
                Console.ReadKey();
                bool loopRunning = true;

                while (loopRunning)
                {
                    //I set a try catch for handeling errors/exeptions.
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
                            //I make another if-statement to give the user a error message when the user are trying to divide by zero.
                            if (nr2 == 0 && oper == '/')
                            {
                                Console.WriteLine("\t\tYou cant divide with 0 (zero).\n\t\tPlease try again.");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                InnerSwitch(nr1, nr2, oper);
                            }
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\tYour calculation are as follow: {0} {1} {2} = {3}", nr1, oper, nr2, answer);
                        saveAnswer = string.Format("{0} {1} {2} = {3}", nr1, oper, nr2, answer);
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
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine("\t\t-------------------------");
                        Console.Write("\t\tNr:" + (i + 1) + "  -  ");
                        Console.WriteLine(list[i]);
                        Thread.Sleep(300);

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
                    //continue; //put a continue so it gose back to the menu
                }
            }
            //This metod is inside the CalculateAndSave-method under the "loop3running" while-loop.
            double InnerSwitch(double nr1, double nr2, char oper)
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

    
