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
            IQueryable<�devTable> query = _context.�devTables
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
        public ActionResult Create(�devTable p1)
        {
            if (p1 == null || !ModelState.IsValid)
            {
                ViewBag.Iller = new SelectList(_context.Iller, "IlId", "IlAd");
                ViewBag.Ilceler = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
                return View("Create");
            }
            _context.�devTables.Add(p1);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Yeni kullan�c� ba�ar�yla eklendi.";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var �devTable = _context.�devTables.Find(id);
            if (�devTable == null) return NotFound();
            _context.�devTables.Remove(�devTable);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var �devTable = _context.�devTables.Find(id);
            if (�devTable == null) return NotFound();

            ViewBag.Iller = new SelectList(_context.Iller, "IlId", "IlAd", �devTable.IlId);
            ViewBag.Ilceler = new SelectList(_context.Ilceler.Where(i => i.IlId == �devTable.IlId), "IlceId", "IlceAd", �devTable.IlceId);

            return View(�devTable);
        }
        [HttpPost]
        public ActionResult Edit(�devTable p2)
        {
            var �devTable = _context.�devTables.Find(p2.Id);
            if (�devTable == null) return NotFound();
            �devTable.KullaniciAdi = p2.KullaniciAdi;
            �devTable.KullaniciSoyadi = p2.KullaniciSoyadi;
            �devTable.TelefonNumarasi = p2.TelefonNumarasi;
            �devTable.Mail = p2.Mail;
            �devTable.Yetki = p2.Yetki;
            �devTable.Yas = p2.Yas;
            �devTable.IlId = p2.IlId;
            �devTable.IlceId = p2.IlceId;
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
