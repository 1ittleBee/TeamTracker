﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using SoccerDiv.Models;

namespace SoccerDiv.Models
{
	using global::SoccerDiv.Models.SoccerDiv.Models;
	using System;
	using System.Collections;
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;

	public partial class SoccerDivEntities : DbContext
	{
		public SoccerDivEntities()
			: base("name=SoccerDivEntities")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			throw new UnintentionalCodeFirstException();
		}

		public virtual DbSet<Admin> Admins { get; set; }
		public virtual DbSet<Coach> Coaches { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Event> Events { get; set; }
		public virtual DbSet<News> News { get; set; }
		public virtual DbSet<Player> Players { get; set; }
		public virtual DbSet<Sport> Sports { get; set; }
		public virtual DbSet<Team> Teams { get; set; }
		public virtual DbSet<Tournamnet> Tournamnets { get; set; }
		public virtual DbSet<Venue> Venues { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public IEnumerable Tournaments { get; internal set; }
	}
}
