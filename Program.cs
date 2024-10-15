class Program
{
    static void Main(string[] args)
    {
        bool runMenu = true;

        while (runMenu)
        {
            Console.WriteLine("1. Lägg till en fråga");
            Console.WriteLine("2. Kör Quiz");
            Console.WriteLine("0. Avsluta Program");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    //Metod för att lägga till fråga
                    break;
                case 2:
                    //Metod för att köra quiz
                    break;
                case 0:
                    //Avsluta programmet
                    runMenu = false;
                    break;
                default:
                    Console.WriteLine("Något blev fel");
                    break;
            }
        }
    }
}