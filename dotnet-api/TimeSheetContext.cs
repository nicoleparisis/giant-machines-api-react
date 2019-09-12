using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models;
using Microsoft.EntityFrameworkCore;

namespace gm
{
    public class TimeSheetContext : DbContext
    {
        public TimeSheetContext(DbContextOptions<TimeSheetContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<TimeSheetEntry> TimeSheetEntries { get; set; }
        
    }
}
