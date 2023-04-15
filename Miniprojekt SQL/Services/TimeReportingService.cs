using Microsoft.EntityFrameworkCore;
using Miniprojekt_SQL.Data;
using Miniprojekt_SQL.Models;
using System;

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

        public void GetPersonAndTimeListRegisteredOnProjectId(int personId)
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                var result = from pp in dbContext.ProjectPerson //LINQ query 
                             join p in dbContext.Person on pp.person_id equals p.id // sets person_id = projectperson rows. called p.id
                             join proj in dbContext.Project on pp.project_id equals proj.id // Same but sets project_id to projectperson rows, called proj.id
                             where p.id == personId // person_id
                             group pp by proj.project_name into projGroup // group by project_name
                             select new //creates a new entry/row/object with columns ->
                             {
                                 ProjectName = projGroup.Key, //Comes from person_name column in Person
                                 TotalHours = projGroup.Sum(pp => pp.hours), //Comes from project_name column in Project
                             };
                foreach (var entry in result)
                {
                    Console.WriteLine($"Project: {entry.ProjectName}, Hours: {entry.TotalHours}\n");
                }
            }
        }

        public void GetPersonsListRegisteredOnProjectId(int projectId)
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                var project = dbContext.Project.Find(projectId);
                var result = from pp in dbContext.ProjectPerson //LINQ query 
                             join p in dbContext.Person on pp.person_id equals p.id // sets person_id = projectperson rows. called p.id
                             join proj in dbContext.Project on pp.project_id equals proj.id // Same but sets project_id to projectperson rows, called proj.id
                             where proj.id == projectId // project_id
                             group pp by p.person_name into persGroup // group by project_name
                             select new //creates a new entry/row/object with columns ->
                             {
                                 PersonName = persGroup.Key, //Comes from person_name column in Person
                                 TotalHours = persGroup.Sum(pp => pp.hours), //Comes from person_name column in person
                             };
                Console.WriteLine($"Project: {project.project_name}\n");
                foreach (var entry in result)
                {
                    Console.WriteLine($"Name: {entry.PersonName}, Hours: {entry.TotalHours}\n");
                }
            }
        }
        public void EntriesLog()
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                var result = from pp in dbContext.ProjectPerson //LINQ query 
                             join p in dbContext.Person on pp.person_id equals p.id // sets person_id = projectperson rows. called p.id
                             join proj in dbContext.Project on pp.project_id equals proj.id // Same but sets project_id to projectperson rows, called proj.id
                             select new //creates a new entry/row/object with columns ->
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
                Console.WriteLine("\nThe following persons exists in the system:");
                foreach (var person in dbContext.Person)
                {
                    Console.WriteLine($"{person.id}. {person.person_name}");
                }
            }
        }
        public void GetAllProjects()
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                dbContext.Project.ToList();
                Console.WriteLine("\nThe following projects exists in the system:");
                foreach (var project in dbContext.Project)
                {
                    Console.WriteLine($"{project.id}. {project.project_name}");
                }
            }
        }
    }
}
