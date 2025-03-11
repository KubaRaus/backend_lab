using ApplicationCore.Models.QuizAggregate;

namespace WebAPI.Dto;

public class QuizItemDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<string> Options { get; set; }

    public static QuizItemDto Of(QuizItem quizItem)
    {
        var options = new List<string>(quizItem.IncorrectAnswers)
        {
            quizItem.CorrectAnswer
        };

        // Shuffle the options
        var random = new Random();
        options = options.OrderBy(_ => random.Next()).ToList();

        return new QuizItemDto
        {
            Id = quizItem.Id,
            Question = quizItem.Question,
            Options = options
        };
    }
}
public class QuizDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<QuizItemDto> Items { get; set; }

    public static QuizDto Of(Quiz quiz)
    {
        return new QuizDto
        {
            Id = quiz.Id,
            Title = quiz.Title,
            Items = quiz.Items.Select(QuizItemDto.Of).ToList()
        };
    }
}

public class QuizItemAnswerDto
{
    public int UserId { get; set; }
    public string Answer { get; set; }
}
public class QuizUserAnswerDto
{
    public int QuizId { get; set; }
    public int UserId { get; set; }
    public int CorrectAnswersCount { get; set; }
}
