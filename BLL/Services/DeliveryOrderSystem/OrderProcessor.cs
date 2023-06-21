using BLL.services.DeliveryOrderProces;
using System.Text;

namespace BLL.services.DeliveryOrder;

public class OrderService : IOrderService
{
    public const int DATE_DELIVERY = 2;
    public const int LENGTH_TTN_NUMBER = 14;

    public DeliveryOrderInfo GenerateDeliveryOrder()
    {
        Random random = new Random();

        StringBuilder ttnBuilder = new StringBuilder();
        for (int i = 0; i < LENGTH_TTN_NUMBER; i++)
        {
            ttnBuilder.Append(random.Next(0, 10));
        }
        string ttn = ttnBuilder.ToString();

        // We calculate the delivery date in 2 days
        DateTime orderDate = DateTime.Now;
        DateTime estimatedDate = orderDate.AddDays(DATE_DELIVERY);

        DeliveryOrderInfo order = new DeliveryOrderInfo
        {
            TTN = ttn,
            OrderTime = orderDate,
            EstimatedDate = estimatedDate
        };

        return order;
    }
}
