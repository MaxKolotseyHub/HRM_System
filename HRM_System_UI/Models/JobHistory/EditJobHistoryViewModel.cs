using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM_System_UI.Models.JobHistory
{
    public class EditJobHistoryViewModel
    {
        private DateTime? startDateDt;
        private DateTime? endDateDt;

        public int Id { get; set; }
        public string StartDate { get; set; }
        public DateTime? StartDateDt { get => startDateDt; set { startDateDt = value;
                if (startDateDt == null)
                    StartDate = "-";
                else StartDate = startDateDt?.ToString("dd.MM.yyyy");
            } }
        public decimal Salary { get; set; }
        public string JobTitle { get; set; }
        public string DeptTitle { get; set; }
        public string EndDate { get; set; }
        public DateTime? EndDateDt { get => endDateDt; set { endDateDt = value;
                if (endDateDt == null)
                    EndDate = "по настоящее время";
                else EndDate = endDateDt?.ToString("dd.MM.yyyy");
            } }
    }
}