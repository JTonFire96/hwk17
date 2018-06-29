using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternTest.Pages.InternPages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Interns Intern { set; get; }
        [TempData]
        public string afterAddMessage { set; get; }
        public void OnGet(int id)
        {
            Intern = _db.InternItems.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var connectionInDB = _db.InternItems.Find(Intern.ID);
                connectionInDB.InternName = Intern.InternName;
                connectionInDB.InternLocation = Intern.InternLocation;
                connectionInDB.InternCycle = Intern.InternCycle;
                // do this for all of your properties

                await _db.SaveChangesAsync();
                afterAddMessage = "List Item Updated Sucessfully!";

                return RedirectToPage("Index");

            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}