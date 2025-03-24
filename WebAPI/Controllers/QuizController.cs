using BackendLab01;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Route("{id}")]
        public ActionResult<QuizDto> FindById(int id)
        {
            var quiz = _service.FindQuizById(id);
            if (quiz is null)
            {
                return NotFound();
            }

            var quizDto = QuizDto.of(quiz);
            return Ok(quizDto);
        }
        
        // GET: api/<QuizController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        public IEnumerable<QuizDto> FindAll()
        {
            return _service.findAllQuizzes().Select(u=>QuizDto.of(u));
        }
        
        // POST api/<QuizController>
        [HttpPost]
        [Route("{quizId}/items/{itemId}")]
        public void SaveAnswer([FromBody] QuizItemAnswerDto dto, [FromRoute] int quizId, [FromRoute] int itemId)
        {
            _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);
        }
        
        [HttpGet]
        [Route("{quizId}/users/{userId}/answer-info")]
        public ActionResult<QuizAnswerInfoDto> GetUserQuizAnswerInfo(int quizId, int userId)
        {
            var correctAnswersCount = _service.CountCorrectAnswersForQuizFilledByUser(quizId, userId);
            var answerInfoDto = new QuizAnswerInfoDto
            {
                QuizId = quizId,
                UserId = userId,
                CorrectAnswersCount = correctAnswersCount
            };
            return Ok(answerInfoDto);
        }
        
    }
}
