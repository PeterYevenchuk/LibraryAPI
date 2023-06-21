using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BLL.Helpers.PasswordHasher;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : Controller
    {
        private readonly IService<Visitor> _visitorService;
        private readonly IPasswordHash hasher;
        public VisitorController(IService<Visitor> visitorService, IPasswordHash hahser)
        {
            _visitorService = visitorService;
            this.hasher = hahser;
        }

        [HttpGet]
        public ActionResult<List<Visitor>> GetVisitors()
        {
            List<Visitor> visitors = _visitorService.Get();

            return Ok(visitors);
        }

        [HttpGet("{id}")]
        public ActionResult<Visitor> GetVisitor(Guid id)
        {
            var visitor = _visitorService.GetById(id);

            if (visitor == null)
                return NotFound();

            return Ok(visitor);
        }

        [HttpPost("save")]
        public ActionResult InsertVisitor(Visitor visitor)
        {
            visitor.Password = hasher.EncryptPassword(visitor.Password, visitor.ID.ToByteArray());
            bool result = _visitorService.Insert(visitor);
            
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult UpdateVisitor(Visitor visitor)
        {
            bool result = _visitorService.Update(visitor);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
