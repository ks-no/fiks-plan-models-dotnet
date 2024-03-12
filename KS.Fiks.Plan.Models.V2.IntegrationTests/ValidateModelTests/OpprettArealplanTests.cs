using KS.Fiks.Plan.Models.V2.felles.ArealplanTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.felles.SaksnummerTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using KS.Fiks.Plan.Models.V2.oppdatering.ArealplanOpprettKvitteringTyper;
using KS.Fiks.Plan.Models.V2.oppdatering.ArealplanOpprettTyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class OpprettArealplanTests : ModelTestsBase
{
    public OpprettArealplanTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Opprett_Arealplan()
    {
        var opprettArealplan = new OpprettArealplan()
        {
            Plannavn = "Test",
            Plantype = new Plantype()
            {
                Kodebeskrivelse = "",
                Kodeverdi = ""
            },
            Planstatus = new Planstatus()
            {
                Kodebeskrivelse = "",
                Kodeverdi = ""
            },
            Lovreferanse = new Lovreferanse()
            {
                Kodeverdi = "",
                Kodebeskrivelse = ""
            },
            Saksnummer = new Saksnummer()
            {
                Saksaar = 2024,
                Sakssekvensnummer = 1
            }
        };

        var jsonString =
            JsonConvert.SerializeObject(opprettArealplan, new Newtonsoft.Json.Converters.StringEnumConverter());
        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.OpprettArealplan);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
    
    [Fact]
    public void Opprett_Og_Valider_Opprett_Arealplan_Kvittering()
    {
        var opprettArealplanKvittering = new OpprettArealplanKvittering()
        {
            Saksnummer = new Saksnummer()
            {
                Saksaar = 2024,
                Sakssekvensnummer = 1
            },
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Type = AdministrativEnhetType.Fylkesnummer,
                    Nummer = "1"
                },
                Planidentifikasjon = "1"
            },
        };

        var jsonString =
            JsonConvert.SerializeObject(opprettArealplanKvittering, new Newtonsoft.Json.Converters.StringEnumConverter());
        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.KvitteringOpprettArealplan);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
}