using System.IO.Pipes;

namespace MiniräknarenSystemutvecklare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creat a list to save the results from the calculations.
            List<string> list = new List<string>();

            //Creat a bool as an button so you can quit the program from the menu.
            bool programRunning = true;
            //string saveAnswer = "";
            double nr1 = 0;
            double nr2 = 0;
            double answer = 0;

            //Creat an while-loop for the first menu. it can go as long as the user choose to quit.
            while (programRunning)
            {
                Console.Clear(); //Clears the console window             
                Console.WriteLine("\n\n\n\n\t\tWelcome to the calculator!\n");
                Console.WriteLine("\t\tPress 1 for count with the calculator");
                Console.WriteLine("\t\tPress 2 to see old results");
                Console.WriteLine("\t\tPress 3 for quit the program (answer/s are going to be deleted)\n");
                Console.Write("\t\t");

                //Handeling errors if the user dosnt write 1, 2 or 3.
                Int32.TryParse(Console.ReadLine(), out int menyVal);
                
                switch (menyVal)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("\n\n\n\n\t\tThis calculator can do a calculations with two numbers (Press any key to go forward).");
                        Console.ReadKey();
                        bool loopRunning = true;
                        
                        while (loopRunning)
                        {
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
                                Console.WriteLine("\n\n\n\n\t\tPlease, write a number (press any key)\n");
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
                                Console.WriteLine("\n\n\n\n\t\tPlease, write a number (press any key)\n");
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
                                if (oper == '+' || oper == '-' || oper == '/' || oper == '*')
                                {

                                    InnerSwitch(nr1, nr2, oper);
                                    
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\n\n\n\t\tPlease, press any key and then write an operand (+, -, / or *).");
                                    Console.ReadLine();
                                }
                                if (nr2 == 0 && oper == '/')
                                {
                                    Console.WriteLine("\t\tYou cant divide with 0 (zero).\n\t\tPlease try again.");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\n\n\n\t\tYour calculation are as follow: " + nr1 + oper + nr2 + "=" + answer);
                                    saveAnswer = "" + nr1 + oper + nr2 + "=" + answer;
                                    list.Add(saveAnswer);
                                    Console.WriteLine("\t\tYour answer is saved as " + saveAnswer + " and you can see it if you press 2 in the first menu.");
                                    Console.ReadKey();
                                    loop3Running = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine("\n\n\n\n\t\tPlease, press any key and then write an operand (+, -, / or *).\n");
                                Console.WriteLine("Error message:");
                                Console.WriteLine(ex);
                                Console.ReadKey();
                            }
                        }
                        break;
                    
                    case 2:
                        if (list.Any()) //saveAnswer need to have something so this if-statment runs  
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\t\tYour results are as follow:\n");
                            for (int i = 0; i < list.Count; i++)
                            {
                                Console.WriteLine("\t\t-------------------------");
                                Console.Write("\t\tNr:" + (i + 1) + " ");
                                Console.WriteLine(list[i]);
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
                            continue; //put a continue so it gose back to the menu
                        }
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

                    /*default:
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\tPlease, press any key and then write an operand (+, -, / or *).");
                        Console.ReadLine();
                        break;*/
                }
                return answer;
            }
        }
           
    }
}

    
