# Mutantjakt med Stryker

# Introduksjon
Først litt generelt om enhetstesting.

En relativt vanlig del av livet som utvikler er å skrive enhetstester som tester koden vår slik at vi 1) kan være sikre på at logikken som vi har implementert oppfører seg som tenkt, og 2) at endringer som blir gjort i koden på et senere tidspunkt ikke introduserer logiske feil som ellers ikke ville blitt oppdaget. 

Enhetstesting har en tett relasjon til det som kalles kvalitetsattributter for programvare, og blir gjerne brukt som et verktøy for å oppnå et ønsket nivå av korrekthet, robusthet, sikkerhet, og slike ting.

1. En utfordring ved enhetstesting er å skrive gode tester. Det vil si effektive tester som ikke bare dekker happy paths men også edge cases.
1. En metrikk som brukes noen steder er det som kalles "code coverage" eller kodedekning. Det vil si å gjøre en måling av hvor mye av koden som blir aktivert av enhetstester. Forskjellige kriterier:
    * Function coverage
    * Statement coverage
    * Edge coverage
    * Branch coverage
    * Condition coverage
1. Begrep som brukes litt om hverandre: Kodedekning vs. testdekning
1. Vi skal se litt på kodedekning idag, og hvis alt går etter planen så vil vi få en håndfast demonstrasjon av hvorfor god kodedekning kan gi et falskt inntrykk av hvor godt testene dine faktisk tester logikken i koden din.

# Demo: Prosjekt og tester
1. Åpne solution  (bruk VS Preview fordi .net 7) og vis kalkulatoren + testene
1. Kjør testene og vis at alle er grønne

# Demo: Code coverage
1. Åpne powershellterminal og kjør powershellscriptet
1. Bruker coverlet og dotnet-reportgenerator
1. Demonstrer at vi har 100% code coverage

# Stryker
1. Åpne https://stryker-mutator.io/
    1. Stryker er et verktøy for å gjøre mutasjonstesting
    1. Hva er mutasjonstesting? => Tegning i OneNote
    1. Støtter Javascript, C# og Scala
1. Åpne en terminal og gå til mappen med testprosjektet.
```cmd
dotnet new tool-manifest --force
dotnet tool install dotnet-stryker
dotnet stryker
```

1. Stryker genererte 12 mutanter
1. Testene våre tok livet av 7 mutanter, men 5 overlevde. 
1. Vi ønsker ikke at mutanter overlever.
1. Åpne rapporten og se kjapt over mutantene
1. Nå skal vi forbedre testene våre slik at vi får tatt livet av alle mutantene
## Subtrahering: Block removal
Block removal betyr at Stryker fjernet koden, men testen feilet ikke.
1. Gå til testkoden og endre Subtraher() til `return 0;`
1. Kjør testen og vis at den ikke feiler
1. Dette tyder på at selv om testen dekker hele koden, så er det en svak test
1. Legg til ny InlineData(2,1,1) som får testen til å feile

## Multiplikasjon: Arithmetic mutation 1
1. Stryker endret * til /
1. Legg til `[InlineData(2, 2, 4)]`

## Divisjon: Block removal
1. DivideByZeroException blir kastet uansett, så når Stryker fjernet den blokken så gjorde det ingen forskjell
1. Dette er default oppførsel, men det visste ikke jeg da jeg skrev koden -- Stryker fortalte meg heldigvis det!:D

## Divisjon: Arithmetic mutation
1. Stryker endret / til *
1. Legg til to nye testcases
```csharp
[InlineData(4,2,2,0)]
[InlineData(5,2,2,1)]
```

# Talking points:
1. Stryker dokumentasjon: https://stryker-mutator.io/docs/stryker-net/mutations 
1. Mutasjonstesting gir deg konkrete forslag til testcases som du kanskje ikke har tenkt på
1. Gir mutasjonstesting et bedre bilde av kvaliteten på testene dine? Sammenlignet med f.eks code coverage.
1. Stryker tar litt tid å kjøre. Kan derfor være en fordel å kjøre det i en CI-pipeline og publisere rapporten.

# Gotchas
1. Stryker ser ut til å tryne hvis man kjører i en mappe som inneholder mellomrom i navnet.

# Andre ting
## VS Code Markdown Editor
1. Preview
1. Syntax highlighting
1. Outline view (venstre)
# VS Code web
1. Åpne mappe
1. Bruk markdown editor+preview
1. Åpne repo fra Github
