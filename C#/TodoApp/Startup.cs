using System;
using TodoApp.Data;
using Unity;

namespace TodoApp
{
    class Startup
    {
        static void Main(string[] args)
        {
            UnityContainer container = new UnityContainer();

            container.RegisterInstance<IContextHelper>(new ContextHelper("dbConnection"));
            container.RegisterType<ITaskService, TaskService>();

            ITaskService taskService = container.Resolve<ITaskService>();
            taskService.CreateTask("Check email");
        }
    }
}
