# Produserer nuget som inneholder json skjema og genererte modeller for Fiks Plan protokollen

## Skript for å generere modeller

`GenerateModels.sh` forventer at json-skjemaene er plassert under `/Schema/V2`. Den kopierer kopierer json skjema og genererr C# klasser i prosjektet `KS.Fiks.Plan.Models` som blir pakket til nuget.

Se readme.md i `KS.Fiks.Plan.Models.V2` for bruk av nuget.