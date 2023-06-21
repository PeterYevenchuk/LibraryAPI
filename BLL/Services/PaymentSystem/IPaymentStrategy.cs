namespace BLL.Services.PaymentSystem;

public interface IPaymentStrategy
{
    public string ProcessPayment(decimal amount, string paymentType); // paymentType can be card number or mail for PayPal
}
