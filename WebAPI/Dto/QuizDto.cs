using ApplicationCore.Models.QuizAggregate;

namespace WebAPI.Dto;

public class QuizDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<QuizItemDto> Items { get; set; }

    public static QuizDto of(Quiz quiz)
    {
        return new QuizDto()
        {
            Id = quiz.Id,
            Title = quiz.Title,
            Items = quiz.Items.Select(QuizItemDto.of).ToList()
        };
    }
}