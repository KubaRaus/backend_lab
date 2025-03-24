using ApplicationCore.Models.QuizAggregate;

namespace WebAPI.Dto;

public class QuizItemDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<string> Options { get; set; }
    
    public static QuizItemDto of(QuizItem quiz)
    {
        return new QuizItemDto()
        {
            Id = quiz.Id,
            Question = quiz.Question,
            Options = quiz.IncorrectAnswers
                .Concat(new[] { quiz.CorrectAnswer })
                .OrderBy(option => option)
                .ToList()
        };
    }
    
}