using AutoMapper;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using WebApi.Models.Employee;
using WebApi.Models.Vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class EmployeesController : ApiController
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
        public IHttpActionResult Index(string fired)
        {
            var empls = _mapper.Map<IEnumerable<IndexEmployeeViewModel>>(_service.GetAll());

            foreach (var emp in empls)
            {
                emp.OnVacation = _vacationService.CheckOnVacation(DateTime.Now, emp.Id);
            }

            if (string.Equals(fired, "fired"))
                return Ok(empls.Where(x => x.Fired));

            if (string.Equals(fired, "unfired"))
                return Ok(empls.Where(x => !x.Fired));

            return Ok(empls);
        }

        [HttpGet]
        public IHttpActionResult Create()
        {
            var depts = _deptService.GetAll();
            var jobs = _jobService.GetAll();

            return Ok(new { Departaments = depts, Jobs = jobs });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(CreateEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _service.Add(_mapper.Map<EmployeeBll>(model), model.DepartamentId, model.JobId, model.HireDate);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Edit(int id)
        {
            var depts = _deptService.GetAll();
            var jobs = _jobService.GetAll();

            var emp = _mapper.Map<EditEmployeeViewModel>(_service.GetById(id));

            emp.Depts = depts;
            emp.Jobs = jobs;

            return Ok(emp);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Edit(EditEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (model.JobId != model.NewJobId || model.DepartamentId != model.NewDepartamentId)
            {
                await _service.ChangeJob(model.Id, model.NewJobId, DateTime.Now, model.NewDepartamentId, model.NewSalary);
                return Ok();
            }

            if (model.Salary != model.NewSalary)
            {
                await _service.ChangeSalary(model.Id, model.NewSalary);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Fire(int id)
        {
            await _service.Fire(id, DateTime.Today);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Vacation(int id)
        {
            var emp = _service.GetById(id);
            var availableDays = _vacationService.GetAvailableDays(id);
            var vac = new CreateVacationViewModel
            {
                EmpId = emp.Id,
                AvailableDays = availableDays,
            };
            return Ok(vac);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Vacation(CreateVacationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (model.EndDate < model.StartDate)
            {
                return BadRequest("Неверно выбраны даты отпуска.");
            }
            var vacationDays = ((DateTime)model.EndDate - (DateTime)model.StartDate).Days;
            if (vacationDays > model.AvailableDays)
            {
                return BadRequest("Количество выбранных дней не должно превышать количество доступных дней.");
            }

            await _vacationService.StartVacation(model.EmpId, model.StartDate, model.EndDate);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Details(int id)
        {
            var vm = _mapper.Map<DetailsEmployeeViewModel>(_service.GetById(id));
            return Ok(vm);
        }

        [HttpGet]
        public IHttpActionResult EditInfo(int id)
        {
            var vm = _mapper.Map<EditInfoEmployeeViewModel>(_service.GetById(id));
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IHttpActionResult> EditInfo(EditInfoEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _service.Update(_mapper.Map<EmployeeBll>(model));

            return Ok(new { id = model.Id });
        }
    }
}
