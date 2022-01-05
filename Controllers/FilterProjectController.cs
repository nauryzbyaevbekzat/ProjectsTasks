using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAkvelon.Models;

namespace TestAkvelon.Controllers
{   
    //WIll be a plus to have an ability to filter and sort projects with 
    //various methods (start at, end at, range, exact value, etc.) 
    //and by various fields (start date, priority, etc.)

    [ApiController]
    [Route("api/[controller]")]
    public class FilterProjectController : ControllerBase
    {
        ApplicationContext db;
        public FilterProjectController(ApplicationContext context)
        {
            db = context;

        }
        //Will show with the by lowest priority
        //GET  api/filterProject/OrderByStartDate

        [HttpGet]
        [Route("[action]", Name = "OrderByPriority")]
        public async Task<ActionResult<IEnumerable<Project>>> OrderByPriority()
        {
            var project = db.Projects.OrderBy(p => p.Priority);
            return await project.ToListAsync();
        }
        //Will show with the by lowest StartDate
        //GET  api/filterProject/OrderByStartDate
        [HttpGet]
        [Route("[action]", Name = "OrderByStartDate")]
        public async Task<ActionResult<IEnumerable<Project>>> OrderByStartDate()
        {
            var project = db.Projects.OrderBy(p => p.StartDate);
            return await project.ToListAsync();
        }
        //Will show with the by lowest CompletionDate
        //GET  api/filterProject/"OrderByCompletionDate"
        [HttpGet]
        [Route("[action]", Name = "OrderByCompletionDate")]
        public async Task<ActionResult<IEnumerable<Project>>> OrderByCompletionDatey()
        {
            var project = db.Projects.OrderBy(p => p.CompletionDate);
            return await project.ToListAsync();
        }
        //Will show with the by lowest ProjectId
        //GET  api/filterProject/OrderById
        [HttpGet]
        [Route("[action]", Name = "OrderById")]
        public async Task<ActionResult<IEnumerable<Project>>> OrderById()
        {
            var project = db.Projects.OrderBy(p => p.ProjectId);
            return await project.ToListAsync();
        }
        //Find by ProjectId
        //GET  api/filterProject/FindById/5
        [HttpGet]
        [Route("[action]", Name = "FindById")]
        public async Task<ActionResult<Project>> FindById(int id) 
        {
            Project project = await db.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (project == null)
                return NotFound();
            return new ObjectResult(project);
        }
        //Find by ProjectId
        //GET  api/filterProject/FindByRangeId?start=1&&end=5
        [HttpGet]
        [Route("[action]", Name = "FindByRangeId")]
        public async Task<ActionResult<Project>> FindByRangeId(int start , int end)
        {  
            var projects = await (from project in  db.Projects
                         where project.ProjectId >= start && project.ProjectId <= end
                            select project).ToListAsync();
            return new ObjectResult(projects);
        }

        //Ability to view all tasks in the project
        //GET  api/filterProject/AllTasksFindById/5
        [HttpGet]
        [Route("[action]", Name = "AllTasksFindById")]
        public async Task<ActionResult<Project>> AllTasksFindById (int ProjectId)
        {
            var tasks = await (from task in db.Tasks 
                               where task.ProjectId == ProjectId
                               select task).ToListAsync();
            if (tasks == null)
                return NotFound();
            return new ObjectResult(tasks);
        }

    }
}
