using KS.Fiks.Plan.Models.V2.innsyn.AktoererHentResultatTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ModelTests;

public class HentAktoerer : ModelTestsBase
{
    public HentAktoerer(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Aktoerer_Resultat()
    {
        var hentAktoererResultat = new HentAktoererResultat()
        {
            Aktoerer = new List<aktoerer>() { new aktoerer() { Rolle = "Testrolle" } }
        };

        var jsonString =
            JsonConvert.SerializeObject(hentAktoererResultat, new Newtonsoft.Json.Converters.StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.ResultatHentAktoerer);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
}