namespace BLL.Services.PaymentSystem;

public class PaymentSystem
{
    private IPaymentStrategy paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        paymentStrategy = strategy;
    }

    public string ProcessPayment(decimal amount, string paymentType)
    {
        return paymentStrategy.ProcessPayment(amount, paymentType);
    }
}
