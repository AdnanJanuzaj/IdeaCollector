using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdeaCollector.Data;
using IdeaCollector.Models;

namespace IdeaCollector.Pages.Ideas
{
    public class CreateModel : PageModel
    {
        private readonly IdeaCollector.Data.ApplicationDbContext _context;

        public CreateModel(IdeaCollector.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Idea Idea { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Idea.Add(Idea);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
