using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using covid19.Models;

namespace covid19.Pages.EventLogs
{
    public class CreateModel : PageModel
    {
        private readonly TrackingContext _context;

        public CreateModel(TrackingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "Name");
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "StudentIdNumber");
            return Page();
        }

        [BindProperty]
        public EventLog EventLog { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            EventLog.TimeStamp = DateTime.Now;
            _context.EventLogs.Add(EventLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
