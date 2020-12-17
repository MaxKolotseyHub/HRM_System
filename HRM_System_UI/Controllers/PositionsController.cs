using AutoMapper;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using HRM_System_UI.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM_System_UI.Controllers
{
    public class PositionsController : Controller
    {
        private readonly IBaseService<JobBll> _jobService;
        private readonly Mapper _mapper;

        public PositionsController(IBaseService<JobBll> jobService, Mapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }
        // GET: Positions
        public ActionResult Index()
        {
            var jobs = _mapper.Map<IEnumerable<IndexJobViewModel>>(_jobService.GetAll());
            return View(jobs);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _jobService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var job = _mapper.Map<IndexJobViewModel>(_jobService.GetById(id));
            return View(job);
        }

        [HttpPost]
        public ActionResult Edit(IndexJobViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.MinSalary > model.MaxSalary)
                return View(model);

            _jobService.Update(_mapper.Map<JobBll>(model));
            return RedirectToAction("Index");
        }
    }
}