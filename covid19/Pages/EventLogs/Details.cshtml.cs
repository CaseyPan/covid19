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
    public class DetailsModel : PageModel
    {
        private readonly TrackingContext _context;

        public DetailsModel(TrackingContext context)
        {
            _context = context;
        }

        public EventLog EventLog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventLog = await _context.EventLogs
                .Include(e => e.Location)
                .Include(e => e.Student).FirstOrDefaultAsync(m => m.ID == id);

            if (EventLog == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
