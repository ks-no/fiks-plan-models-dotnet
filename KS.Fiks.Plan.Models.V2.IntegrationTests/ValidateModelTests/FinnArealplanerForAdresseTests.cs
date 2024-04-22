using KS.Fiks.Plan.Models.V2.felles.ArealplanTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanerFinnForAdresseTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanerFinnResultatTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class FinnArealplanerForAdresseTests : ModelTestsBase
{
    public FinnArealplanerForAdresseTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Arealplaner_For_Adresse()
    {
        var finnArealplaner = new FinnArealplanerForAdresse()
        {
            Adresse = new Adresse()
            {
                Adressenavn = "Eksempelgateveien",
                Adressenummer = 100,
                Adressebokstav = "A"
            }
        };
        
        var jsonString = ValidateWithSchema(finnArealplaner, FiksPlanMeldingtypeV2.FinnArealplanerForAdresse);
        WriteJsonSampleFile("Requests/FinnArealplanerForAdresse", jsonString);
    }
}