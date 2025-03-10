using ApplicationCore.Commons.Specification;
using ApplicationCore.Models.QuizAggregate;
using BackendLab01;

namespace ApplicationCore.Specifications;

public class QuizItemByQuestion: BaseSpecification<QuizItem>
{
    public QuizItemByQuestion(string question): base(item => item.Question == question)
    {
        AddInclude(item => item.IncorrectAnswers);
    }
}