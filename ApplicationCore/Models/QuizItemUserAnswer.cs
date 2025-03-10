using ApplicationCore.Commons.Repository;
using ApplicationCore.Models.QuizAggregate;

namespace ApplicationCore.Models;

public class QuizItemUserAnswer(QuizItem quizItem, int userId, int quizId, string answer)
    : IIdentity<string>
{
    public int QuizId { get; } = quizId;
    public QuizItem  QuizItem{ get; } = quizItem;
    public int UserId { get; } = userId;
    public string Answer { get; } = answer;

    public bool IsCorrect()
    {
        return QuizItem.CorrectAnswer == Answer;
    }

    public string Id
    {
        get => $"{QuizId}-{UserId}-{QuizItem.Id}";
        set
        {
            
        }
    }
}