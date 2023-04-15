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

        public void CreateProject(string projectName)//takes a string and creates a new instance of project object where it sets the name to entered paramete
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                var project = new Project { project_name = projectName };
                dbContext.Project.Add(project);
                dbContext.SaveChanges();
            }
        }

        public void RegisterTime(int projectId, int personId, int hours) //takes a three parameters and creates an entry of ProjectPerson where it sets which Person worked how many hours on which Project.
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                var projectPerson = new ProjectPerson { project_id = projectId, person_id = personId, hours = hours };
                dbContext.ProjectPerson.Add(projectPerson);
                dbContext.SaveChanges();
            }
        }

        public void GetProjectsAndTimeListRegisteredForPerson(int personId) // method that lists every project and the time spent for a specific person
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                //LINQ query 
                var result = from pp in dbContext.ProjectPerson 
                             join p in dbContext.Person on pp.person_id equals p.id // sets person_id = projectperson rows - called p.id
                             join proj in dbContext.Project on pp.project_id equals proj.id // same but sets project_id to projectperson rows - called proj.id
                             where p.id == personId // condition
                             group pp by proj.project_name into projGroup // group by project_name
                             select new //creates a new row with columns ->
                             {
                                 ProjectName = projGroup.Key, //value from person_name column in Person
                                 TotalHours = projGroup.Sum(pp => pp.hours), //value from project_name column in Project
                             };
                foreach (var entry in result)
                {
                    Console.WriteLine($"Project: {entry.ProjectName}, Hours: {entry.TotalHours}\n");
                }
            }
        }

        public void GetPersonsListRegisteredOnProjectId(int projectId) // method that lists every person and their time registered on a project
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                var project = dbContext.Project.Find(projectId); //to present selection
                //LINQ query
                var result = from pp in dbContext.ProjectPerson  
                             join p in dbContext.Person on pp.person_id equals p.id // sets person_id = projectperson rows - called p.id
                             join proj in dbContext.Project on pp.project_id equals proj.id // same but sets project_id to projectperson rows - called proj.id
                             where proj.id == projectId // condition
                             group pp by p.person_name into persGroup // group by project_name
                             select new //creates a new row with columns ->
                             {
                                 PersonName = persGroup.Key, //value from person_name column in Person
                                 TotalHours = persGroup.Sum(pp => pp.hours), //value from person_name column in person
                             };
                Console.WriteLine($"Project: {project.project_name}\n"); //presents selection
                foreach (var entry in result)
                {
                    Console.WriteLine($"Name: {entry.PersonName}, Hours: {entry.TotalHours}\n");
                }
            }
        }
        public void EntriesLog() // lists all time-registration entries
        {
            using (var dbContext = new AppDbContext(connectionString))
            {
                //LINQ query 
                var result = from pp in dbContext.ProjectPerson 
                             join p in dbContext.Person on pp.person_id equals p.id
                             join proj in dbContext.Project on pp.project_id equals proj.id 
                             select new // to get their value rather than id
                             {
                                 PersonName = p.person_name,
                                 ProjectName = proj.project_name, 
                                 Hours = pp.hours 
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
