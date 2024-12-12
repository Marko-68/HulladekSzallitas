using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HulladekSzallitas.Controllers
{
    public class CustomController : Controller
    {
        private readonly HulladekSzallitasContext _context;

        public CustomController(HulladekSzallitasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> LastKomDate()
        {
            return View(await _context.Naptar
                .Where(n => n.Szolgaltatas.tipus == "kom")
                .OrderByDescending(n => n.datum)
                .Select(n => n.datum)
                .FirstOrDefaultAsync());
        }

        public async Task<IActionResult> JanuarGreen()
        {
            return View(await _context.Naptar
                .Where(n => n.Szolgaltatas.tipus == "zold")
                .Where(n => n.datum.Month == 01)
                .Select(n => n.datum)
                .ToListAsync());
        }

        public async Task<IActionResult> GreenCount()
        {
            return View(await _context.Lakig
                .Include(n => n.Szolgaltatas)
                .Where(n => n.Szolgaltatas.tipus == "zold")
                .CountAsync());
        }

        public async Task<IActionResult> MostCountMonth()
        {
            return View(await _context.Lakig
                .GroupBy(n => n.igeny.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    hulladeksum = g.Sum(n => n.mennyiseg)
                })
                .OrderByDescending(x => x.hulladeksum)
                .FirstOrDefaultAsync());

        }


        public async Task<IActionResult> PaMuaDay()
        {
            return View(await _context.Naptar
                .GroupBy(n => n.datum)
                .Where(g => g.Any(n => n.Szolgaltatas.tipus == "pa") && g.Any(n => n.Szolgaltatas.tipus == "mua"))
                .Select(g => g.Key)
                .ToListAsync());

        }
        public async Task<IActionResult> MonthlyStat()
        {
            return View(await _context.Lakig
                .GroupBy(n => new { n.igeny.Year, n.igeny.Month, n.Szolgaltatas.tipus })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    WasteType = g.Key.tipus,
                    Total = g.Sum(x => x.mennyiseg)
                })
                .OrderByDescending(g => g.Total)
                .ToListAsync());

        }

    }
}
