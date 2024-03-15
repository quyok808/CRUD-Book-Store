using AMS4.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM4.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookRepo _bookRepo;

        public HomeController(BookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public IActionResult Index()
        {
            return View(_bookRepo.GetAll());
        }
    }
}
