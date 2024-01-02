using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObjectBussiness;
using System.Net.Http.Headers;
using System.Text.Json;
using X.PagedList;
using static System.Net.WebRequestMethods;

namespace WebMVC.Areas.Admin.Controllers
{
    public class QuestionController : Controller
    {
        #region Variable
        private readonly HttpClient httpClient;
        private readonly string ApiUrl = "";
        Queue<string> questionsQueue = new Queue<string>();
        #endregion

        #region Constructor
        public QuestionController()
        {
            questionsQueue.Enqueue("Câu hỏi 1");
            questionsQueue.Enqueue("Câu hỏi 2");
            questionsQueue.Enqueue("Câu hỏi 3");
            httpClient = new HttpClient();
            var typeMedia = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(typeMedia);
            ApiUrl = "https://localhost:7274/api/QuestionAPI";
        }
        #endregion

        #region Index
        // GET: QuestionController
        public async Task<ActionResult> Index(int? page)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(ApiUrl);
            var data = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            IPagedList<Question> listQuestions = JsonSerializer.Deserialize<List<Question>>(data, options).ToPagedList(page ?? 1, 5);
            return View(listQuestions);
        }
        #endregion

        #region StartQuiz View
        public async Task<ActionResult> StartQuiz(int id, int? page, string selectedAnswer)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync($"https://localhost:7274/api/QuestionAPI/GetQuestionByExam/{id}");
            var data = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            IPagedList<Question> questions = JsonSerializer.Deserialize<List<Question>>(data, options).ToPagedList(page ?? 1, 1);
            if (questions.Count == 0)
            {
                ViewBag.Message = "No question.";
            }

            HttpResponseMessage responseMessageList = await httpClient.GetAsync(ApiUrl);
            var dataList = await responseMessageList.Content.ReadAsStringAsync();
            var optionsList = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Question> listQuestion = JsonSerializer.Deserialize<List<Question>>(data, options);
            if (listQuestion.Count > 0)
            {
                ViewBag.Count = listQuestion.Count;
            }
            if (selectedAnswer != null)
            {
                HttpResponseMessage responseMessageCheckAnswer = await httpClient.GetAsync($"https://localhost:7274/api/QuestionAPI/CheckAnswer/{selectedAnswer}");
                var dataAnswer = await responseMessageCheckAnswer.Content.ReadAsStringAsync();
                var optionsAnswer = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                int answer = JsonSerializer.Deserialize<int>(dataAnswer, optionsAnswer);
                TempData["Score"] = answer;

                int pageNumber = 1;
                if (pageNumber < listQuestion.Count)
                {
                    pageNumber++;
                    return RedirectToAction("StartQuiz", new { id = id, page = pageNumber });
                }
                else
                {
                    return RedirectToAction("StartQuiz", new { id = id, page = listQuestion.Count });
                }

            }
            return View(questions);
        }
        #endregion

        #region StartQuiz Post
        [HttpPost]
        public async Task<Question> StartQuiz(Question question, string selectedAnswer)
        {
            int score = 0;
            if (selectedAnswer != null)
            {
                if (selectedAnswer == "")
                {

                }
            }
            return question;
        }
        #endregion

        #region Result
        public async Task<ActionResult> Result()
        {
            return View();
        }
        #endregion
    }
}
