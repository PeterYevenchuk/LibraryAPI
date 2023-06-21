using BLL.Services.BanSystem;
using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlockedSubscriptionController : ControllerBase
{
    private readonly IService<Visitor> _visitorService;

    public BlockedSubscriptionController(IService<Visitor> visitorService)
    {
        _visitorService = visitorService;
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetBlockedSubscription(Guid id)
    {
        BlockedSubscription blockedSubscription = new();
        var visitor = _visitorService.GetById(id);
        if (visitor == null) return NotFound();
        var infoBlock = blockedSubscription.BlockedSubscriptionVisitor(visitor);
        return infoBlock;
    }
}
