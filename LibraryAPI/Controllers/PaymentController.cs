using BLL.Services.PaymentSystem;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]/payments")]
public class PaymentController : ControllerBase
{
    private readonly PaymentSystem _paymentSystem;

    public PaymentController(PaymentSystem paymentSystem)
    {
        _paymentSystem = paymentSystem;
    }

    [HttpGet("creditcard")]
    public ActionResult<string> ProcessCreditCardPayment(decimal amount, string cardNumber)
    {
        var strategy = new CreditCardPaymentStrategy();
        _paymentSystem.SetPaymentStrategy(strategy);
        var result = _paymentSystem.ProcessPayment(amount, cardNumber);
        return Ok(result);
    }

    [HttpGet("paypal")]
    public ActionResult<string> ProcessPayPalPayment(decimal amount, string payPalMail)
    {
        var strategy = new PayPalPaymentStrategy();
        _paymentSystem.SetPaymentStrategy(strategy);
        var result = _paymentSystem.ProcessPayment(amount, payPalMail);
        return Ok(result);
    }
}
