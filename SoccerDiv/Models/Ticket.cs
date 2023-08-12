using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoccerDiv.Models

{
	namespace SoccerDiv.Models
	{
		public class Ticket
		{
			public int TicketID { get; set; }
			public int EventID { get; set; }
			public string CustomerID { get; set; }
			public DateTime PurchaseDate { get; set; }
			public DateTime Ticket_PurchaseDate { get; internal set; }

			// Add other properties as needed
		}

		public enum TicketType
		{
			GeneralAdmission,
			VIP,
			Premium,
			// Add more ticket types as needed
		}
	}


}