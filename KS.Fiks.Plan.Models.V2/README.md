# KS.Fiks.Plan.Models.V2

## Innhold

### Genererte C# modeller
Koden er generert fra json schema i spesifikasjonen.

### Json schema
Json schema filene er med i nuget pakken som **EmbeddedResource**. 
Det vil si at skjemaene ikke er med som filer sammen med dll-filen når man henter ned nuget-pakken, men er tilgjengelig som ressurser i dll-filen.
Se eksempel under for hvordan man kan laste inn skjema-filene. 
#### Eksempel hente json schema


```
Assembly assembly = Assembly.LoadFrom("KS.Fiks.Plan.Models.V2.dll");

//List alle skjema
string[] resourceNames = assembly.GetManifestResourceNames();
foreach (string resourceName in resourceNames)
{
Console.WriteLine(resourceName);
}

//Hent ut et skjema
var stream = assembly.GetManifestResourceStream("KS.Fiks.Plan.Models.V2.Schema.V2.no.ks.fiks.plan.v2.oppdatering.planbehandling.registrer.schema.json");
if (stream == null)
{
return;
}
using (StreamReader reader = new StreamReader(stream))
{
string text = reader.ReadToEnd();
Console.WriteLine(text);
}
```
