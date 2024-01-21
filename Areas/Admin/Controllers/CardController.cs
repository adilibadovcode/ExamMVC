using ExamMVC.Context;
using ExamMVC.Helpers;
using ExamMVC.Models;
using ExamMVC.ViewModels.CardVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CardController : Controller
    {

        ExamContext _db { get; }

        public CardController(ExamContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Cards.Select(x => new CardListItemVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Text = x.Text
            }).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CardCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Card card = new Card
            {
                Description = vm.Description,
                Image = await vm.Image.SaveAsync(PathConstants.Card),
                Name = vm.Name,
                Text = vm.Text
            };
            await _db.Cards.AddAsync(card);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Cards.FindAsync(Id);
            if (data == null) return NotFound();
            return View(new CardUpdateVM
            {
                Description = data.Description,
                Name = data.Name,
                Text = data.Text,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? Id, CardUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Cards.FindAsync(Id);
            if (data == null) return NotFound();
            data.Text = vm.Text;
            data.Name = vm.Name;
            data.Description = vm.Description;
            data.Image = await vm.Image.SaveAsync(PathConstants.Card);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 0) return BadRequest();
            var data = await _db.Cards.FindAsync(Id);
            if (data == null) return NotFound();
            _db.Cards.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
