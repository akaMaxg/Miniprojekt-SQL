using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniprojekt_SQL.Models
{
    [Table("mgu_project_person")] //Pointing to table name
    public class ProjectPerson //object for entry log
    {
        public int id { get; set; } //properties match columns, but should be PascalCase
        public int project_id { get; set; }
        public int person_id { get; set; }
        public int hours { get; set; }
    }
}
