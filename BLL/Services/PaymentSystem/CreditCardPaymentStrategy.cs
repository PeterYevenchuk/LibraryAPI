namespace BLL.Services.PaymentSystem;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public string ProcessPayment(decimal amount, string cardNumber)
    {
        if (ValidCardNumber(cardNumber))
        {
            return $"Payment of {amount} via Credit Card processed successfully.";
        }
        else
        {
            return $"The payment did not go through, the card number {cardNumber} is incorrect!";
        }
    }

    private bool ValidCardNumber(string cardNumber)
    {
        int sum = 0;
        bool isSecondDigit = false;
        int[] digits = new int[cardNumber.Length];

        for (int i = 0; i < cardNumber.Length; i++)
        {
            digits[i] = int.Parse(cardNumber[i].ToString());
        }

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (isSecondDigit)
            {
                int doubledDigit = digits[i] * 2;
                if (doubledDigit > 9)
                {
                    doubledDigit = doubledDigit % 10 + doubledDigit / 10;
                }
                sum += doubledDigit;
            }
            else
            {
                sum += digits[i];
            }
            isSecondDigit = !isSecondDigit;
        }

        return sum % 10 == 0;
    }
}
