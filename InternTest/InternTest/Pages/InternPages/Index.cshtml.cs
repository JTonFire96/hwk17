using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InternTest.Pages.InternPages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;
        [TempData]
        public string afterAddMessage { get; set; }
        public string someData { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Interns> myConnections { get; set; }
        public async Task OnGet()
        {
            myConnections = await _db.InternItems.ToListAsync();

        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var theConnection = _db.InternItems.Find(id);
            _db.InternItems.Remove(theConnection);
            await _db.SaveChangesAsync();
            afterAddMessage = "Intern deleted successfully!";
            return RedirectToPage();
        }
    }
}