using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM_System_UI.Models.Vacation
{
    public class CreateVacationViewModel
    {
        public int EmpId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}