using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM_System_UI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeesController()
        {

        }
        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }
        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var emp = new EmployeeBll() {
                FirstName = "Максим",
                SecondName = "Колоцей",
                ThirdName = "Александрович",
                Email = "kolotseymax@gmail.com",
                Fired = false,
                HireDate = new DateTime(2020, 11, 12),
                PhoneNumber = "+375259630794",
                Salary = 2750
            };
            await _service.Add(emp);
            return View(_service.GetAll());
        }
    }
}