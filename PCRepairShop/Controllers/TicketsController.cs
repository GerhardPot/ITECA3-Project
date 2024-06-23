using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pcrepairshop.Data;
using pcrepairshop.Models;
using PCRepairShop.Models.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pcrepairshop.Controllers
{
    public class TicketsController : Controller
    {
        private readonly PCrepairshopDbContext _context;
        private readonly UserManager<User> _ManagerContext;

        private void AddViewBag()
        {
            ViewBag.InitStatus = Enum.GetValues(typeof(eInitStatus)).Cast<eInitStatus>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }).ToList();
            ViewBag.InvType = Enum.GetValues(typeof(eInvType)).Cast<eInvType>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }).ToList();
            ViewBag.Status = Enum.GetValues(typeof(eStatus)).Cast<eStatus>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }).ToList();
        }

        public TicketsController(PCrepairshopDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _ManagerContext = userManager;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            AddViewBag();
            var currentUser = await _ManagerContext.GetUserAsync(User);
            string role = "";
            if (currentUser != null)
            {
                var roleList = await _ManagerContext.GetRolesAsync(currentUser);
                role = roleList.First();
            }

            var result = new List<Ticket>();
            if (role == "Users")
            {
                result = await _context.Ticket.Where(x => x.User == currentUser.UserName).ToListAsync();
            }
            else
            {
                result = await _context.Ticket.ToListAsync();
            }
            return View(result);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            AddViewBag();
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InitialStatus,InventoryType,DeviceDescription")] Ticket ticket)
        {
            var newTicket = new Ticket()
            {
                DeviceDescription = ticket.DeviceDescription,
                Id = ticket.Id,
                InitialStatus = (eInitStatus)ticket.InitialStatus,
                InventoryType = (eInvType)ticket.InventoryType,
                Status = eStatus.Open,
                User = _ManagerContext.GetUserName(User)
            };

            _context.Add(newTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            AddViewBag();
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            try
            {
                var newTicket = await _context.Ticket.FirstAsync(x => x.Id == ticket.Id);
                newTicket.Status = ticket.Status;
                _context.Update(newTicket);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(ticket.Id))
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

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            AddViewBag();
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
