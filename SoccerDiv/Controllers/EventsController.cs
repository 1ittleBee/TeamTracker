using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoccerDiv.Models;
using SoccerDiv.Models.SoccerDiv.Models;
//using Microsoft.AspNet.Identity;


namespace SoccerDiv.Controllers
{
    public class EventsController : Controller
    {
        private SoccerDivEntities db = new SoccerDivEntities();

        // GET: Events
        public ActionResult Index()
        {
            ViewBag.First_Team = new SelectList(db.Teams, "Team_ID", "Team_Logo");
            ViewBag.Second_Team = new SelectList(db.Teams, "Team_ID", "Team_Logo");
            var events = db.Events.Include(a => a.Team).Include(b => b.Team1).Include(c => c.Sport).Include(d => d.Tournamnet).Include(e => e.Venue);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.First_Team = new SelectList(db.Teams, "Team_ID", "Team_Name");
            ViewBag.Second_Team = new SelectList(db.Teams, "Team_ID", "Team_Name");
            ViewBag.Sports_ID = new SelectList(db.Sports, "Sports_ID", "Sports_Name");
            ViewBag.Tournament_ID = new SelectList(db.Tournamnets, "Tournament_ID", "Tournament_Name");
            ViewBag.Venue_ID = new SelectList(db.Venues, "Venue_ID", "Venue_Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Event_ID,Sports_ID,Tournament_ID,First_Team,Second_Team,Venue_ID,Event_Date,Event_Time,Event_Details")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.First_Team = new SelectList(db.Teams, "Team_ID", "Team_Name", @event.First_Team);
            ViewBag.Second_Team = new SelectList(db.Teams, "Team_ID", "Team_Name", @event.Second_Team);
            ViewBag.Sports_ID = new SelectList(db.Sports, "Sports_ID", "Sports_Name", @event.Sports_ID);
            ViewBag.Tournament_ID = new SelectList(db.Tournamnets, "Tournament_ID", "Tournament_Name", @event.Tournament_ID);
            ViewBag.Venue_ID = new SelectList(db.Venues, "Venue_ID", "Venue_Name", @event.Venue_ID);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.First_Team = new SelectList(db.Teams, "Team_ID", "Team_Name", @event.First_Team);
            ViewBag.Second_Team = new SelectList(db.Teams, "Team_ID", "Team_Name", @event.Second_Team);
            ViewBag.Sports_ID = new SelectList(db.Sports, "Sports_ID", "Sports_Name", @event.Sports_ID);
            ViewBag.Tournament_ID = new SelectList(db.Tournamnets, "Tournament_ID", "Tournament_Name", @event.Tournament_ID);
            ViewBag.Venue_ID = new SelectList(db.Venues, "Venue_ID", "Venue_Name", @event.Venue_ID);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Event_ID,Sports_ID,Tournament_ID,First_Team,Second_Team,Venue_ID,Event_Date,Event_Time,Event_Details")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EventList");
            }
            ViewBag.First_Team = new SelectList(db.Teams, "Team_ID", "Team_Name", @event.First_Team);
            ViewBag.Second_Team = new SelectList(db.Teams, "Team_ID", "Team_Name", @event.Second_Team);
            ViewBag.Sports_ID = new SelectList(db.Sports, "Sports_ID", "Sports_Name", @event.Sports_ID);
            ViewBag.Tournament_ID = new SelectList(db.Tournamnets, "Tournament_ID", "Tournament_Name", @event.Tournament_ID);
            ViewBag.Venue_ID = new SelectList(db.Venues, "Venue_ID", "Venue_Name", @event.Venue_ID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("EventList");
        }

        [HttpGet]
        public ActionResult AddEvents()
        {
            ViewBag.First_Team = new SelectList(db.Teams, "Team_ID", "Team_Name");
            ViewBag.Second_Team = new SelectList(db.Teams, "Team_ID", "Team_Name");
            ViewBag.Sports_ID = new SelectList(db.Sports, "Sports_ID", "Sports_Name");
            ViewBag.Tournament_ID = new SelectList(db.Tournamnets, "Tournament_ID", "Tournament_Name");
            ViewBag.Venue_ID = new SelectList(db.Venues, "Venue_ID", "Venue_Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddEvents(Event evt)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(evt);
                db.SaveChanges();
                ViewBag.Success = "Successfully Added";
            }

            else
            {
                ViewBag.Failed = "Something Wrong";
            }

            ViewBag.First_Team = new SelectList(db.Teams, "Team_ID", "Team_Name", evt.First_Team);
            ViewBag.Second_Team = new SelectList(db.Teams, "Team_ID", "Team_Name", evt.Second_Team);
            ViewBag.Sports_ID = new SelectList(db.Sports, "Sports_ID", "Sports_Name", evt.Sports_ID);
            ViewBag.Tournament_ID = new SelectList(db.Tournamnets, "Tournament_ID", "Tournament_Name", evt.Tournament_ID);
            ViewBag.Venue_ID = new SelectList(db.Venues, "Venue_ID", "Venue_Name", evt.Venue_ID);
            return View();
        }


        public ActionResult EventList()
        {
            var events = db.Events.Include(a => a.Team).Include(a => a.Team1).Include(a => a.Sport).Include(a => a.Tournamnet).Include(a => a.Venue);
            return View(events.ToList());
        }

        //for customer
        [Authorize]
        public ActionResult Football()
        {
           var football = db.Events.Where(u => u.Sport.Sports_ID == 1).ToList();
           if (football != null)
            {
                return View(football);
            }
            else
            {
                ViewBag.Football = "No events found";
                return View();
            }
        }

        [Authorize]
        public ActionResult Cricket()
        {
            var cricket = db.Events.Where(u => u.Sport.Sports_ID == 2).ToList();
            if (cricket != null)
            {
                return View(cricket);
            }
            else
            {
                ViewBag.Cricket = "No events found";
                return View();
            }
        }

