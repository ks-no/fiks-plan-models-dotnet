using KS.Fiks.Plan.Models.V2.felles.ArealplanTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanHentResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanHentTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class HentArealplanTests : ModelTestsBase
{
    public HentArealplanTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Arealplan()
    {
        var hentArealplan = new HentArealplan()
        {
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Type = AdministrativEnhetType.Kommunenummer,
                    Nummer = "1"
                },
                Planidentifikasjon = "Test"
            },
            InkluderPlanbehandlinger = true
        };
        
        var jsonString = JsonConvert.SerializeObject(hentArealplan, new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");
        Assert.DoesNotContain("vedtaksdato", jsonString);
            
        var jObject = JObject.Parse(jsonString);
            
        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.HentArealplan);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }
        Assert.True(isValid);
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Arealplan_Resultat()
    {
        var hentArealplanResultat = new HentArealplanResultat()
        {
            Arealplan = new Arealplan()
            {
                NasjonalArealplanId = new NasjonalArealplanId()
                {
                    AdministrativEnhet = new AdministrativEnhet()
                    {
                        Type = AdministrativEnhetType.Kommunenummer,
                        Nummer = "1"
                    },
                    Planidentifikasjon = "Test"
                },
                Plantype = new Plantype()
                {
                    Kodebeskrivelse = "",
                    Kodeverdi = ""
                },
                Plannavn = "Test"
            }
        };
            
        var jsonString = JsonConvert.SerializeObject(hentArealplanResultat, new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");
        Assert.DoesNotContain("vedtaksdato", jsonString);
            
        var jObject = JObject.Parse(jsonString);
            
        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.ResultatHentArealplan);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }
        Assert.True(isValid);
        
        // Deserialize test
        var deserialized = JsonConvert.DeserializeObject<HentArealplanResultat>(jsonString);
        Assert.True(deserialized.Arealplan.NasjonalArealplanId.AdministrativEnhet.Type == AdministrativEnhetType.Kommunenummer);
    }
}