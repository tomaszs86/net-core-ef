using System.Collections.Generic;
using net_core_ef.Models;

namespace net_core_ef.ViewModels
{
    public class TaskViewModel
    {
        public IEnumerable<Task> Tasks { get; set; }    
        
    }
}