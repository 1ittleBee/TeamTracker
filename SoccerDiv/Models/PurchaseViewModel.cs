using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoccerDiv.Models
{
	public class PurchaseViewModel
	{
		public int SelectedEventId { get; set; }

		[Required(ErrorMessage = "Please enter your name")]
		public string CustomerName { get; set; }

		// Add more properties for customer information (email, phone, etc.)
		[Required(ErrorMessage = "Please enter your email")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please select the ticket type")]
		public string SelectedTicketType { get; set; }

		[Required(ErrorMessage = "Please enter the ticket price")]
		[Range(0.01, double.MaxValue, ErrorMessage = "Invalid ticket price")]
		public decimal TicketPrice { get; set; }

		[Required(ErrorMessage = "Please enter the ticket quantity")]
		[Range(1, int.MaxValue, ErrorMessage = "Invalid ticket quantity")]
		public int SelectedTicketQuantity { get; set; }
	}
}
