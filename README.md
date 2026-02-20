# ![](KSDigital25.png) Fiks Plan nuget-pakke og eksempler

## Nuget pakke
Prosjektet `KS.Fiks.Plan.Models.V2` inneholder hjelpeklasser for protokollen og produserer nuget pakken `KS.Fiks.Plan.Models.V2` som inneholder hjelpeklassene, json skjema og genererte modeller for Fiks Plan protokollen.

## Test og eksempler
Det er et test-prosjekt, `KS.Fiks.Plan.Models.V2.IntegrationTests` som viser eksempler på oppbygging av meldingstyper vha de genererte modellene. Testene validerer deretter også json mot skjema.


## Generering

Se prosjektet `KS.Fiks.Plan.JsonModelGenerator` og `Generate.cs` for hvordan genereringen blir gjort

### Skript for å generere modeller

`GenerateModels.sh` forventer at json-skjemaene er plassert under `/Schema/V2`. 
Den kopierer kopierer json skjema og genererer C# klasser i prosjektet `KS.Fiks.Plan.Models` som blir pakket til nuget.

Bygg-pipeline med Jenkinsfile sørger for å hente siste versjon av skjema fra specification prosjektet [fiks-plan-specification](https://github.com/ks-no/fiks-plan-specification)

## Eksempler

Se [readme.md](https://github.com/ks-no/fiks-plan-models-dotnet/blob/main/KS.Fiks.Plan.Models.V2/README.md) i `KS.Fiks.Plan.Models.V2` for bruk av nuget pakken og eksempler.


Før bygg må submodul hentes:
```shell
git submodule  update --init --recursive --remote
```