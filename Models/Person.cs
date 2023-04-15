using System.ComponentModel.DataAnnotations.Schema;

namespace Miniprojekt_SQL.Models
{
    [Table("mgu_person")] //Pointing to table name
    public class Person //person object
    {
        public int id { get; set; } //properties match columns, but should be PascalCase
        public string person_name { get; set; }
    }
}
