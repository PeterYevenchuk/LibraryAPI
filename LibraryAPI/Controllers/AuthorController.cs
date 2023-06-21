using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IService<Author> _authorService;

        public AuthorController(IService<Author> authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public ActionResult<List<Author>> GetVisitors()
        {
            List<Author> authors = _authorService.Get();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Author>> GetAuthorByID(Guid id)
        {
            var author = _authorService.GetById(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost("save")]
        public ActionResult InsertVisitor(Author author)
        {
            bool result = _authorService.Insert(author);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult UpdateVisitor(Author author)
        {
            bool result = _authorService.Update(author);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
