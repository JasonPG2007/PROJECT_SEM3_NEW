using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebMVC.Controllers
{
    public class QuestionController : Controller
    {
        private HttpClient httpClient;
        private string ApiUrl = "";
        public QuestionController()
        {
            httpClient = new HttpClient();
            var typeMedia = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(typeMedia);
            ApiUrl = "https://localhost:7274/api/Question";
        }
        // GET: QuestionMVCController
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(ApiUrl);
            var data = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Test> questionsList = JsonSerializer.Deserialize<List<Test>>(data, options);
            return View(questionsList);
        }

        // GET: QuestionMVCController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuestionMVCController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionMVCController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Test question)
        {
            try
            {
                Random random = new Random();
                question.TestID = random.Next();
                var data = JsonSerializer.Serialize(question);
                var typeData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(ApiUrl, typeData);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new ArgumentException("Created failed.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: QuestionMVCController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync($"{ApiUrl}/{id}");
            var data = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Test questions = JsonSerializer.Deserialize<Test>(data, options);
            return View(questions);
        }

        // POST: QuestionMVCController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Test question)
        {
            try
            {
                var data = JsonSerializer.Serialize(question);
                var typeData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await httpClient.PutAsync($"{ApiUrl}/{id}", typeData);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new ArgumentException("Updated failed.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: QuestionMVCController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync($"{ApiUrl}/{id}");
            var data = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Test questions = JsonSerializer.Deserialize<Test>(data, options);
            return View(questions);
        }

        // POST: QuestionMVCController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.DeleteAsync($"{ApiUrl}/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new ArgumentException("Deleted failed.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
