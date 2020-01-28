using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdeaCollector.Data;
using IdeaCollector.Models;

namespace IdeaCollector.Pages.Ideas
{
    public class DetailsModel : PageModel
    {
        private readonly IdeaCollector.Data.ApplicationDbContext _context;

        public DetailsModel(IdeaCollector.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Idea Idea { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Idea = await _context.Idea.FirstOrDefaultAsync(m => m.ID == id);

            if (Idea == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
