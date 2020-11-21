using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Dal.DbContexts
{
    internal class MyContextInitializer: DropCreateDatabaseIfModelChanges<MyDbContext>
    {
    }
}
