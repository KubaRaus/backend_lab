using Microsoft.AspNetCore.Mvc;
using BackendLab01;
using ApplicationCore.Models.QuizAggregate;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/quizzes")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizUserService _service;

        public QuizController(IQuizUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Quiz>> GetAllQuizzes()
        {
            var quizzes = _service.FindAllQuizzes();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public ActionResult<Quiz> GetQuizById(int id)
        {
            var quiz = _service.FindQuizById(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDto> FindById(int id)
        {
            var quiz = _service.FindQuizById(id);
            if (quiz == null)
            {
                return NotFound();
            }

            var quizDto = QuizDto.Of(quiz);
            return Ok(quizDto);
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<QuizDto>> FindAll()
        {
            var quizzes = _service.FindAllQuizzes();
            var quizDtos = quizzes.Select(QuizDto.Of).ToList();
            return Ok(quizDtos);
        }
        
        [HttpPost]
        [Route("{quizId}/items/{itemId}")]
        public IActionResult SaveAnswer(int quizId, int itemId, [FromBody] QuizItemAnswerDto dto)
        {
            _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);
            return Ok();
        }
        
        [HttpGet]
        [Route("{quizId}/users/{userId}/answers")]
        public ActionResult<QuizUserAnswerDto> GetUserAnswersForQuiz(int quizId, int userId)
        {
            var correctAnswersCount = _service.CountCorrectAnswersForQuizFilledByUser(quizId, userId);
            var userAnswerDto = new QuizUserAnswerDto
            {
                QuizId = quizId,
                UserId = userId,
                CorrectAnswersCount = correctAnswersCount
            };
            return Ok(userAnswerDto);
        }
    }
}