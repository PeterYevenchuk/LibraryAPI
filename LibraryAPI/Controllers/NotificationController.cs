using BLL.Services.NotificationSystem;
using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IService<Visitor> _visitorService;

    public NotificationController(IService<Visitor> visitorService)
    {
        _visitorService = visitorService;
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetNotificationMessage(Guid id)
    {
        Notification notification = new();
        var visitor = _visitorService.GetById(id);
        if (visitor == null) return NotFound();
        var infoTicket = notification.TicketExpirationNotification(visitor.SeasonTicket);
        return infoTicket;
    }
}
