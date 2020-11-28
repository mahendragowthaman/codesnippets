using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Services
{
    public class ServiceHelper
    {
        public static string GenerateCorrelationId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
