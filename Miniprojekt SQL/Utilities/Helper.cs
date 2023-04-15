using Miniprojekt_SQL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miniprojekt_SQL.Services;
using Miniprojekt_SQL.Utilities;
using System.Configuration;

namespace Miniprojekt_SQL.Utilities
{
    public class Helper
    {
        public static void Meny()
        {
            string connectionString = ConnectionStringHelper.GetConnectionString();
            Console.Write("\nChoose an option by typing the meny-number.");
            Console.WriteLine("\n______________________________________________________________\n");
            Console.WriteLine("1. Create person");
            Console.WriteLine("2. Create project");
            Console.WriteLine("3. Register time on project");
            Console.WriteLine("4. List all persons");
            Console.WriteLine("5. List all projects");
            Console.WriteLine("6. List entries-log");
            Console.WriteLine("7. List entries for specific person");
            Console.WriteLine("8. List entries for specific project");
            Console.WriteLine("9. Exit");
            Console.WriteLine("______________________________________________________________\n");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            TimeReportingService timeReportingService = new TimeReportingService(connectionString); //New Timereporting service instance
            MenuFunctions(choice, timeReportingService);

        }

        public static void MenuFunctions(int choice, TimeReportingService timeReportingService)
        {
            switch (choice)
            {
                case 1:
                    Console.Write("Enter person name: ");
                    string personName = Console.ReadLine();
                    timeReportingService.CreatePerson(personName);
                    Console.WriteLine($"--A new person named: {personName} has been created.--");
                    Meny();
                    break;
                case 2:
                    Console.Write("Enter project name: ");
                    string projectName = Console.ReadLine();
                    timeReportingService.CreateProject(projectName);
                    Console.WriteLine($"--A new project named: {projectName} has been added.--");
                    Meny();
                    break;
                case 3:
                    timeReportingService.GetAllProjects();
                    Console.Write("Enter project ID: ");
                    int projectId = int.Parse(Console.ReadLine());
                    timeReportingService.GetAllPersons();
                    Console.Write("Enter person ID: ");
                    int personIdRegister = int.Parse(Console.ReadLine());
                    Console.Write("Enter hours worked: ");
                    int hours = int.Parse(Console.ReadLine());
                    timeReportingService.RegisterTime(projectId, personIdRegister, hours);
                    Console.WriteLine("--Registration successfull.--");
                    Meny();
                    break;
                case 4:
                    Console.WriteLine("______________________________________________________________\n");
                    timeReportingService.GetAllPersons();
                    Meny();
                    break;
                case 5:
                    Console.WriteLine("______________________________________________________________\n");
                    timeReportingService.GetAllProjects();
                    Meny();
                    break;

                case 6:
                    Console.WriteLine("______________________________________________________________\n");
                    timeReportingService.EntriesLog();
                    Meny();
                    break;
                case 7:
                    timeReportingService.GetAllPersons();
                    Console.Write("\nEnter person ID: ");
                    int personIdList = int.Parse(Console.ReadLine());
                    Console.WriteLine("______________________________________________________________\n");
                    timeReportingService.GetPersonAndTimeListRegisteredOnProjectId(personIdList);
                    Meny();
                    return;
                case 8:
                    timeReportingService.GetAllProjects();
                    Console.Write("\nEnter project ID: ");
                    int projectIdList = int.Parse(Console.ReadLine());
                    Console.WriteLine("______________________________________________________________\n");
                    timeReportingService.GetPersonsListRegisteredOnProjectId(projectIdList);
                    Meny();
                    return;

                case 9:
                    Console.WriteLine("Thank you for using our service!");
                    return;
                default:
                    Console.WriteLine("Not an option");
                    Meny();
                    break;
            }
        }
    }
}
