using ApplicationCore.Commons.Specification;
using ApplicationCore.Models;

namespace ApplicationCore.Specifications;

public class QuizItemsForQuizIdFilledByUser: BaseSpecification<QuizItemUserAnswer>
{
    public QuizItemsForQuizIdFilledByUser(int quizId, int userId) : base(answer => answer.QuizId == quizId && answer.UserId == userId)
    {
        AddInclude(answer => answer.QuizItem);
        AddOrderBy(answer => answer.QuizItem.Id);
    }
}