using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Models;
using TicketSystem.Utility;

namespace TicketSystem.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketSystemContext _context;

        public TicketsController(TicketSystemContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var premissions = HttpContext.Session.GetString("Premission").Split(";");

            List<string> DataActions = new List<string>();
            if (premissions.Contains(((int)Premission.PremissionEnum.TicketResolve).ToString()))
            {
                DataActions.Add("Resolve");
            }
            if (premissions.Contains(((int)Premission.PremissionEnum.TicketModify).ToString()))
            {
                DataActions.Add("Edit");
                DataActions.Add("Delete");
            }
            ViewData["DataActions"] = DataActions;
            if (premissions.Contains(((int)Premission.PremissionEnum.TicketCreate).ToString()))
            {
                ViewBag.CreateEnable = true;
            }

            Expression<Func<Ticket, bool>> filter = (f => f == null);
            if (premissions.Contains(((int)Premission.PremissionEnum.TicketView).ToString()))
            {
                filter = filter.Or(f => f.Type == TicketTypeEnum.Ticket);
            }
            if (premissions.Contains(((int)Premission.PremissionEnum.TestCaseView).ToString()))
            {
                filter = filter.Or(f => f.Type == TicketTypeEnum.TestCase);
            }
            if (premissions.Contains(((int)Premission.PremissionEnum.FeatureRequestView).ToString()))
            {
                filter = filter.Or(f => f.Type == TicketTypeEnum.FeatureRequest);
            }
            return View(await _context.Ticket.Where(filter).Where(f => f.Deleted == null).ToListAsync());
        }



        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Summary,Description,Type,ID,Created,Deleted")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(string id,string actName)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Summary,Description,Type,ID,Created,Deleted")] Ticket ticket)
        {
            if (id != ticket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(string id)
        {
            return _context.Ticket.Any(e => e.ID == id);
        }
        public async Task<IActionResult> LoginAsync(string id)
        {
            var user = _context.Account.FirstOrDefault(f => f.ID == id);
            if (user == null)
                return View();
            else
            {
                var premissions = _context.AccountRole.Where(f => f.AccountID == id)
                    .SelectMany(s => s.Role.RolePremissions
                    .Select(s => s.Premission)).Distinct()
                    .Select(s => s.PremissionType).ToList();
                HttpContext.Session.SetString("Premission", string.Join(";", premissions.Select(s => ((int)s).ToString()).ToArray()));

                var db = _context.Ticket.Where(f => f.Deleted == null)
                    .Where(f => premissions.Any(a => a == Premission.PremissionEnum.TicketView) );

                return View("Index", await _context.Ticket.ToListAsync());
            }
        }
    }
}
