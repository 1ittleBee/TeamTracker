using SoccerDiv.Models.SoccerDiv.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerDiv.Models
{
	public partial class Event
	{
		public int Event_ID { get; set; }
		public int Sports_ID { get; set; }
		public int Tournament_ID { get; set; }
		public int First_Team { get; set; }
		public int Second_Team { get; set; }
		public int Venue_ID { get; set; }

		[DataType(DataType.Date)]
		public Nullable<System.DateTime> Event_Date { get; set; }
		public int AvailableTickets { get; set; }

		[DataType(DataType.Time)]
		public Nullable<System.TimeSpan> Event_Time { get; set; }
		public string Event_Details { get; set; }
		public virtual ICollection<Ticket> Tickets { get; set; }

		public virtual Team Team { get; set; }
		public virtual Team Team1 { get; set; }
		public virtual Sport Sport { get; set; }
		public virtual Tournamnet Tournamnet { get; set; }
		public virtual Venue Venue { get; set; }
		public string TicketType { get; set; }
		public decimal TicketPrice { get; set; }
		// Constructor to initialize the Tickets collection
		public Event()
		{
			Tickets = new List<Ticket>();
		}
	}
}
