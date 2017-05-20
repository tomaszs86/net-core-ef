using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using net_core_ef.Models;
using net_core_ef.Services;
using net_core_ef.ViewModels;

namespace net_core_ef.Controllers
{
    public class TaskController : Controller
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;                        
        }

        public async Task<IActionResult> Index()
        {
            List<UserTask> tasks = await _taskService.GetAll();

            TaskViewModel vm = new TaskViewModel() { Tasks = tasks }; 
            return View(vm);
        }

        [HttpGet]
        public ViewResult Create() 
        {
            return View();    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskCreateViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserTask task = new UserTask() { Id = vm.Id, Name = vm.Name};
                
                    await _taskService.Add(task);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            UserTask task = await _taskService.Get(id);

            if (task == null)
            {
                return RedirectToAction("Index");
            }

            TaskCreateViewModel vm = new TaskCreateViewModel() { Id = task.Id, Name = task.Name, Priority = task.Priority};

            return View(vm);
        }   

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserTask task = await _taskService.Get((int)id);

            if (task == null)
            {
                return NotFound();
            }

            TaskCreateViewModel vm = new TaskCreateViewModel() { Id = task.Id, Name = task.Name, Priority = task.Priority};

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskCreateViewModel vm)
        {
            var task = await _taskService.Get(vm.Id);
           
            try
            {
                task.Name = vm.Name;
                task.Priority = vm.Priority;

                await _taskService.Update(task);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            
            return View();
        }
    }
}
