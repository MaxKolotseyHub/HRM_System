using AutoMapper;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using HRM_System_WebApi.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HRM_System_WebApi.Controllers
{
    public class JobsController : ApiController
    {
        private readonly IBaseService<JobBll> _jobService;
        private readonly Mapper _mapper;

        public JobsController(IBaseService<JobBll> jobService, Mapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }
        // GET: Positions
        [Route("api/jobs"),HttpGet]
        public IHttpActionResult Index()
        {
            var jobs = _mapper.Map<IEnumerable<IndexJobViewModel>>(_jobService.GetAll());
            return Ok(jobs);
        }

        [Route("api/jobs/{id}"),HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _jobService.Delete(id);
            return Ok();
        }

        [Route("api/jobs/{id}"),HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var job = _mapper.Map<IndexJobViewModel>(_jobService.GetById(id));
            return Ok(job);
        }

        [Route("api/jobs"),HttpPost]
        public IHttpActionResult Edit(IndexJobViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (model.MinSalary > model.MaxSalary)
                return BadRequest("Слишком высокий оклад для данной позиции");

            _jobService.Update(_mapper.Map<JobBll>(model));
            return Ok();
        }
    }
}
