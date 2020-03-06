using MEU.web.Data;
using MEU.web.Data.Entities;
using MEU.web.Helpers;
using MEU.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MEU.web.Controllers
{
    public class OfficesController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public OfficesController(DataContext context, IUserHelper userHelper,IConverterHelper converterHelper)
        {
            _datacontext = context;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
        }

        public IActionResult Index()
        {
            return View(_datacontext.Offices
                .Include(e => e.Employees)
                .ThenInclude(v => v.Voys)
                );
        }

        public IActionResult Create_Office()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_Office(Office office)
        {
            if (ModelState.IsValid)
            {
                _datacontext.Add(office);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        public async Task<IActionResult> EditOffice(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var office = await _datacontext.Offices.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }
            return View(office);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOffice(int? id, Office office)
        {
            if (id != office.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _datacontext.Update(office);
                    await _datacontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var valo = _datacontext.Offices.FindAsync(id);
                    if (valo == null)
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
            return View(office);
        }

        public async Task<IActionResult> DeleteOffice(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = await _datacontext.Offices
                .Include(c => c.Employees)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (office == null)
            {
                return NotFound();
            }

            if (office.Employees.Count != 0 )
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction($"Index");
            }

            _datacontext.Offices.Remove(office);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"Index");
        }


        public async Task<IActionResult> EmployList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = await _datacontext.Offices
                .Include(c => c.Employees)
                .ThenInclude(u => u.User)
                .Include(e => e.Employees)
                .ThenInclude(v => v.Voys)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (office == null)
            {
                return NotFound();
            }

            return View(office);
        }

        public async Task<IActionResult> EmployeeDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _datacontext.Offices
                .Include(c => c.Employees)
                .ThenInclude(u => u.User)
                .Include(e => e.Employees)
                .ThenInclude(v => v.Voys)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(AddEmployeeViewModel model, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var office = await _datacontext.Offices.FindAsync(id);
            if (ModelState.IsValid)
            {
                var user = await CreateEmployee(model);

                if (user != null)
                {
                    var employee = new Employee
                    {
                        User = user,
                        Office = office,
                        Skype = model.Skype,
                        Cargo = model.Cargo

                    };
                    _datacontext.Employees.Add(employee);
                    await _datacontext.SaveChangesAsync();
                    return RedirectToAction($"EmployList/{model.Id}");
                }
                ModelState.AddModelError(string.Empty, "User already exists");
            }
            return View(model);
        }

        private async Task<User> CreateEmployee(AddEmployeeViewModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Username,
                UserName = model.Username,
                Document = model.Document,
                PhoneNumber = model.PhoneNumber,

            };

            var result = await _userHelper.AddUserAsync(user, model.Password);

            if (result.Succeeded)
            {
                user = await _userHelper.GetUserByEmailAsync(model.Username);
                await _userHelper.AddUserToRoleAsync(user, "Employee");
                return user;
            }
            return null;
        }

        public async Task<IActionResult> EditEmployee(int? id)
        {
            var employee = await _datacontext.Employees
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || employee == null)
            {
                return NotFound();
            }

            var model = new EditEmployeeViewModel
            {
                Document = employee.User.Document,
                FirstName = employee.User.FirstName,
                LastName = employee.User.LastName,
                PhoneNumber = employee.User.PhoneNumber,
                Cargo = employee.Cargo,
                Skype = employee.Skype,
                Id = employee.Id,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EditEmployeeViewModel view)
        {
            if (ModelState.IsValid)
            {
                var employee = await _datacontext.Employees
                .Include(u => u.User)
                .Include(c => c.Office)
                .FirstOrDefaultAsync(p => p.Id == view.Id);

                employee.User.Document = view.Document;
                employee.User.FirstName = view.FirstName;
                employee.User.LastName = view.LastName;
                employee.User.PhoneNumber = view.PhoneNumber;
                employee.Skype = view.Skype;
                employee.Cargo = view.Cargo;

                await _userHelper.UpdateUserAsync(employee.User);
                return RedirectToAction($"{nameof(EmployList)}/{employee.Office.Id}");
            }

            return View(view);
        }


        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            var employee = await _datacontext.Employees
                .Include(s => s.Office)
                .Include(u => u.User)
                .Include(v => v.Voys)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || employee == null)
            {
                return NotFound();
            }

            if (employee.Voys.Count != 0)
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction($"{nameof(EmployList)}/{employee.Office.Id}");
            }


            _datacontext.Employees.Remove(employee);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"{nameof(EmployList)}/{employee.Office.Id}");

        }

    }
}