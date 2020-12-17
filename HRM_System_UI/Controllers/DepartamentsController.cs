using AutoMapper;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using HRM_System_UI.Models.Departaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM_System_UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class DepartamentsController : Controller
    {
        private readonly IBaseService<DepartamentBll> _service;
        private readonly Mapper _mapper;

        public DepartamentsController(IBaseService<DepartamentBll> service, Mapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: Departaments
        public ActionResult Index()
        {
            var depts = _mapper.Map<IEnumerable<IndexDepartamentViewModel>>(_service.GetAll());
            return View(depts);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dept = _mapper.Map<IndexDepartamentViewModel>(_service.GetById(id));
            return View(dept);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(IndexDepartamentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _service.Update(_mapper.Map<DepartamentBll>(model));
            return RedirectToAction("Index");
        }
    }
}