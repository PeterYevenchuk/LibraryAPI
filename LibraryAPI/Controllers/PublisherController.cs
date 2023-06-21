using DAL.Db.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Publisher = DAL.Entities.EntitiesPublicationItem.Publisher;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IService<Publisher> _publisherService;

        public PublisherController(IService<Publisher> publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public ActionResult<List<Publisher>> Get()
        {
            List<Publisher> addresses = _publisherService.Get();

            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public ActionResult<Publisher> Get(Guid id)
        {
            var publisher = _publisherService.GetById(id);

            if (publisher == null)
                return NotFound();

            return Ok(publisher);
        }

        [HttpPost("save")]
        public ActionResult Insert(Publisher publisher)
        {
            bool result = _publisherService.Insert(publisher);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult Update(Publisher publisher)
        {
            bool result = _publisherService.Update(publisher);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}