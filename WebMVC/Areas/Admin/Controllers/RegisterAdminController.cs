using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBussiness;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RegisterAdminController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly string ApiUrl = "";
        public RegisterAdminController()
        {
            httpClient = new HttpClient();
            var type = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(type);
            ApiUrl = "https://localhost:7274/api/ExamRegisterAPI";
        }
        // GET: RegisterAdminController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(ExamRegister examRegister, string password)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                Account account = new Account();

                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                var gender = Request.Form["gender"];
                Random random = new Random();
                examRegister.ExamRegisterID = random.Next();
                if (gender == "Male")
                {
                    examRegister.Gender = true;
                }
                else
                {
                    examRegister.Gender = false;
                }
                var data = JsonSerializer.Serialize(examRegister);
                var typeData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(ApiUrl, typeData);
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["msg"] = "Register successfully.";
                    return Redirect("~/Admin/RegisterAdmin/Register");
                }
                throw new ArgumentException("Register failed!");
                //}
                //return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // GET: RegisterAdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegisterAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterAdminController/Create
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

        // GET: RegisterAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegisterAdminController/Edit/5
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

        // GET: RegisterAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterAdminController/Delete/5
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
