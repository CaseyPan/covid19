using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using covid19.Models;

namespace covid19.Pages.EventLogs
{
    public class IndexModel : PageModel
    {
        private readonly TrackingContext _context;

        public IndexModel(TrackingContext context)
        {
            _context = context;
        }

        public IList<EventLog> EventLog { get;set; }

        public async Task OnGetAsync()
        {
            EventLog = await _context.EventLogs
                .Include(e => e.Location)
                .Include(e => e.Student).ToListAsync();
        }
    }
}
