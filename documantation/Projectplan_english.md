# Projectplan RoadIt
*Robbroeckx Samme, Pauchet Jelle and Boen Matthias*

----

[TOC]

----

## Project description
### Problem definition

Several parties cooperate in laying asphalt. A clear and quick communication between different companies is not easy. As a result, each party is not always fully aware of the situation. Each company hold its data of their part of the process in its own way. The data is afterwards not easy nor centrally accessible. As a result, the researchers of UA can not detect broad trends that may lead to a better road infrastructure.

### Goal of the project

One can select a construction site in which the data sets - or a selection of them - become translated into a clear report (Figure 1). To this end, an app will be developed that allows you to generate a report of results (detailed or generalist) of a given site per level of access to the database.
> ![Figure 1](https://raw.githubusercontent.com/JellePauchet/RoadIt/master/documantation/img/projectplanFig1.PNG)
> Figure 1

### Methodology

#### Process collaboration

We work according to the Agile operating principle. We go weekly to the UA campus Groenenborger to overflow our progress together with Mr. Muddsair.

#### Process application / Expected results

One reports to the web application and thereby indirectly let it know his security clearance, see "Mockups" Figure 2. You select the data and its units and manner of display, see "Mockups" Figure 3 and Figure 4. The web platform consults the database and copies the selection data to a local database on the web platform. It processes the data and prepared them to be visualized. The platform sends this ready-to-use data to the client where the data become visualized clearly and unequivocally, see "Mockups" Figure 5.

## Technology

- MySQL-database
- AngularJS
- NodeJS
- Bootstrap
- SQL
- Git

## Outcome for society

The actors will view the collected data from various companies and stages in the process on a single platform. Each piece of asphalt has some kind of information sheet with all the data from the beginning of production until the asphalt is completely finished. Scientists can look at it later to search trends for certain characteristics of asphalt (eg. Durability, noise, drying, braking distances, response in wet weather, ...).

## User stories / Actors
### Actors

- Principal
- Asphaltproducent
- Transportors
- Contractor
- Copro
- UA/OCW

### User stories

#### Principal
- As principal, I want to consult administrative data of an asphaltbatch form an asfalt mix plant in an easy manner and everywhere.
- As principal, I want to consult administrative data of an asphalttransport and its location in an easy manner and everywhere.
- As principal, I want to consult all data on finicher, compactor and the qualitycontrol in an easy manner and everywhere.


#### asphaltproducent
- As an asphaltproducent, I want to consult the daily required amount of asfalt in an easy manner and everywhere.
- As an asphaltproducent, I want to consult all data of the asphaltmix plant in an easy manner and everywhere.
- As an asphaltproducent, I want to consult all data of an asphalttransport in an easy manner and everywhere.
- As an asphaltproducent, I want to consult compliance mixtures and see samples of Copro in an easy manner and everywhere.

#### Transporter
- As an transporter, I want to consult all data about the transport in an easy manner and everywhere.

#### Contractor
- As an contractor, I want to consult all data exclusive the technical data of the asphaltbatch in an easy manner and everywhere.

#### Copro
- As Copro, I want to consult the daily required amount of asphalt in an easy manner and everywhere.
- As Copro, I want to consult all data of the asphalt mix plant in an easy manner and everywhere.
- As Copro, I want to consult the logistics data of transport in an easy manner and everywhere.
- As Copro, I want to consult the samples made by us in an easy manner and everywhere.

#### UA/OCW
- As UA or OCW, I want to consult all data in an easy manner and everywhere.

## Mockups

> ![Figure 2](https://raw.githubusercontent.com/JellePauchet/RoadIt/master/documantation/img/projectplanFig2.PNG)
> Figure 2

> ![Figure 3](https://raw.githubusercontent.com/JellePauchet/RoadIt/master/documantation/img/projectplanFig3.PNG)
> Figure 3

> ![Figure 4](https://raw.githubusercontent.com/JellePauchet/RoadIt/master/documantation/img/projectplanFig4.PNG)
> Figure 4

> ![Figure 5](https://raw.githubusercontent.com/JellePauchet/RoadIt/master/documantation/img/projectplanFig5.PNG)
> Figure 5

## Links

- [Github](https://github.com/JellePauchet/RoadIt)
