using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using covid19.Models;

namespace covid19.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly TrackingContext _context;

        public IndexModel(TrackingContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; }

        public IList<EventLog> EventLog { get; set; }
        public IList<EventLog> SelectedEventLog { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Location = await _context.Locations.ToListAsync();
            EventLog = await _context.EventLogs
                                     .Include(x => x.Student)
                                     .ToListAsync();

            if (id != null)
            {
                // StudentID = id.Value; 

                SelectedEventLog = EventLog.Where(x => x.LocationID == id.Value).ToList();

            }
        }
    }
}
