using BLL.services.DeliveryOrderProces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<DeliveryOrderInfo> GenerateDeliveryOrder()
    {
        DeliveryOrderInfo order = _orderService.GenerateDeliveryOrder();
        return Ok(order);
    }
}
