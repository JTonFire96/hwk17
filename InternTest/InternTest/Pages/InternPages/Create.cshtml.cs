using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternTest.Pages.InternPages
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;
        public string someData { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string afterAddMessage { get; set; }
        [BindProperty]
        public Interns Intern { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                //Return to a page and not a view
                return Page();

            }
            else
            {
                //if it IS Valid , then we'll add our Connnection to our table
                _db.InternItems.Add(Intern);
                await _db.SaveChangesAsync();
                afterAddMessage = "New Intern Added!";
                return RedirectToPage("Index");
            }
        }
    }
}