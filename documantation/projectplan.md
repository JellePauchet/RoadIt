# Projectplan RoadIt
*Robbroeckx Samme, Pauchet Jelle en Boen Matthias*

----

[TOC]

----

## Projectomschrijving
### Probleemstelling

Er werken verscheidene partijen mee bij het leggen van asfalt. Een duidelijke en snelle communicatie tussen verschillende bedrijven is echter niet makkelijk. Daardoor is elke partij niet steeds volledig op de hoogte is van de stand van zaken. Elk bedrijf houd op zijn eigen manier data bij van hun deel van het proces. De data is achteraf ook niet makkelijk noch centraal bereikbaar. Daardoor kunnen de onderzoekers van UA geen globale trends ontdekken die kunnen leiden tot een betere wegeninfrastructuur.

### Doel van het project

Men kan een werf selecteren waarbij de datasets – of een selectie ervan – vertaald word in een duidelijk rapport (Figuur 1). Hiervoor wordt een app ontwikkeld die toelaat een rapport te genereren met resultaten (detail of generalistisch) van een bepaalde werf per toegangsniveau tot de database.

> ![Figuur 1](https://raw.githubusercontent.com/JellePauchet/RoadIt/master/documantation/img/projectplanFig1.PNG)
> Figuur 1

### Methodologie

#### Werkwijze samenwerking

We werken volgens het Agile-werkingsprincipe. We spreken wekelijks af te UA campus Groenenborger om samen met dhr Muddsair onze vorderingen te overlopen.

#### Werkwijze applicatie / Verwachte resultaten

Men meldt aan op de webapplicatie en laat daarbij indirect diens security clearance weten, zie Mockups Figuur 2. Men selecteert de gewenste data en diens eenheden en manier van weergave, zie Mockups Figuur 3 en Figuur 4. Het webplatform raadpleegt de database en kopieert de selectiedata naar een lokale database op het webplatform. Het verwerkt de data en bereid ze voor om gevisualiseerd te worden. Het platform stuurt deze klant-en-klare data door naar de client waar de data overzichtelijk en éénduidig word gevisualiseerd, zie Mockups Figuur 5.

## Technologie

- MySQL-database
- AngularJS
- NodeJS
- Bootstrap
- SQL
- Git

## Uitkomst voor de maatschappij

De actoren zullen de verzamelde gegevens van verscheidene bedrijven en fases in het proces te raadplegen zijn vanuit één platform. Elk stuk asfalt heeft een soort van info fiche met alle data vanaf begin van productie tot wanneer de asfalt volledig afgewerkt is. Wetenschappers kunnen deze later raadplegen om trends te zoeken voor bepaalde karakteristieken van asfalt (bv. duurzaamheid, geluidshinder, droogtijd, remafstand, reactie bij nat weer, ...).

## User stories / Actoren
### Actoren

- Opdrachtgever
- Asfaltproducent
- Transporteurs
- Aannemer
- Copro
- UA/OCW

### User stories

#### Opdrachtgever
- Makkelijk en overal de volgende data kunnen raadplegen
 - administratieve gegevens van een asfaltbatche uit de asfaltcentrale
 - administratieve gegevens van een asfalttransport en de actuele locatie
 - alle gegevens omtrent de spreidmachine, walsen en de kwaliteitscontrole

#### Asfaltproducent
- Makkelijk en overal de volgende data kunnen raadplegen
 - de benodigde hoeveelheid asfalt per dag
 - alle gegevens van de asfaltcentrale
 - alle gegevens van het asfalttransport
 - conformiteit asfaltmengsels en steekproeven van de kwaliteitscontrole

#### Transporteurs
- Makkelijk en overal kunnen raadplegen van alle data omtrent het transport

#### Aannemer
- Makkelijk en overal kunnen raadplegen van alle de data exclusief de specifieke gegevens van de asfaltcentrale

#### Copro
- Makkelijk en overal de volgende data kunnen raadplegen
 - de benodigde hoeveelheid asfalt per dag
 - alle gegevens van de asfaltcentrale
 - logistieke gegevens van het transport
 - controleproeven van de kwaliteitscontrole

#### UA/OCW
- Makkelijk en overal kunnen raadplegen alle data

## Mockups

> ![Figuur 2](https://raw.githubusercontent.com/JellePauchet/RoadIt/master/documantation/img/projectplanFig2.PNG)
> Figuur 2

> ![Figuur 3](https://raw.githubusercontent.com/JellePauchet/RoadIt/master/documantation/img/projectplanFig3.PNG)
> Figuur 3

> ![Figuur 4](https://raw.githubusercontent.com/JellePauchet/RoadIt/master/documantation/img/projectplanFig4.PNG)
> Figuur 4

> ![Figuur 5](https://raw.githubusercontent.com/JellePauchet/RoadIt/master/documantation/img/projectplanFig5.PNG)
> Figuur 5

## Links

- [Github](https://github.com/JellePauchet/RoadIt)
