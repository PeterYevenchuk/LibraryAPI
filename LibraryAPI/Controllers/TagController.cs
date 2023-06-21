using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly IService<Tag> _tagService;

        public TagController(IService<Tag> tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public ActionResult<List<Tag>> GetTags()
        {
            List<Tag> tags = _tagService.Get();

            return Ok(tags);
        }

        [HttpPost("save")]
        public ActionResult InsertTag(Tag tag)
        {
            bool result = _tagService.Insert(tag);
            if (result)
                return Ok();

            return BadRequest();
        }

    }
}