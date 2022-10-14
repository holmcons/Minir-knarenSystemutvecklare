namespace MiniräknarenSystemutvecklare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creat a list to save the results from the calculations.
            List<double> list = new List<double>();

            //Creat a bool as an button so you can quit the program from the menu.
            bool programRunning = true;

            while (programRunning)
            {
                Console.Clear();
                Console.WriteLine();
                // Välkomnande meddelande
                Console.WriteLine("Welcome to the calculator!");
                Console.WriteLine("Press 1 for count with the calculator");
                //Vilken typ av uträkning kanske borde finnas i menyvalet???
                Console.WriteLine("Press 2 to see old results");
                Console.WriteLine("Press 3 for quit the program");
                Console.WriteLine();


                Int32.TryParse(Console.ReadLine(), out int menyVal);
                if (menyVal == 1)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("This calculator can do a calculations with two numbers.");
                    double nr1 = 0;
                    double nr2 = 0;
                    double answer = 0;
                    bool loopRunning = true;
                    while (loopRunning)
                    {
                        try
                        { //Börja med siffra, sen vad jag vill räkna med, sen siffra, fortsätt till det trycks på likamed och spara.

                            Console.WriteLine();
                            Console.Write("Write your first number: ");
                            nr1 = double.Parse(Console.ReadLine());
                            loopRunning = false;
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Please, write a number");
                            Console.WriteLine();
                            Console.WriteLine(ex);
                            //Console.ReadKey();
                        }
                    }
                    loopRunning = true;
                    while (loopRunning)
                    {
                        try
                        { //Börja med siffra, sen vad jag vill räkna med, sen siffra, fortsätt till det trycks på likamed och spara.

                            Console.Clear();
                            Console.WriteLine();
                            Console.Write("Write your second number: ");
                            nr2 = double.Parse(Console.ReadLine());
                            loopRunning = false;
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine("Please, write a number");
                            Console.WriteLine();
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
                            Console.WriteLine();
                            Console.WriteLine("Write an operand (+, -, /, *):");
                            oper = char.Parse(Console.ReadLine());
                            if (oper == '+' || oper == '-' || oper == '/' || oper == '*')
                            {
                                loopRunning = false;
                            }
                            else
                                Console.WriteLine("Please, write an operand (+, -, / or *).");

                        }
                       catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine("Please, write an operand (+, -, / or *).");
                            Console.WriteLine();
                            Console.WriteLine(ex);
                            //Console.ReadKey();

                        }
                       
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
                        Console.WriteLine("Din uträkning ser ut som följer: " + nr1 + oper + nr2 + "=" + answer);
                        Console.ReadLine();
                    }
                }
                if (menyVal == 2)
                {
                    try
                    {
                        //for(int)
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Det finns inga uträkningar sparade ännu. Gör en uträkning!");
                        Console.WriteLine(ex);
                    }
                    Console.WriteLine("Tryck på en tangent för att komma tillbaka till menyn.");
                }

                if (menyVal == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Thank you. Bye!");
                    programRunning = false;
                }

                else
                    Console.WriteLine("You need to right 1, 2 or 3.");
                    Console.ReadKey();
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
    
