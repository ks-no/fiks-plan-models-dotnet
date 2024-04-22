using KS.Fiks.Plan.Models.V2.felles.ArealplanTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanerFinnForMatrikkelenhetTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanerFinnResultatTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class FinnArealplanerForMatrikkelenhetTests : ModelTestsBase
{
    public FinnArealplanerForMatrikkelenhetTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Arealplaner_For_Matrikkelenhet()
    {
        var finnArealplaner = new FinnArealplanerForMatrikkelenhet()
        {
            Matrikkelnummer = new Matrikkelnummer()
            {
                Kommunenummer = "4601",
                Gaardsnummer = 76,
                Bruksnummer = 1
            }
        };
        
        var jsonString = ValidateWithSchema(finnArealplaner, FiksPlanMeldingtypeV2.FinnArealplanerForMatrikkelenhet);
        WriteJsonSampleFile("Requests/FinnArealplanerForMatrikkelenhet", jsonString);
    }
}