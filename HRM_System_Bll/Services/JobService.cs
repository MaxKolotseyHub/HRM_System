using AutoMapper;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using HRM_System_Dal.DbContexts;
using HRM_System_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Services
{
    internal class JobService : IBaseService<JobBll>
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        public JobService(MyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Add(JobBll model)
        {
            var job = _mapper.Map<JobDal>(model);
            if (_db.Jobs.FirstOrDefault(x => x.Title == job.Title) == null)
            {
                _db.Jobs.Add(job);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var job = _db.Jobs.FirstOrDefault(x => x.Id == id);
            if (job != null)
            {
                _db.Jobs.Remove(job);
                await _db.SaveChangesAsync();
            }
        }

        public IEnumerable<JobBll> GetAll()
        {
            return _mapper.Map<IEnumerable<JobBll>>(_db.Jobs.ToList());
        }

        public JobBll GetById(int id)
        {
            var job = _db.Jobs.FirstOrDefault(x => x.Id == id);
            return job == null ? null : _mapper.Map<JobBll>(job);
        }

        public async Task Update(JobBll model)
        {
            var job = _db.Jobs.FirstOrDefault(x => x.Id == model.Id);
            job.MaxSalary = model.MaxSalary;
            job.MinSalary = model.MinSalary;
            job.Title = model.Title;
            await _db.SaveChangesAsync();
        }
    }
}
