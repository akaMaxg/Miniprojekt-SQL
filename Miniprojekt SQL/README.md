##Instruktioner
I detta projekt är tanken att du ska bygga en enklare Console-app i C# som pratar med endatabas. Du behöver använda färdigheter från framförallt Workshop-uppgifterna som handlar om SQL. Du lär även behöva googla fram ledtrådar till hur du ska lösa problemen. Man får samarbeta men det är viktigt att alla bygger sin egen app, utifrån egen förmåga. Du förväntas kunna förklara ungefär vad varje rad kod gör i ditt projekt.

##Vad du ska göra
Du ska skapa ett enklare system för tidsrapportering, med registrering av personer samt projekt. När en person arbetat minst en timme på ett projekt ska det registreras i systemet.

##Start av programmet
När programmet startar ska användaren välkomnas till systemet med en enklare meny
Ingen inloggning behövs
Här finns exempel på databasstruktur.Links to an external site.
Förberedelser
Du kommer att behöva ändra namnet på tabellerna, kkj_person, kkj_project och kkj_project_person. Sätt samma första tre bokstäver som du använde på dina tabeller i WS-uppgifterna.
Databascredentials är: l: monsters p: monsters123 db: monsters (alltså samma som för WS-uppgifterna)

##👉  G-kriterier 
- Projektet ska byggas i Visual Studio med C# och .NET Core 6 som en Console Application
- Alla namn på filer, variabler, metoder etc ska vara på engelska
- Det ska gå att skapa personer samt projekt
- Det ska gå att registrera arbetad tid på ett projekt så att det på något sätt syns i databasen
- Projektet måste innehålla minst tre olika metoder/funktioner som du skapat själv
- Projektet måste versionshanteras med Git. Du ska ha sparat löpande till Github under arbetet.
- Det ska finnas en del kommentarer i koden. Dels som förklarar vad varje metod eller del av koden gör (ex. de olika funktionerna i programmet) samt kommentarer för kodrader som inte är helt uppenbara vad de gör eller hur de fungerar.
- Du ska lägga alla anrop till databasen i en separat klass, som inte innehåller någon meny eller annan logik, se PostgresDataAccess.csLinks to an external site.
- Du behöver lägga in åtminstone en person och ett projekt i databasen, med din kod eller DBGate
- Skapa en databas-dump och döp den till database.sql som ska innehålla strukturen samt exempeldatan du skapat.
- Ingen insert i programmet får skicka med "id" i SQL, dvs ni får inte inserta med primary key satt, detta ska postgres ta hand om.
- Användaren får inte mata in ID i någon del av programmet. Däremot val i meny, t.ex 1, 2, 3 är helt OK

##👉  VG-kriterier 
- Se till att du har bra commit-meddelanden i din Git så det går att förstå vad du lagt till i varje version.

Lägga in grundläggande innehåll i den Readme-fil som finns i ditt Git-repository på Github så att någon som ser projektet för första gången får en kort introduktion till strukturen i koden.
Det ska förutom G-kriterierna även gå att redigera personer, projekt samt bokningar av spenderad tid på projekt (t.ex ändra mängden tid)
Övrigt
Du får lägga till fler fält i dina Models om det behövs, särskilt ProjectPerson (i syfte att visa vilken person och vilket projekt som registrerats när du ska redigera tidsbokningar)
Din inlämning
En länk till ditt repository som ska vara publikt, innehållandes all kod + en README.md samt din databas-dump