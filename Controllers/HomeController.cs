using ExamMVC.Context;
using ExamMVC.ViewModels.CardVM;
using ExamMVC.ViewModels.HomeVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamMVC.Controllers
{
    public class HomeController : Controller
    {
        ExamContext _db { get; }

        public HomeController(ExamContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Cards = await _db.Cards.Select(x => new CardListItemVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Text = x.Text
            }).ToListAsync();
            return View(homeVM);
        }
    }
}
    