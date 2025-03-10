using ApplicationCore.Commons.Repository;
using BackendLab01;

namespace ApplicationCore.Models.QuizAggregate;

public class Quiz(int id, List<QuizItem> items, string title) : IIdentity<int>
{
    public int Id { get; set; } = id;

    public string Title { get; } = title;

    public List<QuizItem> Items { get; } = items;
}