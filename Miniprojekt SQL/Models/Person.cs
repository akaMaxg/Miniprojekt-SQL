using System.ComponentModel.DataAnnotations.Schema;

namespace Miniprojekt_SQL.Models
{
    [Table("mgu_person")] //Pointing to table name
    public class Person
    {
        public int id { get; set; } //properties match columns, but shout be PascalCase
        public string person_name { get; set; }
    }
}
