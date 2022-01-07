using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TicketSystem.Data;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TicketSystemContext _context;

        public HomeController(ILogger<HomeController> logger, TicketSystemContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.Account.ToListAsync());
        }

        public IActionResult Privacy(string M, int N = 1)
        {
            ViewData["M"] = "Hello " + M;
            ViewData["N"] = N;
            return View();
        }

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {numTimes}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Menu(string id)
        {
            var user = _context.Account.FirstOrDefault(f => f.ID == id);
            if (user == null)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            else
            {
                var premissions = _context.AccountRole.Where(f => f.AccountID == id)
                    .SelectMany(s => s.Role.RolePremissions
                    .Select(s => s.Premission)).Distinct()
                    .Select(s => s.PremissionType).ToList();
                HttpContext.Session.SetString("Premission", string.Join(";", premissions.Select(s => ((int)s).ToString()).ToArray()));
                HttpContext.Session.SetString("UserID", user.ID);

                List<NavigationParameterModel> menuList = new List<NavigationParameterModel>();
                if (premissions.Contains(Premission.PremissionEnum.AccountView))
                {
                    menuList.Add(new NavigationParameterModel { Controller = "Accounts", DisplayName = "Account" });
                }
                if (premissions.Any(a => (int)a >= 100))
                {
                    menuList.Add(new NavigationParameterModel { Controller = "Tickets", DisplayName = "Ticket" });
                }

                return View(menuList);
            }
        }

        public IActionResult Route(NavigationParameterModel data)
        {
            return RedirectToAction("Index", data.Controller);
        }
    }
}
