using Microsoft.AspNetCore.Mvc;
using VivesBlog.Model.Dto;
using VivesBlog.Sdk;

namespace VivesBlog.Ui.Presentation.Controllers
{
    public class PeopleController : Controller
    {
        private readonly VivesBlogApiClient _apiClient;

        public PeopleController(VivesBlogApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var people = await _apiClient.GetPeople();
            return View(people);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var authors = await _apiClient.GetPeople();
            ViewBag.Authors = authors;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _apiClient.CreatePerson(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var person = await _apiClient.GetPerson(id);
            if (person is null)
            {
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] PersonDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _apiClient.UpdatePerson(id, dto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[controller]/Delete")]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int id)
        {
            await _apiClient.DeletePerson(id);
            return RedirectToAction("Index");
        }
    }
}