namespace MiniräknarenSystemutvecklare
{
    internal class Program
    {
        static void Main(string[] args)
        {       
            bool programRunning = true;

            while (programRunning)
            {
                Console.Clear();
                // Välkomnande meddelande
                Console.WriteLine("Välkommen till miniräknaren!");
                Console.WriteLine("Skriv 1 för att använda miniräknaren");
                Console.WriteLine("Skriv 2 för att se tidigare resultat");
                Console.WriteLine("Skriv 3 för att avsluta programmet");
                Console.WriteLine("");
                Console.WriteLine("");

                Int32.TryParse(Console.ReadLine(), out int menyVal);

                switch (menyVal)
                {
                    case 1:
                        break;

                    case 2:
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
                        break;

                    case 3: //Här avslutas while-loopen och där med även programmet.
                        programRunning = false;
                        break;

                    default:
                        //Detta skrivs ut om någonting annat än 1, 2 eller 3 skrivs när menyn är uppe.
                        Console.WriteLine("Du måste skriva 1, 2 eller 3.");
                        break;

                }
                Console.ReadLine();
            }


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