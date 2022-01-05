using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAkvelon.Models;

namespace TestAkvelon.Controllers
{   
    
    //Ability to create / view / edit / delete information about projects

    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        ApplicationContext db;
        public ProjectController(ApplicationContext context)
        {
            db = context;
           
        }
        // View
        // GET api/project/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            return await db.Projects.ToListAsync();
        }
        // View by id
        // GET api/project/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> Get(int id)
        {
            Project project = await db.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (project == null)
                return NotFound();
            return new ObjectResult(project);
        }
        //Create
        // POST api/project/
        [HttpPost]
        public async Task<ActionResult<Project>> Post(Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }

            db.Projects.Add(project);
            await db.SaveChangesAsync();
            return Ok(project);
        }
        // Edit
        // PUT api/project/
        [HttpPut]
        public async Task<ActionResult<Project>> Put(Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            if (!db.Projects.Any(x => x.ProjectId == project.ProjectId))
            {
                return NotFound();
            }

            db.Projects.Update(project);
            await db.SaveChangesAsync();
            return Ok(project);
        }
        // Delete by id
        // DELETE api/project/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> Delete(int id)
        {
            Project project = db.Projects.FirstOrDefault(x => x.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }
            db.Projects.Remove(project);
            await db.SaveChangesAsync();
            return Ok(project);
        }
    }
}
