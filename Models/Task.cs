using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAkvelon.Models
{
    public class Task
    {   //primary key 
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description  { get; set; } 
        public string TaskStatus { get; set; }
        public int Priority  { get; set; }

        //foreign key
        public int ProjectId { get; set; }
        //navigation property
        public Project Project  { get; set; }


        /*A one-to-many relationship represents a situation where one entity stores 
          a reference to one object of another entity, and the second entity can refer 
           to a collection of objects of the first entity.In our case, one project may 
        contain a bunch of tasks and these tasks will only be assigned to one project.*/

    }
}
