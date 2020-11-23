using AutoMapper;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using HRM_System_UI.Helpers;
using HRM_System_UI.Models.Employee;
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
        private readonly IJobService _jobService;
        private readonly IDepartamentService _deptService;
        private readonly Mapper _mapper;

        public EmployeesController()
        {

        }
        public EmployeesController(IEmployeeService service, IJobService jobService, IDepartamentService deptService, Mapper mapper)
        {
            _service = service;
            _jobService = jobService;
            _deptService = deptService;
            _mapper = mapper;
        }
        // GET: Employees
        public ActionResult Index()
        {
            //var emp = new EmployeeBll() {
            //    FirstName = "Максим",
            //    SecondName = "Колоцей",
            //    ThirdName = "Александрович",
            //    Email = "kolotseymax@gmail.com",
            //    Fired = false,
            //    HireDate = new DateTime(2020, 11, 12),
            //    PhoneNumber = "+375259630794",
            //    Salary = 2750
            //};
            //await _service.Add(emp);
            return View(_service.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var depts = _deptService.GetAll();
            var jobs = _jobService.GetAll();

            ViewBag.Depts = depts;
            ViewBag.Jobs = jobs;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            await _service.Add(_mapper.Map<EmployeeBll>(model), model.DepartamentId, model.JobId, model.HireDate);

            return RedirectToAction("Index");
        }
    }
}