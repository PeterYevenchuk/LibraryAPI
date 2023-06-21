using DAL.Entities.EntitiesLibrary;

namespace BLL.Services.BanSystem;

public class BlockedSubscription
{
    public string BlockedSubscriptionVisitor(Visitor visitor)
    {
        DateTime curentDate = DateTime.Now;
        DateTime expitationDate = visitor.SeasonTicket.ExpirationDate;
        var usedBooks = visitor.ActiveLibraryItems;

        if (curentDate > expitationDate && usedBooks != null)
        {
            return "Due to an overdue subscription and unreturned books, you have been blocked! " +
                "Pay the fine to continue using the services of our bookstore.";
        }
        else
        {
            return null;
        }
    }
}
