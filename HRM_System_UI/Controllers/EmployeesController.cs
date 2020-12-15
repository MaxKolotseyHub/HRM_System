using AutoMapper;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using HRM_System_UI.Helpers;
using HRM_System_UI.Models.Employee;
using HRM_System_UI.Models.Filters;
using HRM_System_UI.Models.Vacation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM_System_UI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _service;
        private readonly IVacationService _vacationService;
        private readonly IBaseService<JobBll> _jobService;
        private readonly IBaseService<DepartamentBll> _deptService;
        private readonly Mapper _mapper;

        public EmployeesController()
        {

        }
        public EmployeesController(IEmployeeService service, IBaseService<JobBll> jobService, IBaseService<DepartamentBll> deptService, IVacationService vacationService, Mapper mapper)
        {
            _service = service;
            _jobService = jobService;
            _deptService = deptService;
            _vacationService = vacationService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index(string fired)
        {
            ViewBag.Filter = string.IsNullOrEmpty(fired) ? "all" : fired;
            var empls = _mapper.Map<IEnumerable<IndexEmployeeViewModel>>(_service.GetAll());

            foreach (var emp in empls)
            {
                emp.OnVacation = _vacationService.CheckOnVacation(DateTime.Now, emp.Id);
            }

            if (string.Equals(fired, "fired"))
                return View(empls.Where(x => x.Fired));

            if (string.Equals(fired, "unfired"))
                return View(empls.Where(x => !x.Fired));

            return View(empls);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var depts = _deptService.GetAll();
            var jobs = _jobService.GetAll();

            var emp = _mapper.Map<EditEmployeeViewModel>(_service.GetById(id));

            emp.Depts = depts;
            emp.Jobs = jobs;

            return View(emp);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", model);
            }

            if (model.JobId != model.NewJobId || model.DepartamentId != model.NewDepartamentId)
            {
                await _service.ChangeJob(model.Id, model.NewJobId, DateTime.Now, model.NewDepartamentId, model.NewSalary);
                return RedirectToAction("Index");
            }

            if (model.Salary != model.NewSalary)
            {
                await _service.ChangeSalary(model.Id, model.NewSalary);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Fire(int id)
        {
            await _service.Fire(id, DateTime.Today);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Vacation(int id)
        {
            var emp = _service.GetById(id);
            var availableDays = _vacationService.GetAvailableDays(id);
            var vac = new CreateVacationViewModel
            {
                EmpId = emp.Id,
                AvailableDays = availableDays,
            };
            return View(vac);
        }

        [HttpPost]
        public async Task<ActionResult> Vacation(CreateVacationViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var vacationDays = ((DateTime)model.EndDate - (DateTime)model.StartDate).Days;
            if (vacationDays > model.AvailableDays)
            {
                model.ErrorMessage = "Количество выбранных дней не должно превышать количество доступных дней.";
                return View(model);
            }

            await _vacationService.StartVacation(model.EmpId, model.StartDate, model.EndDate);

                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var vm = _mapper.Map<DetailsEmployeeViewModel>(_service.GetById(id));
            return View(vm);
        }

        [HttpGet]
        public ActionResult EditInfo(int id)
        {
            var vm = _mapper.Map<EditInfoEmployeeViewModel>(_service.GetById(id));
            return View(vm);
        }    
        
        [HttpPost]
        public async Task<ActionResult> EditInfo(EditInfoEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.Update(_mapper.Map<EmployeeBll>(model));

            return RedirectToAction("Details",  new { id = model.Id});
        }
    }
}