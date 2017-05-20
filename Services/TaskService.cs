using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net_core_ef.Data;
using net_core_ef.Models;

namespace net_core_ef.Services
{
    public interface ITaskService {
        Task<List<UserTask>> GetAll();
        Task<UserTask> Get(int id);
        Task<int> Add(UserTask task);

        Task<int> Update(UserTask task);
    }
    
    public class TaskService : ITaskService {

        private EfCoreContext _context;

        public TaskService(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<List<UserTask>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        } 

        public async Task<int> Add(UserTask task)
        {
           _context.Add(task);
           return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(UserTask task)
        {
           _context.Update(task);
           return await _context.SaveChangesAsync();
        }

        public async Task<UserTask> Get(int id)
        {
            return await _context.Tasks.SingleOrDefaultAsync(r => r.Id == id);
        }
    }
}