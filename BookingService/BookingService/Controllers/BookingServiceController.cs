using BookingService.Models;
using BookingService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    public class BookingServiceController : Controller
    {
        [ApiController]
        [Route("[controller]")]//URL: http://localhost:5066/todo
        public class TodoController : ControllerBase
        {
            private readonly ICrudService<BookingServiceItem, int> _BookingServiceService;
            public TodoController(ICrudService<BookingServiceItem, int> todoService)
            {
                _BookingServiceService = todoService;
            }

            // GET all action
            [HttpGet] // auto returns data with a Content-Type of application/json
            public ActionResult<List<BookingServiceItem>> GetAll() => _BookingServiceService.GetAll().ToList();

            // GET by Id action
            [HttpGet("{id}")]
            public ActionResult<BookingServiceItem> Get(int id)
            {
                var todo = _BookingServiceService.Get(id);
                if (todo is null) return NotFound();
                else return todo;
            }

            // POST action
            [HttpPost]
            public IActionResult Create(BookingServiceItem todo)
            {
                // Runs validation against model using data validation attributes
                if (ModelState.IsValid)
                {
                    _BookingServiceService.Add(todo);
                    return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
                }
                return BadRequest();
            }

            // PUT action
            [HttpPut("{id}")]
            public IActionResult Update(int id, BookingServiceItem todo)
            {
                var existingTodoItem = _BookingServiceService.Get(id);
                if (existingTodoItem is null || existingTodoItem.Id != id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    _BookingServiceService.Update(existingTodoItem, todo);
                    return NoContent();
                }
                return BadRequest();
            }

            // DELETE action
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var todo = _BookingServiceService.Get(id);
                if (todo is null) return NotFound();
                _BookingServiceService.Delete(id);
                return NoContent();
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
