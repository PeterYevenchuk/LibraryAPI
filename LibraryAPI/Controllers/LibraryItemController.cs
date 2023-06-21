using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryItemController : Controller
    {
        private readonly IService<LibraryItem> _libraryItemService;

        public LibraryItemController(IService<LibraryItem> libraryItemService)
        {
            _libraryItemService = libraryItemService;
        }

        [HttpGet]
        public ActionResult<List<LibraryItem>> Get()
        {
            List<LibraryItem> libraryItems = _libraryItemService.Get();

            return Ok(libraryItems);
        }

        [HttpGet("{id}")]
        public ActionResult<LibraryItem> Get(Guid id)
        {
            var libraryItem = _libraryItemService.GetById(id);

            if (libraryItem == null)
                return NotFound();

            return Ok(libraryItem);
        }

        [HttpPost("save")]
        public ActionResult Insert(LibraryItem libraryItem)
        {
            bool result = _libraryItemService.Insert(libraryItem);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult Update(LibraryItem libraryItem)
        {
            bool result = _libraryItemService.Update(libraryItem);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
