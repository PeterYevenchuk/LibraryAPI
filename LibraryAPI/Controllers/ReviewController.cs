using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IService<Review> _reviewService;

        public ReviewController(IService<Review> reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public ActionResult<List<Review>> Get()
        {
            List<Review> reviews = _reviewService.Get();

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public ActionResult<Review> Get(Guid id)
        {
            var review = _reviewService.GetById(id);

            if (review == null)
                return NotFound();

            return Ok(review);
        }

        [HttpPost("save")]
        public ActionResult Insert(Review review)
        {
            bool result = _reviewService.Insert(review);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult Update(Review review)
        {
            bool result = _reviewService.Update(review);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
