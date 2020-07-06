<h2>Installatiehandleiding Case</h2>

<h3>Benodigdheden</h3>
<p>Het uitvoeren van zowel de ASP.NET Web API (backend) applicatie als de Angular (frontend) applicatie vereist dat de gebruiker een systeem met Windows OS heeft met daarop de onderstaande software geïnstalleerd.</p>

<a src="https://visualstudio.microsoft.com/downloads/">Visual Studio 2019</a>
<a src="https://nodejs.org/en/download/">Node.js</a>
<a src="https://cli.angular.io/">Angular CLI</a>

<h3>Clone</h3>
<p>Clone de link van het project door op de hoofdpagina op de knop 'Code' en vervolgens op het 'clipboard' icoon te klikken.</p>
<p>Via de terminal kan het project worden gecloned door het volgende command uit te voeren:</p>
<p>$ git clone {de zojuist gekopieerde link}</p>

<h3>Backend</h3>
<p>Voor het uitvoeren van de ASP.NET Web API applicatie open je de solution file met Visual Studio 2019: 'CaseTW/backend/Course/Course.sln'.</p>
<p>Via de Solution Explorer rechtermuisklik op 'Course' en selecteer 'Set as startup project'.</p>
<p>Via de Package Manager Console voer je het volgende commando uit: 'Update-Database'.</p>
<p>Via 'Build', 'Rebuild Solution' wordt de applicatie gestart.</p>
<br>
<p>Eventuele meldingen rondom Nuget Packages kunnen worden opgelost door vanuit 'Tools', 'Options', 'NuGet Package Manager' onder het kopje 'Package Restore options' 'Allow NuGet to download missing packages' aan te vinken.</p>
<br>
<p>Eventuele meldingen rondom het vertrouwen van het IIS Express SSL certificaat kunnen worden opgelost door op 'Ja' te klikken.</p>
<br>
<p>Zodra de browser opent zal deze navigeren naar 'https://localhost:44309/', het adres waarop de applicatie draait.</p>

<h3>Frontend</h3>
<p>Middels de terminal, navigeer je naar 'CaseTW/frontend/course'.</p>
<p>Vanuit de terminal voer je de volgende commando's uit:</p>
<p>'$ npm install' voor het installeren van de NPM packages in het package.json bestand.</p>
<p>'$ npm install -g @angular/cli' voor het installeren van de Angular CLI.</p>
<p>'$ ng serve --open' voor het compileren en starten van de applicatie.</p>
<br>
<p>Nadat het derde commando is uitgevoerd zal na enkele seconden een browser zich openen en navigeren naar 'http://localhost:4200/'. De applicatie navigeert automatisch naar het cursusinstantie-overzicht van de huidige week. CursusInstanties en Cursussen kunnen worden toegevoegd middels de overzicht pagina, te benaderen via de 'Overzicht' knop in de navigatiebar.</p>

<h3>Tests</h3>
<p>Voor het uitvoeren van de tests kan er vanuit Visual Studio 2019 met de rechtermuisknop op 'Course.Tests' worden geklikt en vervolgens op 'Run Tests'.</p>