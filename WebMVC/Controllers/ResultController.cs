using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebMVC.Controllers
{
    public class ResultController : Controller
    {
        private HttpClient httpClient;
        private string ApiUrlResult = "";
        public ResultController()
        {
            httpClient = new HttpClient();
            var typeMedia = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(typeMedia);
            ApiUrlResult = "https://localhost:7274/api/Result";
        }
        // GET: ResultController
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(ApiUrlResult);
            var data = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Result> questionsList = JsonSerializer.Deserialize<List<Result>>(data, options);
            return View(questionsList);
        }

        // GET: ResultController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResultController/Create
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(ApiUrlResult);
            var data = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Result> listResult = JsonSerializer.Deserialize<List<Result>>(data, options);
            ViewBag.LIST = listResult;
            return View();
        }

        // POST: ResultController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResultController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResultController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResultController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResultController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
