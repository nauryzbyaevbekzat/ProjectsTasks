using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestAkvelon.Controllers
{
    //Ability to create / view / edit / delete task information


    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {

        ApplicationContext db;
        public TaskController(ApplicationContext context)
        { 
            db = context;

        }
        // View
        // GET api/task/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> Get()
        {
            return await db.Tasks.ToListAsync(); 
        }

        // View by id
        // GET api/task/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> Get(int id)
        {
            Models.Task task = await db.Tasks.FirstOrDefaultAsync(x => x.TaskId == id);
            if (task == null)
                return NotFound();
            return new ObjectResult(task);
        }

        //Create
        // POST api/task/
        [HttpPost]
        public async Task<ActionResult<Models.Task>> Post(Models.Task task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            db.Tasks.Add(task);
            await db.SaveChangesAsync();
            return Ok(task);
        }

        // Edit
        // PUT api/task/
        [HttpPut]
        public async Task<ActionResult<Models.Task>> Put(Models.Task task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            if (!db.Tasks.Any(x => x.TaskId == task.TaskId))
            {
                return NotFound();
            }

            db.Tasks.Update(task);
            await db.SaveChangesAsync();
            return Ok(task);
        }

        // Delete by id
        // DELETE api/task/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Task>> Delete(int id)
        {
            Models.Task task = db.Tasks.FirstOrDefault(x => x.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            db.Tasks.Remove(task);
            await db.SaveChangesAsync();
            return Ok(task);
        }
    }
}
