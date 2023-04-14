using Miniprojekt_SQL.Services;
using System.Configuration;

namespace Miniprojekt_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString; //
            TimeReportingService timeReportingService = new TimeReportingService(connectionString); //New Timereporting service instance


            //This section will be a separate method.
            while (true)
            {
                Console.WriteLine("______________________________________________________________\n");
                Console.WriteLine("1. Create person");
                Console.WriteLine("2. Create project");
                Console.WriteLine("3. Register time on project");
                Console.WriteLine("4. List all persons");
                Console.WriteLine("5. List all projects");
                Console.WriteLine("6. List all entries");
                Console.WriteLine("7. Exit");
                Console.WriteLine("______________________________________________________________\n");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter person name: ");
                        string personName = Console.ReadLine();
                        timeReportingService.CreatePerson(personName);
                        break;
                    case 2:
                        Console.Write("Enter project name: ");
                        string projectName = Console.ReadLine();
                        timeReportingService.CreateProject(projectName);
                        break;
                    case 3:
                        Console.Write("Enter project ID: ");
                        int projectId = int.Parse(Console.ReadLine());
                        Console.Write("Enter person ID: ");
                        int personId = int.Parse(Console.ReadLine());
                        Console.Write("Enter hours worked: ");
                        int hours = int.Parse(Console.ReadLine());
                        timeReportingService.RegisterTime(projectId, personId, hours);
                        break;
                    case 4:
                        Console.WriteLine("______________________________________________________________\n");
                        timeReportingService.GetAllPersons();
                        break;
                    case 5:
                        Console.WriteLine("______________________________________________________________\n");
                        timeReportingService.GetAllProjects();
                        break;
                        
                    case 6:
                        Console.WriteLine("______________________________________________________________\n");
                        timeReportingService.GetPersonAndProject();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Not an option");
                        break;
                }
            }
        }
    }
}