using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tasks : ControllerBase
    {
        private static List<Assignment> tasks = new List<Assignment>
            {
              
            };

        private readonly DataContext _context;
        public Tasks(DataContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<List<Assignment>> Get() 
        {
            var taskList = await _context.Tasks.ToListAsync();
            return taskList;
        }

        [HttpPost]
        public async Task<List<Assignment>> AddTask(Assignment task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return tasks;
        }

        [HttpDelete("{id}")]
        public async Task<List<Assignment>> DeleteTask(int id)
        {
            var task =  await _context.Tasks.FindAsync(id);
            if (task == null)
                return null;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return tasks;
        }
    }
}
