using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Data
{
    public class DbContext : IDisposable
    {
        //Its a mock class of the dbcontext

        public DbContext(string dbConnectionString)
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
