using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniprojekt_SQL.Models
{    public class ProjectPerson
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PersonId { get; set; }
        public int Hours { get; set; }
    }
}
