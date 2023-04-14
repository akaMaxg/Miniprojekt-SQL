using Microsoft.EntityFrameworkCore;
using Miniprojekt_SQL.Data;
using Miniprojekt_SQL.Models;

namespace Miniprojekt_SQL.Services
{
    public class TimeReportingService //Class for methods
    {
        private readonly string connectionString; //defines connectionstring

        public TimeReportingService(string connectionString) //Construct that sets the connection string its instance, string parameter
        {
            this.connectionString = connectionString;
        }

        public void CreatePerson(string personName) //takes a string and creates a new instance of person object where it sets the name to entered parameter
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                var person = new Person { person_name = personName };
                dbContext.Person.Add(person); //Method adds to DbContext change-tracker (property)
                dbContext.SaveChanges(); //Method that depending on 'state' and change-tracker generates SQL to update database.
            }
        }

        public void CreateProject(string projectName)
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                var project = new Project { project_name = projectName };
                dbContext.Project.Add(project);
                dbContext.SaveChanges();
            }
        }

        public void RegisterTime(int projectId, int personId, int hours)
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                var projectPerson = new ProjectPerson { project_id = projectId, person_id = personId, hours = hours };
                dbContext.ProjectPerson.Add(projectPerson);
                dbContext.SaveChanges();
            }
        }

        public void GetAllProjects()
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                dbContext.Project.ToList();
                foreach (var project in dbContext.Project)
                {
                    Console.WriteLine(project.project_name);
                }
            }
        }
        public void GetPersonAndProject()
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                var result = from pp in dbContext.ProjectPerson //LINQ query 
                             join p in dbContext.Person on pp.person_id equals p.id // sets person_id = projectperson rows. called p.id
                             join proj in dbContext.Project on pp.project_id equals proj.id // Same but sets project_id to projectperson rows, called proj.id
                             select new //creates a new entry/row/object with properties ->
                             {
                                 PersonName = p.person_name, //Comes from person_name column in Person
                                 ProjectName = proj.project_name, //Comes from project_name column in Project
                                 Hours = pp.hours //Comes from Hours column in ProjectPerson
                             };
                foreach (var entry in result)
                {
                    Console.WriteLine($"Project: {entry.ProjectName}\nName: {entry.PersonName}\nHours: {entry.Hours}\n_______________");
                }
            }
        }

        public void GetAllPersons()
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                dbContext.Person.ToList();
                foreach (var person in dbContext.Person)
                {
                    Console.WriteLine(person.person_name);
                }
            }
        }
    }
}
