using System.Text.Json;

public static class QuizHandler
{
    public static List <Quiz> quizzes = new List<Quiz>();
    public static List <Quiz> answeredQuizzes = new List<Quiz>();

    public static void AddQuestionMenu()
    {
        Console.Clear();
        Console.WriteLine("Lägg till en fråga:");
        Console.WriteLine("1. Fritext");
        Console.WriteLine("2. 1,X,2");
        Console.WriteLine("3. Flersvarsalternativ");
        Console.WriteLine("4. Årtal");
        Console.WriteLine("5. 1-10");
        Console.WriteLine("0. Gå tillbaka");

        int answer = int.Parse(Console.ReadLine());

        switch (answer)
        {
            case 1:
                Fritext.AddQuestion();
                break;
            case 2:
                EttKryssTvå.AddQuestion();
                break;
            case 3:
                FlersvarsAlternativ.AddQuestion();
                break;
            case 4:
                Årtal.AddQuestion();
                break;
            case 5:
                EttTillTio.AddQuestion();
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Något gick fel");
                break;
        }
    }

    public static void RunQuiz()
    {
        if (quizzes.Count == 0)
        {
            Console.WriteLine("Det finns inga frågor tillagda.");
            return;
        }
        
        Random random = new Random();
        int playerPoints = 0;
        int maxPoints = 0;

        Console.WriteLine($"Hur många frågor vill du ha? (max antal frågor är {quizzes.Count})");
        int antalFrågor = int.Parse(Console.ReadLine());
        if (antalFrågor > quizzes.Count)
        {
            Console.WriteLine($"Du kan max välja {quizzes.Count} frågor");
        }
        else
        {
            for (int i = 0; i < antalFrågor; i++)   //visar så många frågor som användaren har angett
            {
                int quizIndex = random.Next(0, quizzes.Count);   //slumpar fram frågor ur quizzes
                //anropa PrintQuestion() för att se och svara på slumpad fråga
                playerPoints += quizzes[quizIndex].PrintQuestion(); 

                //Lägg till varje frågas points i maxPoints
                //Lägg till värdet för varje rätt svar * så många rätta svar frågan har
                for (int y = 0; y < quizzes[quizIndex].Answer.Count; y++)
                {
                    maxPoints += quizzes[quizIndex].Points;
                }
                //Lägg sedan till frågan i answeredQuizzes och ta sedan bort den från quizzes så att användaren inte kan få samma fråga igen
                answeredQuizzes.Add(quizzes[quizIndex]);
                quizzes.RemoveAt(quizIndex);
            }
        }
        Console.WriteLine($"Du fick {playerPoints}/{maxPoints} poäng");
        Console.ReadKey();
    }

    public static void SaveJson()
    {
        string fileName = "quizzes.json";
        string jsonString = JsonSerializer.Serialize(quizzes);
        File.WriteAllText(fileName, jsonString);
    }
    public static void LoadJson()
    {
        string fileName = "quizzes.json";
        string jsonString = File.ReadAllText(fileName);
        quizzes = JsonSerializer.Deserialize<List<Quiz>>(jsonString);
    }
}