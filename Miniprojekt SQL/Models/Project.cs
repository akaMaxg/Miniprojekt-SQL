using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniprojekt_SQL.Models
{
    [Table("mgu_project")] //Pointing to table name
    public class Project
    {
        public int id { get; set; } //properties match columns, but shout be PascalCase
        public string project_name { get; set; }
    }
}
