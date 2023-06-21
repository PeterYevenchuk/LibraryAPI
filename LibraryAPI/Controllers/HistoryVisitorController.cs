using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using DAL.Entities.EntitiesPublicationItem;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/historyVisitor")]
    public class HistoryVisitorController : Controller
    {
        private readonly IHistoryVisitorService _historyVisitorService;

        public HistoryVisitorController(IHistoryVisitorService historyVisitorService)
        {
            _historyVisitorService = historyVisitorService;
        }

        [HttpGet("{id}")]
        public ActionResult<List<PublicationItem>> GetHistoryVisitor(Guid id)
        {
            var history = _historyVisitorService.GetHistoryVisitorByID(id);

            if (history == null)
                return NotFound();

            return Ok(history);
        }

        [HttpPut("update")]
        public ActionResult UpdateVisitor(Visitor visitor)
        {
            bool result = _historyVisitorService.UpdateHistoryVisitor(visitor);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
