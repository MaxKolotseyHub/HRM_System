using AutoMapper;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using HRM_System_Dal.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Services
{
    internal class DepartamentService : IDepartamentService
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        public DepartamentService(MyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IEnumerable<DepartamentBll> GetAll()
        {
            return _mapper.Map<IEnumerable<DepartamentBll>>(_db.Departaments.ToList());
        }
    }
}
