using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;

namespace TodoApp
{
    public interface ITaskService
    {
        public ServiceResponse<bool> CreateTask(string taskName);

    }
}
