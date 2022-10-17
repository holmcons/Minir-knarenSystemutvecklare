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
            string saveAnswer = "";

            while (programRunning)
            {
                Console.Clear();               
                // Välkomnande meddelande
                Console.WriteLine("\n\n\n\n\t\tWelcome to the calculator!\n");
                Console.WriteLine("\t\tPress 1 for count with the calculator");
                //Vilken typ av uträkning kanske borde finnas i menyvalet???
                Console.WriteLine("\t\tPress 2 to see old results");
                Console.WriteLine("\t\tPress 3 for quit the program (answer/s are going to be delete)");
                Console.WriteLine();


                Int32.TryParse(Console.ReadLine(), out int menyVal);
                if (menyVal == 1)
                {
                    Console.Clear();                    
                    Console.WriteLine("\n\n\n\n\t\tThis calculator can do a calculations with two numbers.");
                    double nr1 = 0;
                    double nr2 = 0;
                    double answer = 0;                    
                    bool loopRunning = true;
                    while (loopRunning)
                    {
                        try
                        { //Börja med siffra, sen vad jag vill räkna med, sen siffra, fortsätt till det trycks på likamed och spara.

                            Console.Clear();
                            Console.Write("\n\n\n\n\t\tWrite your first number: ");
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
                    loopRunning = true;
                    while (loopRunning)
                    {
                        try
                        { //Börja med siffra, sen vad jag vill räkna med, sen siffra, fortsätt till det trycks på likamed och spara.

                            Console.Clear();                            
                            Console.Write("\n\n\n\n\t\tWrite your second number: ");
                            nr2 = double.Parse(Console.ReadLine());
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
                    loopRunning = true;
                    while (loopRunning)
                    {
                        char oper = '0';
                        try
                        { //Börja med siffra, sen vad jag vill räkna med, sen siffra, fortsätt till det trycks på likamed och spara.

                            Console.Clear();                            
                            Console.WriteLine("\n\n\n\n\t\tWrite an operand (+, -, /, *):");
                            oper = char.Parse(Console.ReadLine());
                            if (oper != '+' || oper != '-' || oper != '/' || oper != '*')
                            {
                                switch (oper)
                                {
                                    case '+':
                                        answer = nr1 + nr2;
                                        break;

                                    case '-':
                                        answer = nr1 - nr2;
                                        break;

                                    case '/':
                                        answer = nr1 / nr2;
                                        break;

                                    case '*':
                                        answer = nr1 * nr2;
                                        break;

                                    default:
                                        //This message shows up if something else then 1, 2 or 3 rights when the menu is open.

                                        break;

                                }
                                Console.Clear();
                                Console.WriteLine("\n\n\n\n\t\tYour calculation are as follow: " + nr1 + oper + nr2 + "=" + answer);
                                saveAnswer = "" + nr1 + oper + nr2 + "=" + answer;
                                list.Add(saveAnswer);
                                Console.WriteLine("\t\tYour answer is saved as " + saveAnswer + " and you can see it if you press 2 in the first menu.");
                                Console.ReadKey();
                                loopRunning = false;
                            }
                            else
                                Console.WriteLine("\n\n\n\n\t\tPlease, write an operand (+, -, / or *).");

                        }
                       catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\t\tPlease, write an operand (+, -, / or *).");
                            Console.WriteLine();
                            Console.WriteLine(ex);
                            //Console.ReadKey();

                        }                  
                    }
                }
                if (menyVal == 2)
                {
                    Console.Clear();
                    //try
                    //{
                        for (int i =0; i<list.Count; i++)
                        {
                            Console.WriteLine("\n\t--------------------------------------------------------\n");
                            Console.WriteLine("\t\tYour answers are as follow:");
                            Console.Write("\t\tNr:" + (i + 1) + " ");
                            Console.WriteLine(list[i]);
                        }
                    /*}
                    catch (Exception ex)
                    {
                        Console.WriteLine("\n\n\n\n\t\tThere are no calculations saved yet. Please do some calculations!");
                        Console.WriteLine(ex);
                        Console.ReadKey();
                    }
                    */
                    Console.WriteLine("\n\n\n\n\t\tPress any key to go back to the menu.");
                    Console.ReadKey();
                    continue;
                }

                if (menyVal == 3)
                {
                    Console.Clear ();
                    Console.WriteLine();
                    Console.WriteLine("\n\n\n\n\t\tThank you. Bye!");
                    programRunning = false;
                }

                else if (saveAnswer == "")
                {
                    Console.WriteLine("\n\n\n\n\t\tYou need to right 1, 2 or 3.");
                    Console.ReadKey();
                }
            }
            //Created an method to have an menu in the menu
            //It will return witch parameter to count whit
            /*char Countwith();
            {
                //bool
                //while 
               
                Console.WriteLine("Vad vill du räkna med?");
                Console.WriteLine("Press 1 for count with Multiplication");
                Console.WriteLine("Press 2 for count with Division");
                Console.WriteLine("Press 3 for count with Addition");
                Console.WriteLine("Press 4 for count with Subtraction");

                Int32.TryParse(Console.ReadLine(), out int menyVal);

                switch (menyVal)
                {
                    case 1:
                        char multi = '*';
                        break;
                    

                    case 2:
                        char divi = '/';
                        break;

                    case 3:
                        char add = '+';
                        break;

                    case 4:
                        char sub = '-';
                        break;

                        default:
                        //This message shows up if something else then 1, 2, 3 or 4 rights when the menu is open.
                        Console.WriteLine("You need to right 1, 2, 3 or 4.");
                        break;

                }
            }
            */


            // En lista för att spara historik för räkningar

            // Användaren matar in tal och matematiska operation

            //OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!

            // Ifall användaren skulle dela 0 med 0 visa Ogiltig inmatning!

            // Lägga resultat till listan

            //Visa resultat

            //Fråga användaren om den vill visa tidigare resultat.

            //Visa tidigare resultat

            //Fråga användaren om den vill avsluta eller fortsätt
        }
    }
}
    
