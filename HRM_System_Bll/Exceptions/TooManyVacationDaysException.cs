using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Exceptions
{
    public class TooManyVacationDaysException: Exception
    {
        public TooManyVacationDaysException(string msg = "Недостаточно доступных дней отпуска") : base(msg)
        {

        }
    }
}
