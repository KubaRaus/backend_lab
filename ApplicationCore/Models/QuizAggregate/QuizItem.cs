using ApplicationCore.Commons.Repository;

namespace ApplicationCore.Models.QuizAggregate;

public class QuizItem(int id, string question, List<string> incorrectAnswers, string correctAnswer)
    : IIdentity<int>
{
    public int Id { get; set; } = id;
    public string Question { get; } = question;
    public List<string> IncorrectAnswers { get; } = incorrectAnswers;
    public string CorrectAnswer { get;  } = correctAnswer;
}