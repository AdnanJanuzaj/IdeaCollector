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
    public class IndexModel : PageModel
    {
        private readonly IdeaCollector.Data.ApplicationDbContext _context;

        public IndexModel(IdeaCollector.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Idea> Idea { get;set; }

        public async Task OnGetAsync()
        {
            Idea = await _context.Idea.ToListAsync();
        }
    }
}
