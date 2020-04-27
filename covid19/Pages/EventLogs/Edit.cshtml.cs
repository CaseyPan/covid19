using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using covid19.Models;

namespace covid19.Pages.EventLogs
{
    public class EditModel : PageModel
    {
        private readonly TrackingContext _context;

        public EditModel(TrackingContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "ID");
           ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EventLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventLogExists(EventLog.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EventLogExists(int id)
        {
            return _context.EventLogs.Any(e => e.ID == id);
        }
    }
}
