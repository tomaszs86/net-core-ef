using net_core_ef.ViewModels;

namespace net_core_ef.Models
{
    public class UserTask {
        public int Id { get; set; }
        public string Name { get; set; }
        public PriorityType Priority { get; set; }
    }
}