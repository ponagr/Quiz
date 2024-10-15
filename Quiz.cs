//Basklass Quiz, med tomma metoder som overridas av underklasserna
public class Quiz
{
    //Listor som kan innehålla 1 eller fler rätta svar / alternativ
    public string Question { get; set; }
    public List<string> Answer { get; set; }
    public int Points { get; set; }
    public List<string> Alternatives { get; set; }  //Låter denna ligga i Quiz trots att den endast används av FlersvarsAlternativ
                                                    //för att förhoppningsvis enkelt kunna spara Quiz-Lista i json-fil senare.

    public virtual int PrintQuestion()
    {
        return 0;
    }

}

public class Fritext : Quiz
{
    public Fritext(string question, List<string> answer, int points)
    {
        Question = question;
        Answer = answer;
        Points = points;
    }

    public override int PrintQuestion() //returnera int eller string?
    {
        int points = 0;
        Console.WriteLine(Question);
        Console.Write("Skriv in ditt svar: ");
        string svar = Console.ReadLine();
        char.ToUpper(svar[0]);
        if (svar == Answer[0])
        {
            Console.WriteLine($"Rätt!");
            points = Points;
        }
        else
        {
            Console.WriteLine("Fel svar!");
            Console.WriteLine($"Rätt svar var {Answer[0]}");
        }

        return points;
    }

    public static void AddQuestion()
    {
        List<string> answer = new List<string>();
        
        Console.WriteLine("Skriv in en fråga:");
        string question = Console.ReadLine();
        char.ToUpper(question[0]);
        Console.WriteLine("Skriv in ett svar:");
        string answerInput = Console.ReadLine();
        char.ToUpper(answerInput[0]);
        answer.Add(answerInput);
        Console.WriteLine("Hur många poäng är frågan värd?");
        int points = int.Parse(Console.ReadLine());

        var nyFråga = new Fritext(question, answer, points);
        QuizHandler.quizzes.Add(nyFråga);
        Console.WriteLine("Ny fråga tillagd");
    }
}

public class FlersvarsAlternativ : Quiz
{
    public FlersvarsAlternativ(string question, List<string> answers, int points, List<string> alternatives)
    {
        Question = question;
        Answer = answers;
        Points = points;
        Alternatives = alternatives;
    }

    public override int PrintQuestion()
    {
        int points = 0;
        int rightAnswers = 0;
        List<string> answers = new List<string>();
        Console.WriteLine(Question);
        for (int i = 0; i < Alternatives.Count; i++)
        {
            Console.WriteLine($"{i+1}. {Alternatives[i]}");
        }
        for (int i = 0; i < Answer.Count; i++)
        {
            Console.Write($"Skriv in svar nr {i+1}: ");
            string svar = Console.ReadLine();
            char.ToUpper(svar[0]);
            answers.Add(svar);
        }  
        for (int i = 0; i < Answer.Count; i++)
        {
            for (int y = 0; y < Answer.Count; y++)
            {
                if (answers[i] == Answer[y])
                {
                    Console.WriteLine($"{answers[i]} var rätt!");
                    rightAnswers++;
                    points = Points;
                }
                else
                {
                    Console.WriteLine($"{answers[i]} var fel svar");
                }
            }
        }
        Console.WriteLine($"Du fick {rightAnswers}/{Answer.Count} rätt");

        return points;
    }

    public static void AddQuestion()
    {
        List<string> answers = new List<string>();
        List<string> alternatives = new List<string>();

        Console.WriteLine("Skriv in en fråga:");
        string question = Console.ReadLine();
        char.ToUpper(question[0]);

        Console.WriteLine("Hur många svarsalternativ vill du lägga till?");
        int ammount = int.Parse(Console.ReadLine());
        for (int i = 0; i < ammount; i++)
        {
            Console.Write($"Skriv in Alternativ {i+1}: ");
            string answer = Console.ReadLine();
            char.ToUpper(answer[0]);
            alternatives.Add(answer);
        }
        Console.WriteLine("Hur många rätta svar ska frågan ha?");
        int answerAmmount = int.Parse(Console.ReadLine());
        for (int i = 0; i < answerAmmount; i++)
        {           
            Console.Write($"Skriv in rätt svar {i+1}: ");
            string answer = Console.ReadLine();
            char.ToUpper(answer[0]);
            answers.Add(answer);
        }
        Console.WriteLine("Hur många poäng är varje rätt svar värt?");
        int points = int.Parse(Console.ReadLine());
        
        var nyFråga = new FlersvarsAlternativ(question, answers, points, alternatives);
        QuizHandler.quizzes.Add(nyFråga);
        Console.WriteLine("Ny fråga tillagd");
    }
}

