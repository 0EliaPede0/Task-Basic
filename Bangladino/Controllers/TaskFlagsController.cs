using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bangladino.Models;

namespace Bangladino.Controllers
{
    public class TaskFlagsController : Controller
    {
        private readonly ToDoContext _context;

        public TaskFlagsController(ToDoContext context)
        {
            _context = context;
        }

        // GET: TaskFlags
        public async Task<IActionResult> Index()
        {
              return _context.TaskFlags != null ? 
                          View(await _context.TaskFlags.ToListAsync()) :
                          Problem("Entity set 'ToDoContext.TaskFlags'  is null.");
        }
        /*
        public ActionResult HB(int ID)
        {
            int bnumber = ID;
            var taskFlagg = _context.TaskFlags.FirstOrDefaultAsync(m => m.Id == ID);
           
            return View("Index", _context.TaskFlags);
        }*/


        // GET: TaskFlags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TaskFlags == null)
            {
                return NotFound();
            }

            var taskFlag = await _context.TaskFlags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskFlag == null)
            {
                return NotFound();
            }

            return View(taskFlag);
        }

        // GET: TaskFlags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskFlags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Testo,Flag")] TaskFlag taskFlag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskFlag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskFlag);
        }

        // GET: TaskFlags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TaskFlags == null)
            {
                return NotFound();
            }

            var taskFlag = await _context.TaskFlags.FindAsync(id);
            if (taskFlag == null)
            {
                return NotFound();
            }
            return View(taskFlag);
        }

        // POST: TaskFlags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Testo,Flag")] TaskFlag taskFlag)
        {
            if (id != taskFlag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskFlag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskFlagExists(taskFlag.Id))
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
            return View(taskFlag);
        }

        public async Task<IActionResult> Edit2(int? id)
        {
            if (id == null || _context.TaskFlags == null)
            {
                return NotFound();
            }

            var taskFlag = await _context.TaskFlags.FindAsync(id);
            if (taskFlag == null)
            {
                return NotFound();
                
            }
            else if (taskFlag.Flag == true)
            {
                taskFlag.Flag = false;
                try
                {
                    _context.Update(taskFlag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskFlagExists(taskFlag.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            else if (taskFlag.Flag == false)
            {
                taskFlag.Flag = true;
                try
                {
                    _context.Update(taskFlag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskFlagExists(taskFlag.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else { }

            return RedirectToAction(nameof(Index));
        }

        // GET: TaskFlags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TaskFlags == null)
            {
                return NotFound();
            }

            var taskFlag = await _context.TaskFlags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskFlag == null)
            {
                return NotFound();
            }

            return View(taskFlag);
        }

        // POST: TaskFlags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TaskFlags == null)
            {
                return Problem("Entity set 'ToDoContext.TaskFlags'  is null.");
            }
            var taskFlag = await _context.TaskFlags.FindAsync(id);
            if (taskFlag != null)
            {
                _context.TaskFlags.Remove(taskFlag);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskFlagExists(int id)
        {
          return (_context.TaskFlags?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}