        [Authorize]
        public ActionResult Tennis()
        {
            var tennis = db.Events.Where(u => u.Sport.Sports_ID == 3).ToList();
            if (tennis != null)
            {
                return View(tennis);
            }
            else
            {
                ViewBag.Tennis = "No events found";
                return View();
            }
        }

        [Authorize]
        public ActionResult Basketball()
        {
            var basketball = db.Events.Where(u => u.Sport.Sports_ID == 4).ToList();
            if (basketball != null)
            {
                return View(basketball);
            }
            else
            {
                ViewBag.Basketball = "No events found";
                return View();
            }
        }

        [Authorize]
        public ActionResult Volleyball()
        {
            var volleyball = db.Events.Where(u => u.Sport.Sports_ID == 5).ToList();
            if (volleyball != null)
            {
                return View(volleyball);
            }
            else
            {
                ViewBag.Volleyball = "No events found";
                return View();
            }
        }

        [Authorize]
        public ActionResult Hockey()
        {
            var hockey = db.Events.Where(u => u.Sport.Sports_ID == 6).ToList();
            if (hockey != null)
            {
                return View(hockey);
            }
            else
            {
                ViewBag.Hockey = "No events found";
                return View();
            }
        }

        [Authorize]
        public ActionResult TableTennis()
        {
            var tableTennis = db.Events.Where(u => u.Sport.Sports_ID == 7).ToList();
            if (tableTennis != null)
            {
                return View(tableTennis);
            }
            else
            {
                ViewBag.TableTennis = "No events found";
                return View();
            }
        }

        [Authorize]
        public ActionResult Badminton()
        {
            var badminton = db.Events.Where(u => u.Sport.Sports_ID == 8).ToList();
            if (badminton != null)
            {
                return View(badminton);
            }
            else
            {
                ViewBag.Badminton = "No events found";
                return View();
            }
        }

        [Authorize]
        public ActionResult Baseball()
        {
            var baseball = db.Events.Where(u => u.Sport.Sports_ID == 9).ToList();
            if (baseball != null)
            {
                return View(baseball);
            }
            else
            {
                ViewBag.Baseball = "No events found";
                return View();
            }
        }

        [Authorize]
        public ActionResult Rugby()
        {
            var rugby = db.Events.Where(u => u.Sport.Sports_ID == 10).ToList();
            if (rugby != null)
            {
                return View(rugby);
            }
            else
            {
                ViewBag.Rugby = "No events found";
                return View();
            }
        }

        [Authorize]
        public ActionResult Premium()
        {
            return View();
        }

        public ActionResult sort()
        {
            var x = db.Events.OrderByDescending(a => a.Event_Date).ToString();
            return View(x);
        }
		[Authorize(Roles = "Admin")]
		public ActionResult PurchaseTicket(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Event @event = db.Events.Find(id);
			if (@event == null)
			{
				return HttpNotFound();
			}

			if (@event.AvailableTickets > 0)
			{
				// Replace this line with your logic to retrieve the current user's identifier
				string userId = GetCustomUserId(); // Replace with your own logic

				// Create a new ticket and associate it with the event and user
				Ticket newTicket = new Ticket
				{
					EventID = @event.Event_ID,
					CustomerID = userId,
					Ticket_PurchaseDate = DateTime.Now
				};

				db.Tickets.Add(newTicket);
				@event.AvailableTickets--;
				db.SaveChanges();

				return RedirectToAction("Details", new { id = @event.Event_ID });
			}

			ViewBag.ErrorMessage = "No tickets available for this event.";
			return View();
		}

		private string GetCustomUserId()
		{
			string userId = Session["UserId"] as string;
			return userId;
		}
		[HttpGet]
		public ActionResult PurchaseTicketForm(int Event_ID, int tournamentId)
		{
			// Retrieve the event and other required data
			Event @event = db.Events.Find(Event_ID);
			if (@event == null)
			{
				return HttpNotFound();
			}

			// Pass the event data to the view
			ViewBag.Event = @event;

			// Retrieve the events within the specified tournament and other required data
			List<Event> eventsInTournament = db.Events.Where(e => e.Tournament_ID == tournamentId).ToList();
			ViewBag.EventsInTournament = eventsInTournament;

			// Create an instance of the PurchaseViewModel and pass it to the view
			var purchaseViewModel = new PurchaseViewModel();
			return View(purchaseViewModel);
		}


		[HttpPost]
		[Authorize(Roles = "Customer")]
		public ActionResult PurchaseTicketForm(int Event_ID, int tournamentId, PurchaseViewModel model)
		{
			if (ModelState.IsValid)
			{
				// Process the form submission and generate a purchase bill
				// Update the database with the purchase information

				// Redirect to a success or confirmation page
				return RedirectToAction("PurchaseConfirmation");
			}

			// If the model is not valid, return to the form with validation errors
			Event @event = db.Events.Find(Event_ID);
			ViewBag.Event = @event;
			List<Event> eventsInTournament = db.Events.Where(e => e.Tournament_ID == tournamentId).ToList();
			ViewBag.EventsInTournament = eventsInTournament;

			// Create an instance of the PurchaseViewModel and pass it to the view
			var purchaseViewModel = new PurchaseViewModel();
			return View(purchaseViewModel);
			// Redirect back to the PurchaseTicketForm action with the correct eventId
			//return RedirectToAction("PurchaseTicketForm", new { Event_ID = @event.Event_ID });
		}

		[Authorize(Roles = "Customer")]
		public ActionResult PurchaseConfirmation()
		{
			// You can add any additional logic or retrieve necessary data here if needed
			return View();
		}

		[Authorize]
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
