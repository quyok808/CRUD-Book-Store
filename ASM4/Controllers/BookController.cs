using AMS4.Data;
using AMS4.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMS4.Controllers
{
    public class BookController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly BookRepo _bookRepo;

        public BookController(IWebHostEnvironment environment, BookRepo bookRepo)
        {
            _environment = environment;
            _bookRepo = bookRepo;
        }

        public IActionResult Index()
        {
            return View(_bookRepo.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = _bookRepo.GetAll().Count > 0 ? _bookRepo.GetAll().Max(p => p.Id) + 1 : 1;
                if (book.FileUpload != null && book.FileUpload.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, "imgs");
                    var filePath = Path.Combine(uploadsFolder, book.Id + ".jpg");
                    book.Image = book.Id + ".jpg";
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await book.FileUpload.CopyToAsync(fileStream);
                    }
                }
                _bookRepo.Insert(book);
                return View("Index", _bookRepo.GetAll());
            }
            return View("Create", book);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Book? book = _bookRepo.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book item)
        {
            
            _bookRepo.Delete(item.Id);
            return View("Index", _bookRepo.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book? book = _bookRepo.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book edit)
        {
            if (edit.FileUpload != null && edit.FileUpload.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "imgs");
                var filePath = Path.Combine(uploadsFolder, edit.Id + ".jpg");
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await edit.FileUpload.CopyToAsync(fileStream);
                }
            }
            edit.Image = edit.Id + ".jpg";
            _bookRepo.Update(edit);
            return View("Index", _bookRepo.GetAll());
        }

        public IActionResult Details(int id)
        {
            Book? book = _bookRepo.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
    }
}