public class Årtal : Quiz
{
    public Årtal(string question, List<string> answer, int points)
    {
        Question = question;
        Answer = answer;
        Points = points;
    }

    public override int PrintQuestion()
    {
        int points = 0;
        Console.WriteLine(Question);
        Console.Write("Skriv in ditt svar: ");
        string svar = Console.ReadLine();
        char.ToUpper(svar[0]);
        if (svar == Answer[0])
        {
            Console.WriteLine($"Rätt!");
            points = Points;
        }
        else
        {
            Console.WriteLine("Fel svar!");
            Console.WriteLine($"Rätt svar var {Answer[0]}");
        }

        return points;
    }

    public static void AddQuestion()
    {
        List<string> answer = new List<string>();

        Console.WriteLine("Skriv in en fråga:");
        string question = Console.ReadLine();
        Console.WriteLine("Skriv in det rätta årtalet:");
        string answerInput = Console.ReadLine();
        answer.Add(answerInput);
        Console.WriteLine("Hur många poäng är frågan värd?");
        int points = int.Parse(Console.ReadLine());

        var nyFråga = new Fritext(question, answer, points);
        QuizHandler.quizzes.Add(nyFråga);
        Console.WriteLine("Ny fråga tillagd");
    }
}

public class EttTillTio : Quiz
{
    public EttTillTio(string question, List<string> answer, int points)
    {
        Question = question;
        Answer = answer;
        Points = points;
    }

    public override int PrintQuestion()
    {
        int points = 0;
        Console.WriteLine(Question);
        Console.Write("Skriv in ditt svar: ");
        string svar = Console.ReadLine();
        if (svar == Answer[0])
        {
            Console.WriteLine($"Rätt!");
            points = Points;
        }
        else
        {
            Console.WriteLine("Fel svar!");
            Console.WriteLine($"Rätt svar var {Answer[0]}");
        }

        return points;
    }

    public static void AddQuestion()
    {
        List<string> answer = new List<string>();

        Console.WriteLine("Skriv in en fråga:");
        string question = Console.ReadLine();
        char.ToUpper(question[0]);
        string answerInput;
        while (true)
        {
            Console.WriteLine("Skriv in ett svar(mellan 1-10):");
            answerInput = Console.ReadLine();
            int intAnswer = int.Parse(answerInput);
            if (intAnswer < 1 || intAnswer > 10)
            {
                Console.WriteLine("Svaret måste vara mellan 1-10, skriv in ett nytt svar");
                continue;
            }
            else
            {
                break;
            }
        }
        answer.Add(answerInput);
        Console.WriteLine("Hur många poäng är frågan värd?");
        int points = int.Parse(Console.ReadLine());

        var nyFråga = new EttTillTio(question, answer, points);
        QuizHandler.quizzes.Add(nyFråga);
        Console.WriteLine("Ny fråga tillagd");
    }
}

public class EttKryssTvå : Quiz
{
    public EttKryssTvå(string questions, List<string> answer, int points, List<string> alternatives)
    {
        Question = questions;
        Answer = answer;
        Points = points;
        Alternatives = alternatives;
    }

    public override int PrintQuestion()
    {
        return 0;
    }

    public static void AddQuestion()
    {
        List<string> answer = new List<string>();
        List<string> alternatives = new List<string>();

        Console.WriteLine("Skriv in en fråga:");
        string question = Console.ReadLine();
        char.ToUpper(question[0]);
        Console.Write("Skriv in Alternativ 1: ");
        string alt1 = Console.ReadLine();
        Console.Write("Skriv in Alternativ X: ");
        string altX = Console.ReadLine();
        Console.Write("Skriv in Alternativ 2: ");
        string alt2 = Console.ReadLine();
        alternatives.Add(alt1);
        alternatives.Add(altX);
        alternatives.Add(alt2);
        Console.WriteLine("Skriv in det rätta alternativet(1/X/2):");
        string answerInput = Console.ReadLine();
        if (answerInput == "x")
        {
            char.ToUpper(answerInput[0]);
        }
        answer.Add(answerInput);
        Console.WriteLine("Hur många poäng är frågan värd?");
        int points = int.Parse(Console.ReadLine());

        var nyFråga = new EttKryssTvå(question, answer, points, alternatives);
        QuizHandler.quizzes.Add(nyFråga);
        Console.WriteLine("Ny fråga tillagd");
    }
}