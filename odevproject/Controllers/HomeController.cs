using Microsoft.AspNetCore.Mvc;
using PagedList;
using Microsoft.IdentityModel.Tokens;
using odevproject.Models;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace odevproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StajContext _context;

        public HomeController(ILogger<HomeController> logger, StajContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string q, string clear, int page = 1)
        {
            const int pageSize = 5;
            IQueryable<ÖdevTable> query = _context.ÖdevTables
                                        .Include(o => o.Il)
                                        .Include(o => o.Ilce);

            if (!string.IsNullOrEmpty(clear))
            {
                q = string.Empty;
            }
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(x => x.KullaniciAdi.Contains(q) ||
                                        x.KullaniciSoyadi.Contains(q) ||
                                        x.TelefonNumarasi.Contains(q) ||
                                        x.Mail.Contains(q) ||
                                        x.Yetki.Contains(q) ||
                                        x.Yas.ToString().Contains(q));
            }
            var pagedList = query.ToPagedList(page, pageSize);

            ViewBag.AramaTerimi = q;
            return View(pagedList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Create()
        {
            ViewBag.Iller = new SelectList(_context.Iller, "IlId", "IlAd");
            ViewBag.Ilceler = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text"); 
            return View();
        }


        [HttpPost]
        public ActionResult Create(ÖdevTable p1)
        {
            if (p1 == null || !ModelState.IsValid)
            {
                ViewBag.Iller = new SelectList(_context.Iller, "IlId", "IlAd");
                ViewBag.Ilceler = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
                return View("Create");
            }
            _context.ÖdevTables.Add(p1);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Yeni kullanýcý baþarýyla eklendi.";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var ödevTable = _context.ÖdevTables.Find(id);
            if (ödevTable == null) return NotFound();
            _context.ÖdevTables.Remove(ödevTable);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var ödevTable = _context.ÖdevTables.Find(id);
            if (ödevTable == null) return NotFound();

            ViewBag.Iller = new SelectList(_context.Iller, "IlId", "IlAd", ödevTable.IlId);
            ViewBag.Ilceler = new SelectList(_context.Ilceler.Where(i => i.IlId == ödevTable.IlId), "IlceId", "IlceAd", ödevTable.IlceId);

            return View(ödevTable);
        }
        [HttpPost]
        public ActionResult Edit(ÖdevTable p2)
        {
            var ödevTable = _context.ÖdevTables.Find(p2.Id);
            if (ödevTable == null) return NotFound();
            ödevTable.KullaniciAdi = p2.KullaniciAdi;
            ödevTable.KullaniciSoyadi = p2.KullaniciSoyadi;
            ödevTable.TelefonNumarasi = p2.TelefonNumarasi;
            ödevTable.Mail = p2.Mail;
            ödevTable.Yetki = p2.Yetki;
            ödevTable.Yas = p2.Yas;
            ödevTable.IlId = p2.IlId;
            ödevTable.IlceId = p2.IlceId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetIlceler(int ilId)
        {
            var ilceler = _context.Ilceler
                .Where(i => i.IlId == ilId)
                .Select(i => new { i.IlceId, i.IlceAd })
                .ToList();
            return Json(ilceler);
        }
    }
}
