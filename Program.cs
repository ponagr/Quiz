class Program
{
    //TODO: Fixa så att svaren får stor bokstav i början, och lägg till Console.Clear() i slutet på alla PrintQuestion()

    static void Main(string[] args)
    {
        QuizHandler.LoadJson();
        bool runMenu = true;

        while (runMenu)
        {
            Console.Clear();
            Console.WriteLine("1. Lägg till en fråga");
            Console.WriteLine("2. Kör Quiz");
            Console.WriteLine("0. Avsluta Program");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    //Metod för att lägga till fråga
                    QuizHandler.AddQuestionMenu();
                    QuizHandler.SaveJson();
                    break;
                case 2:
                    //Metod för att köra quiz
                    QuizHandler.RunQuiz();
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