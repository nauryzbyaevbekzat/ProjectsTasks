using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAkvelon.Models
{
    public class Project
    {   //primary key 
        public int ProjectId { get; set; }  
        public string Name { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime CompletionDate { get; set; }
        public string ProjectStatus { get; set; }
        public int Priority  { get; set; }

        public List<Task> Tasks { get; set; } 
    }
  
}
