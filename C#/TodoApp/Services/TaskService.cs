using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp
{
    public class TaskService : ITaskService
    {
        private readonly IContextHelper contextHelper;
        public TaskService(IContextHelper _contextHelper)
        {
            contextHelper = _contextHelper;
        }
        public ServiceResponse<bool> CreateTask(string taskName)
        {
            ServiceResponse<bool> taskCreatedResponse = ServiceResponse<bool>.CreateSuccessResponse(true);
            try
            {
                using (DbContext dbContext = contextHelper.GetDbContext())
                {
                    // db operations goes here.
                }
            }
            catch (Exception exception)
            {
                taskCreatedResponse = ServiceResponse<bool>.CreateErrorResponse(false, exception);
            }

            return taskCreatedResponse;

        }

      
    }
}
