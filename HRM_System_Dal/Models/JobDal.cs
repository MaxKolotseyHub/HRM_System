using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Dal.Models
{
    public class JobDal
    {
        public JobDal()
        {
            JobHistories = new List<JobHistoryDal>();
        }
        public int Id { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public string Title { get; set; }
        public virtual List<JobHistoryDal> JobHistories { get; set; }
    }
}
