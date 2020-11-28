using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Data
{
    public class ContextHelper : IContextHelper
    {
        private readonly string dbConnectionString;
        private ContextHelper()
        {

        }

        public ContextHelper(string _dbConnectionString)
        {
            dbConnectionString = _dbConnectionString;
        }

        public DbContext GetDbContext()
        {
            return new DbContext(dbConnectionString);
        }

    }
}
