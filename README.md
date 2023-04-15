# Max Guclu, FS.NET, 2023-04-15

## Introduction 
This console application was created by *Max Guclu* The project was conducted as part of a *C#-course* in a *Fullstack .NET* program at **Chas Academy**.   

## Application structure and Requirements
This console application was developed in **C#** and utilizes a **PostgreSQL** database along with **Entity Framework**. The purpose of this application is to demonstrate basic *CRUD* (Create, Read, Update, Delete) operations on a database. The key for the database connection is located in a git-ignored app file.

The program revolves around two primary objects *Person* and *Project* with list of properties derived from their database tables. The application also contains a number of classes and functionality as per required by the assignment:

- ***Projektet ska byggas i Visual Studio med C# och .NET Core 6 som en Console Application***   
OK   
- ***Alla namn på filer, variabler, metoder etc ska vara på engelska***   
OK   
- ***Det ska gå att skapa personer samt projekt***   
Ok, TimeReportingServices class contains methods that can create both object and persist them to DB   
- ***Det ska gå att registrera arbetad tid på ett projekt så att det på något sätt syns i databasen***   
OK, TimeReportingServices class contains methods that can add 'hours' to entries in ProjectPerson DB table    
- ***Projektet måste innehålla minst tre olika metoder/funktioner som du skapat själv***   
OK, All are created by MGu   
- ***Projektet måste versionshanteras med Git. Du ska ha sparat löpande till Github under arbetet***   
OK   
- ***Det ska finnas en del kommentarer i koden. Dels som förklarar vad varje metod eller del av koden gör (ex. de olika funktionerna i programmet) samt kommentarer för kodrader som inte är helt uppenbara vad de gör eller hur de fungerar***
OK, code is commented   
- ***Du ska lägga alla anrop till databasen i en separat klass, som inte innehåller någon meny eller annan logik, se PostgresDataAccess.csLinks***   
OK, all CRUD-operations in Services-Folder and class TimeReportingServices   
- ***Du behöver lägga in åtminstone en person och ett projekt i databasen, med din kod eller DBGate***   
OK, Few entries made   
- ***Skapa en databas-dump och döp den till database.sql som ska innehålla strukturen samt exempeldatan du skapat***   
OK, See "SQL-Dump"   
- ***Ingen insert i programmet får skicka med "id" i SQL, dvs ni får inte inserta med primary key satt, detta ska postgres ta hand om***   
OK, All CRUD operations are handled by Entitity Framework through LINQ   
- ***Användaren får inte mata in ID i någon del av programmet. Däremot val i meny, t.ex 1, 2, 3 är helt OK***   
OK, User selects from list of persons/projects - not based off ID.

### Additional functionality
-> Used *Entity Framework*
 
## To run program
1.  Download or clone the project files from the Git repository.  
2.  Open the solution or project in an C# IDE.  
3.  Build the project by pressing F6 or navigating to Build > Build Solution.    

-- *Ensure that the key for the connection string is added to the app.config* --  

## Usage
No log-in required. The applications provides the information necessary to test it.

## Contribution  
If you would like to contribute to this project, please feel free to submit a pull request on the Git repository.

## SQL-Dump
DROP TABLE IF EXISTS "public"."mgu_project";   
DROP TABLE IF EXISTS "public"."mgu_project_person";   
DROP TABLE IF EXISTS "public"."mgu_person";   
CREATE TABLE "public"."mgu_project" (    
  "id" SERIAL,   
  "project_name" VARCHAR(50) NOT NULL,   
  CONSTRAINT "mgu_project_pkey" PRIMARY KEY ("id")   
);   
CREATE TABLE "public"."mgu_project_person" (    
  "id" SERIAL,   
  "project_id" INTEGER NOT NULL,   
  "person_id" INTEGER NOT NULL,   
  "hours" INTEGER NOT NULL,   
  CONSTRAINT "mgu_project_person_pkey" PRIMARY KEY ("id")   
);   
CREATE TABLE "public"."mgu_person" (    
  "id" SERIAL,   
  "person_name" VARCHAR(25) NOT NULL,   
  CONSTRAINT "mgu_person_pkey" PRIMARY KEY ("id")   
);   
INSERT INTO "public"."mgu_project" ("id", "project_name") VALUES (1, 'C# Studying');   
INSERT INTO "public"."mgu_project" ("id", "project_name") VALUES (2, 'Databashantering');   
INSERT INTO "public"."mgu_project" ("id", "project_name") VALUES (3, 'Bosses lekstund');   
INSERT INTO "public"."mgu_project_person" ("id", "project_id", "person_id", "hours") VALUES (1, 1, 1, 499);   
INSERT INTO "public"."mgu_project_person" ("id", "project_id", "person_id", "hours") VALUES (2, 1, 2, 20);   
INSERT INTO "public"."mgu_project_person" ("id", "project_id", "person_id", "hours") VALUES (3, 2, 1, 20);   
INSERT INTO "public"."mgu_project_person" ("id", "project_id", "person_id", "hours") VALUES (5, 2, 3, 50);   
INSERT INTO "public"."mgu_project_person" ("id", "project_id", "person_id", "hours") VALUES (7, 3, 4, 5);   
INSERT INTO "public"."mgu_project_person" ("id", "project_id", "person_id", "hours") VALUES (8, 3, 1, 50);   
INSERT INTO "public"."mgu_person" ("id", "person_name") VALUES (1, 'Franky Sinatry');   
INSERT INTO "public"."mgu_person" ("id", "person_name") VALUES (2, 'Gert Götebritta');   
INSERT INTO "public"."mgu_person" ("id", "person_name") VALUES (3, 'Pelle Svanslös');   
INSERT INTO "public"."mgu_person" ("id", "person_name") VALUES (4, 'Bosse');   
ALTER TABLE "public"."mgu_project_person" ADD CONSTRAINT "FK_mgu_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."mgu_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;   
ALTER TABLE "public"."mgu_project_person" ADD CONSTRAINT "FK_mgu_person_project_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."mgu_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION; 

