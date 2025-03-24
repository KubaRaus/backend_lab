namespace WebAPI.Dto;

public class QuizAnswerInfoDto
{
    public int QuizId { get; set; }
    public int UserId { get; set; }
    public int CorrectAnswersCount { get; set; }
}