using System.Collections.Generic;
using System.Linq;
using SoccerDiv.Models; // Make sure to use the correct namespace
using SoccerDiv.Models.SoccerDiv.Models;

namespace SoccerDiv.Helpers
{
	public static class TicketHelper
	{
		public static IEnumerable<Ticket> GetPurchasedTicketsForCurrentUser(string userId)
		{
			// Implement your logic here to fetch and return the purchased tickets for the given user ID
			// For example:
			using (var db = new SoccerDivEntities()) // Update with your DbContext
			{
				return db.Tickets.Where(t => t.CustomerID == userId).ToList();
			}
		}
	}
}
