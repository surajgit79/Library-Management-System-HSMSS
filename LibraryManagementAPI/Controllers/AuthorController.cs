using LibraryManagementAPI.Models;
using LibraryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authors = _authorService.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
                return NotFound("Author not found");
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Author author)
        {
            _authorService.AddAuthor(author);
            return Ok("Author saved successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Author author)
        {
            var existing = _authorService.GetAuthorById(id);
            if (existing == null)
                return NotFound("Author not found");

            author.AuthorId = id;
            _authorService.UpdateAuthor(author);
            return Ok("Author updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _authorService.GetAuthorById(id);
            if (existing == null)
                return NotFound("Author not found");

            _authorService.DeleteAuthor(id);
            return Ok("Author deleted successfully");
        }
    }
}