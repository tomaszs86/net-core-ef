using net_core_ef.Models;
using System;
using System.Linq;
using net_core_ef.ViewModels;

namespace net_core_ef.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EfCoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Tasks.Any())
            {
                return;   // DB has been seeded
            }

            var tasks = new UserTask[]
            {
                new UserTask{Name="Task 1",Priority = PriorityType.Low},   
                new UserTask{Name="Task 2",Priority = PriorityType.Low},   
                new UserTask{Name="Task 3",Priority = PriorityType.High},   
                new UserTask{Name="Task 4", Priority = PriorityType.Low},   
                new UserTask{Name="Task 5",Priority = PriorityType.Medium}                
            };

            foreach (UserTask s in tasks)
            {
                context.Tasks.Add(s);
            }
            context.SaveChanges();
        }
    }
}