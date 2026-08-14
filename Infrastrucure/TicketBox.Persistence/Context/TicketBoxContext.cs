using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Domain.Entities;

namespace TicketBox.Persistence.Context
{
    public class TicketBoxContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
     "Server=localhost;Initial Catalog=DbTicketSphere;Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
