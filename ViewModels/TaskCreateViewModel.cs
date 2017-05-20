using System.ComponentModel.DataAnnotations;

namespace net_core_ef.ViewModels
{
    public enum PriorityType
    {
        Low, 
        Medium, 
        High
    }
    public class TaskCreateViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(80)]
        [Display(Name="Name")]
        public string Name { get; set; }
        public PriorityType Priority {get; set;}   
    }
}