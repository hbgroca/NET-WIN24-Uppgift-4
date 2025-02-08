# .NET-WIN24-Uppgift-4 

Inlämningsuppgift 4 - Datalagring &#10003;
- I denna inlämningsuppgift ska du bygga en applikation som kommunicerar med en databas med hjälp av C# och .NET. Du väljer själv vilken applikationsform du vill använda: Console, WPF/Avalonia WPF, MAUI, eller React. Varje applikationsplattform har sina egna styrkor och utmaningar. Det är ditt ansvar att utvärdera vilken plattform som bäst uppfyller kraven för godkänt eller väl godkänt.
Observera att vissa plattformar, exempelvis React eller MAUI, kan kräva att du implementerar ett Web API (med ASP.NET Core) för att hantera kommunikationen mellan frontend och backend. Du får använda ett Web API oavsett plattform, men det är inget krav och påverkar inte betygsättningen.

Användning av AI-genererad kod
- Om du använder kod som genererats av AI (exempelvis ChatGPT), måste detta tydligt framgå för att undvika plagiat.

Val av lagringslösning
- Du väljer själv vilken typ av databasmotor du vill använda, exempelvis: Sqlite, LocalDB eller SQL Server. Välj en lösning som passar bäst för din plattform och ditt ändamål. Observera följande: Undvik att lagra känslig information, såsom personnummer, kortuppgifter eller riktiga lösenord, i databasen; Du behöver inte ladda upp din databas till GitHub.

Design och inspiration
- Systemet ska vara strukturerat enligt moderna principer och uppdelat i entities, models, repositories och services. SOLID-principerna ska tillämpas där det är lämpligt. Du får själv välja hur du vill att din applikation ska se ut, det grafiska utseendet bedöms inte, men du kan använda inspiration från Fortnox.

Information om projektuppgiften
- Företaget Mattin-Lassei Group AB vill ha ett system för att hantera sina projekt. Du ska bygga en applikation där användare kan lägga till projekt med uppgifter som projektnummer (t.ex. "P-101"), namn, tidsperiod (start- och slutdatum), projektansvarig, kund, tjänst (t.ex. konsulttid 1000 kr/tim), totalpris och status (ej påbörjat, pågående, avslutat). Projektnumret ska genereras automatiskt och får inte ändras efter att projektet skapats.
- Applikationen ska visa en översikt med alla aktuella projekt och deras projektnummer, namn, tidsperiod och status. Det ska finnas möjlighet att klicka på ett projekt för att komma till en detaljerad vy där alla uppgifter (utom projektnumret) kan redigeras. Användaren ska kunna spara ändringar eller avbryta redigeringen och navigera tillbaka till översikten.



BETYGSKRITERIER FÖR INLÄMNINGSUPPGIFTEN
Här nedan specificeras vad som krävs för att uppnå godkänt respektive väl godkänt. Det är viktigt att notera att det är ett stort steg mellan dessa nivåer, vilket följer de riktlinjer som EC-Utbildning nu tillämpar.

## FÖR GODKÄNT KRÄVS FÖLJANDE:

Frontend-baserad applikation enligt specifikationen ovan med följande:
- En sida som listar alla befintliga projekt. &#10003;
- En sida där man kan skapa ett nytt projekt. &#10003;
- En sida där man kan editera/uppdatera ett befintligt projekt. &#10003;

Ett klassbibliotek med följande:
- Använda Entity Framework Core - Code First. &#10003;
- Använda valfri databaslösning av de som presenterats i kursen/uppgiften. &#10003;
- Använda minst två olika entiteter/tabeller (såsom kund och projekt). &#10003;
- Använda Services för att hantera projekt och kunder. &#10003;
- Använda Repositories för att hantera alla entiteter/tabeller. &#10003;
- Använda Dependency Injection. &#10003;
- Tillämpa S i SOLID (Single Responsibility Principle). (Övriga SOLID-principer är inte ett krav för godkänt.) &#10003;

## FÖR VÄL GODKÄNT KRÄVS FÖLJANDE:
- Frontend-baserad applikation enligt G-kraven. &#10003;
- Ett klassbibliotek enligt G-kraven med följande utökning:
- Använda Repositories som baseras på en BaseClass (Generic). &#10003;
- Använda fler entiteter/tabeller (såsom kund, projektansvarig, projekt, tjänst etc.). &#10003;
- Använda Services för att hantera alla entiteter på ett lämpligt sätt, vilket innebär att man ska kunna hantera CRUD för kunder, projektansvarig, projekt etc. &#10003;
- Tillämpa SOLID-principer där det är lämpligt. &#10003;
- Tillämpa Factories. &#10003;
- Task ska tillämpas där det är lämpligt genom att använda asynkrona metoder och async/await, t.ex. vid databasoperationer. &#10003;
- Tillämpa Transaction Management för att hantera flera beroende operationer som en transaktion, inklusive rollback vid fel.

Utöver dessa kriterier så har jag
- Skapat test för services, factories, repositories.
- Regex på nödvändiga ställen (Epost, telefonnummer och organisationsnummer).
