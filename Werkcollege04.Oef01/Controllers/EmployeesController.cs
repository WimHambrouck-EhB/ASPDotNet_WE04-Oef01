using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Werkcollege04.Oef01.Data;
using Werkcollege04.Oef01.Models;

namespace Werkcollege04.Oef01.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly Werkcollege04Oef01Context _context;

        public EmployeesController(Werkcollege04Oef01Context context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var werkcollege04Oef01Context = _context.Employee.Include(e => e.Department).Include(e => e.Manager);
            return View(await werkcollege04Oef01Context.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(m => m.Empno == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["Deptno"] = new SelectList(_context.Set<Department>(), "Deptno", "Deptno");
            ViewData["Mgr"] = new SelectList(_context.Employee, "Empno", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Empno,Name,Job,Mgr,Hiredate,Salary,Commission,Deptno")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Deptno"] = new SelectList(_context.Set<Department>(), "Deptno", "Deptno", employee.Deptno);
            ViewData["Mgr"] = new SelectList(_context.Employee, "Empno", "Name", employee.Mgr);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["Deptno"] = new SelectList(_context.Set<Department>(), "Deptno", "Deptno", employee.Deptno);
            ViewData["Mgr"] = new SelectList(_context.Employee, "Empno", "Name", employee.Mgr);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Empno,Name,Job,Mgr,Hiredate,Salary,Commission,Deptno")] Employee employee)
        {
            if (id != employee.Empno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Empno))
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
            ViewData["Deptno"] = new SelectList(_context.Set<Department>(), "Deptno", "Deptno", employee.Deptno);
            ViewData["Mgr"] = new SelectList(_context.Employee, "Empno", "Name", employee.Mgr);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(m => m.Empno == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Empno == id);
        }
    }
}
