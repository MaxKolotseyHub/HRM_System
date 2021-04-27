using AutoMapper;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using HRM_System_WebApi.Models.Departaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HRM_System_WebApi.Controllers
{
    public class DepartamentsController : ApiController
    {
        private readonly IBaseService<DepartamentBll> _service;
        private readonly Mapper _mapper;

        public DepartamentsController(IBaseService<DepartamentBll> service, Mapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: Departaments
        [Route("api/departaments"), HttpGet]
        public IHttpActionResult Index()
        {
            var depts = _mapper.Map<IEnumerable<IndexDepartamentViewModel>>(_service.GetAll());
            return Ok(depts);
        }

        [Route("api/departaments/{id}"), HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [Route("api/departaments/{id}"), HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var dept = _mapper.Map<IndexDepartamentViewModel>(_service.GetById(id));
            return Ok(dept);
        }

        [Route("api/departaments/{id}"), HttpPost]
        public async Task<IHttpActionResult> Edit(IndexDepartamentViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _service.Update(_mapper.Map<DepartamentBll>(model));
            return Ok();
        }
    }
}
