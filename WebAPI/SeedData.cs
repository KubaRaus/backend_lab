using ApplicationCore.Commons.Repository;
using ApplicationCore.Models.QuizAggregate;
using BackendLab01;

namespace Infrastructure.Memory;

public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            
            List<QuizItem> mathQuizItems = new List<QuizItem>();

            mathQuizItems.Add(quizItemRepo.Add(new QuizItem(id: 1, correctAnswer: "6", question: "2 + 4",
                incorrectAnswers: new List<string>() { "5", "7", "8" })));
            mathQuizItems.Add(quizItemRepo.Add(new QuizItem(id: 2, correctAnswer: "8", question: "2 * 4",
                incorrectAnswers: new List<string>() { "4", "6", "9" })));
            mathQuizItems.Add(quizItemRepo.Add(new QuizItem(id: 3, correctAnswer: "4", question: "8 / 2",
                incorrectAnswers: new List<string>() { "5", "7", "8" })));
            quizRepo.Add(new Quiz(id: 1, items: mathQuizItems, title: "Matematyka"));
            
            List<QuizItem> historyQuizItems = new List<QuizItem>();

            historyQuizItems.Add(quizItemRepo.Add(new QuizItem(id: 6, correctAnswer: "1945",
                question: "When did World War II end?",
                incorrectAnswers: new List<string>() { "1939", "1941", "1950" })));
            historyQuizItems.Add(quizItemRepo.Add(new QuizItem(id: 7, correctAnswer: "Julius Caesar",
                question: "Who was assassinated on the Ides of March?",
                incorrectAnswers: new List<string>() { "Augustus", "Nero", "Caligula" })));
            quizRepo.Add(new Quiz(id: 2, items: historyQuizItems, title: "Historia"));

            List<QuizItem> scienceQuizItems = new List<QuizItem>();

            scienceQuizItems.Add(quizItemRepo.Add(new QuizItem(id: 8, correctAnswer: "H2O",
                question: "What is the chemical formula for water?",
                incorrectAnswers: new List<string>() { "CO2", "O2", "H2" })));
            scienceQuizItems.Add(quizItemRepo.Add(new QuizItem(id: 9, correctAnswer: "Einstein",
                question: "Who developed the theory of relativity?",
                incorrectAnswers: new List<string>() { "Newton", "Galileo", "Curie" })));
            quizRepo.Add(new Quiz(id: 3, items: scienceQuizItems, title: "Nauka"));
        }
    }
}