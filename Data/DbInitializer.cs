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

            var tasks = new Task[]
            {
                new Task{Name="Task 1",Priority = PriorityType.Low},   
                new Task{Name="Task 2",Priority = PriorityType.Low},   
                new Task{Name="Task 3",Priority = PriorityType.High},   
                new Task{Name="Task 4", Priority = PriorityType.Low},   
                new Task{Name="Task 5",Priority = PriorityType.Medium}                
            };

            foreach (Task s in tasks)
            {
                context.Tasks.Add(s);
            }
            context.SaveChanges();
        }
    }
}