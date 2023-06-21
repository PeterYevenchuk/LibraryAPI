namespace BLL.Services.PaymentSystem;

public class PayPalPaymentStrategy : IPaymentStrategy
{
    public string ProcessPayment(decimal amount, string payPalMail)
    {
        if (IsValidEmail(payPalMail))
        {
            return $"Payment of {amount} via PayPal processed successfully.";
        }
        else
        {
            return $"The payment did not go through, the email {payPalMail} is invalid!";
        }
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var mailAddress = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
