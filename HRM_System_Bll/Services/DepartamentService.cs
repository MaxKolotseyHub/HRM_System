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
    internal class DepartamentService : IBaseService<DepartamentBll>
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        public DepartamentService(MyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Add(DepartamentBll model)
        {
            var dept = _mapper.Map<DepartamentDal>(model);
            if (_db.Departaments.FirstOrDefault(x => x.Title == dept.Title) == null)
            {
                _db.Departaments.Add(dept);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var dept = _db.Departaments.FirstOrDefault(x => x.Id == id);
            if (dept != null)
            {
                _db.Departaments.Remove(dept);
                await _db.SaveChangesAsync();
            }
        }

        public IEnumerable<DepartamentBll> GetAll()
        {
            return _mapper.Map<IEnumerable<DepartamentBll>>(_db.Departaments.ToList());
        }

        public DepartamentBll GetById(int id)
        {
            var dept = _db.Departaments.FirstOrDefault(x => x.Id == id);
            return  dept == null ? null : _mapper.Map<DepartamentBll>(dept);
        }

        public async Task Update(DepartamentBll model)
        {
            var dept = _db.Departaments.FirstOrDefault(x => x.Id == model.Id);
            dept.Title = model.Title;
            await _db.SaveChangesAsync();
        }
    }
}
