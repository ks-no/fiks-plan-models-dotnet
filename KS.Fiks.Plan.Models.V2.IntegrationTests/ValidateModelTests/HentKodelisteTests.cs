using KS.Fiks.Plan.Models.V2.innsyn.KodelisteHentResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.KodelisteHentTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class HentKodelisteTests : ModelTestsBase
{
    public HentKodelisteTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Kodeliste()
    {
        var hentArealplan = new HentKodeliste()
        {
            Kodelistenavn = "Kodelistenavnet"
        };
        
        var jsonString = JsonConvert.SerializeObject(hentArealplan, new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");
        Assert.DoesNotContain("vedtaksdato", jsonString);
            
        var jObject = JObject.Parse(jsonString);
            
        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.HentKodeliste);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }
        Assert.True(isValid);
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Kodeliste_Resultat()
    {
        var hentKodelisteResultat = new HentKodelisteResultat()
        {
            Koder = new List<koder>()
            {
                new koder()
                {
                    Kodeverdi = "",
                    Kodebeskrivelse = ""
                },
                new koder()
                {
                    Kodeverdi = "",
                    Kodebeskrivelse = ""
                }
            },
            Navn = ""
        };
            
        var jsonString = JsonConvert.SerializeObject(hentKodelisteResultat, new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");
        Assert.DoesNotContain("vedtaksdato", jsonString);
            
        var jObject = JObject.Parse(jsonString);
            
        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.ResultatHentKodeliste);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }
        Assert.True(isValid);
    }
}