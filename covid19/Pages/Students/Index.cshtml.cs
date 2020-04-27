using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using covid19.Models;

namespace covid19.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly TrackingContext _context;

        public IndexModel(TrackingContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public IList<EventLog> EventLog { get; set; }
        public IList<EventLog> SelectedEventLog { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Student = await _context.Students.ToListAsync();
            EventLog = await _context.EventLogs
                                     .Include(x => x.Location)
                                     .ToListAsync();

            if (id != null)
            {
                // StudentID = id.Value; 
             
                SelectedEventLog = EventLog.Where(x => x.StudentID == id.Value).ToList();
                
            }
        }
    }
}
