# Huskeliste
* Start docker
* Åpne Windows Terminal (ubuntu) og ```cd "/mnt/c/Projects/Fagfredag/2022-06-24 Structurizr"```
* Åpne 2x VS Code: 
    - Notater
    - Demovindu
* Rydd bort ting i https://app.ilograph.com/new/

# Intro/Presentasjon
Kjør presentasjon. Ikke bruk for mye tid :-o

# Structurizr Cloud
- Naviger til https://structurizr.com/dsl
- Forklar UI'et: DSL-kode til venstre, rendering til høyre
- Paste inn DSL fra workspace.dsl (originalt er det bare en enkel modell med ett view)
- En enkelt modell, to views
- Demonstrer views ved å bruke dropdown
    - Talking points:
        - En modell, to views
        - Zooming ved å klikke i tegningen
- Demonstrer eksport til Mermaid og paste inn i Wiki på devops 
    - (PlantUML demonstrerer vi med Structurizr CLI)
    - Link: https://dev.azure.com/lanekassen/Modulis/_wiki/wikis/Modulis.wiki/31/Utviklingsveiledning


# Structurizr Lite
- Structurizr Lite er en lite-versjon av Structurizr Cloud 
- Kjøres lokalt som et docker-image
- Aksessere med nettleser 

- Talking points:
    - Gjør bare en enkel visualisering av en modell på samme måte som Structurizr Cloud. 
    - Gjør det mulig å jobbe med modellering lokalt og få endringene visualisert kjapt.
    - Har mulighet til å eksportere til HTML (interaktiv), SVG og PNG
    - Ikke mulighet til å eksportere til PlantUML, Mermaid, osv.

```powershell
docker pull structurizr/lite:latest
```
```powershell
docker run -it --rm -p 8080:8080 -v "$(pwd)":/usr/local/structurizr structurizr/lite
```

- Åpne http://localhost:8080 i nettleser
    - Hvis det ikke funker i Chrome, prøv Edge

# Structurizr CLI
- Talking points:
    - Verktøy for å pushe og pulle modeller til/fra Structurizr Cloud
    - Også en del verktøy for å gjøre eksportering og konvertering
    - Vis at det ble generert to views: Context og Container
    - Visualiser direkte i VS Code

```powershell
docker pull structurizr/cli:latest
docker run -it --rm -v "$(pwd)":/usr/local/structurizr structurizr/cli export -w workspace.dsl -f plantuml -o output
```

# Structurizr for .NET
## Eksplisitt modellering (notebook)
- Åpne Structurizr-Code.dib
- Talking points:
    - Som nevnt så kan vi bruke C# for å modellere
    - Kan brukes på to måter: 
        - Eksplisitt modellering, som vi skal se på nå        
        - Implisitt modellering med annotering av eksisterende kode, f.eks entiteter, kontroller, repositories, etc.

- Kjør demo i notebook
    - NB! Output fra PlantUML havner i output-mappa

## Implisitt modellering (Visual Studio)
- Åpne visual studio (Lk.Fagfredag.Demo)
- Step gjennom koden
- Kjør den uten annotering først og vis hvordan modellen ser ut

NB! Bruk samme Ubuntu-terminal.
```powershell   
# Bygg og kjør prosjektet
dotnet build Lk.Fagfredag.Demo/
dotnet run --project Lk.Fagfredag.Demo/ > workspace.json && docker run -it --rm -v "$(pwd)":/usr/local/structurizr structurizr/cli export -f plantuml -w workspace.json -o output
```
- Vis at man får et UML-diagram med lite info
- Kommenter inn Component Finder i Program.cs og kjør kommandoen på nytt:

```powershell   
dotnet run --project Lk.Fagfredag.Demo/ > workspace.json && docker run -it --rm -v "$(pwd)":/usr/local/structurizr structurizr/cli export -f plantuml -w workspace.json -o output
```

- Vis at man nå får mer informasjon i UML-diagrammet
- Talking points:
    - Viewet ble beriket med informasjon fra de annoterte klassene
    - Case for kodegenerering? OpenAPI?
    - Bonus: ilograph:

```powershell   
dotnet run --project Lk.Fagfredag.Demo/ > workspace.json && docker run -it --rm -v "$(pwd)":/usr/local/structurizr structurizr/cli export -f ilograph -w workspace.json -o output
```
Naviger til https://app.ilograph.com/new/ og paste.
Vis at man kan endre view med zoom-kontrollen