using CourtBooking.Domains.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Infstructure
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options ): base(options) 
        { 
        
        
        }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<TennisCourts> TennisCourts { get; set; }
        public DbSet<Bookings> Bookings { get; set; }

    }
}
