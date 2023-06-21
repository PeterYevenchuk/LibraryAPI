using DAL.Entities.EntitiesLibrary;

namespace BLL.Services.NotificationSystem;

public class Notification
{
    public string TicketExpirationNotification(SeasonTicket seasonTicket)
    {
        const uint DAY_TO_END = 7;

        DateTime curentDate = DateTime.Now;
        DateTime expitationDate = seasonTicket.ExpirationDate.AddDays(-DAY_TO_END);

        if (curentDate == expitationDate)
        {
            return $"Season ticket will end in {DAY_TO_END} days!";
        }
        else if (curentDate == seasonTicket.ExpirationDate)
        {
            return "Today season ticket will end!";
        }
        else if (curentDate < seasonTicket.ExpirationDate)
        {
            return "Season ticket has ended!";
        }
        else
        {
            return null;
        }
    }
}
