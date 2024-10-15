//Klass för att enkelt kunna ge varje svar ett tillhörande poäng
public class Answer
{
    public string RightAnswer { get; set; }
    public int PointPerAnswer { get; set; }

    public Answer(string answer, int points)
    {
        RightAnswer = answer;
        PointPerAnswer = points;
    }
}

//Basklass Quiz, med tomma metoder som overridas av underklasserna
public class Quiz
{
    //Listor som kan innehålla 1 eller fler rätta svar / alternativ
    public string Question { get; set; }
    public List<Answer> Answer { get; set; }
    public List<string> Alternatives { get; set; }  //Låter denna ligga i Quiz trots att den endast används av FlersvarsAlternativ
                                                    //för att förhoppningsvis enkelt kunna spara Quiz-Lista i json-fil senare.

    public virtual void PrintQuestion()
    {

    }
    public virtual void AddQuestion()
    {

    }
}

public class Fritext : Quiz
{
    public Fritext(string question, List<Answer> answer)
    {
        Question = question;
        Answer = answer;
    }

    public override void PrintQuestion()
    {

    }

    public override void AddQuestion()
    {
        
    }
}

public class FlersvarsAlternativ : Quiz
{
    public FlersvarsAlternativ(string question, List<Answer> answers, List<string> alternatives)
    {
        Question = question;
        Answer = answers;
        Alternatives = alternatives;
    }

    public override void PrintQuestion()
    {

    }

    public override void AddQuestion()
    {
        
    }
}

public class Årtal : Quiz
{
    public Årtal(string question, List<Answer> answer)
    {
        Question = question;
        Answer = answer;
    }

    public override void PrintQuestion()
    {

    }

    public override void AddQuestion()
    {
        
    }
}

public class EttTillTio : Quiz
{
    public EttTillTio(string question, List<Answer> answer)
    {
        Question = question;
        Answer = answer;
    }

    public override void PrintQuestion()
    {

    }

    public override void AddQuestion()
    {
        
    }
}

public class EttKryssTvå : Quiz
{
    public EttKryssTvå(string questions, List<Answer> answer)
    {
        Question = questions;
        Answer = answer;
    }

    public override void PrintQuestion()
    {

    }

    public override void AddQuestion()
    {
        
    }
}