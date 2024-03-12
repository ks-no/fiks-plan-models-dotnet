using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.felles.PlanbehandlingTyper;
using KS.Fiks.Plan.Models.V2.felles.PosisjonTyper;
using KS.Fiks.Plan.Models.V2.innsyn.PlanbehandlingerFinnResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.PlanbehandlingerFinnTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class FinnPlanbehandlingerTests : ModelTestsBase
{
    public FinnPlanbehandlingerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Planbehandlinger()
    {
        var finnPlanbehandlinger = new FinnPlanbehandlinger()
        {
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Type = AdministrativEnhetType.Fylkesnummer,
                    Nummer = "1"
                },
                Planidentifikasjon = "1"
            },
            InkluderPlandokumenter = true
        };
        
        var jsonString = JsonConvert.SerializeObject(finnPlanbehandlinger, new Newtonsoft.Json.Converters.StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");
            
        var jObject = JObject.Parse(jsonString);
            
        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.FinnPlanbehandlinger);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }
        Assert.True(isValid);
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Planbehandlinger_Resultat()
    {
        var finnPlanbehandlingerResultat = new FinnPlanbehandlingerResultat()
        {
            Planbehandlinger = new List<Planbehandling>() { 
                new Planbehandling()
                {
                    Navn = "",
                    Posisjon = new Posisjon()
                    {
                        Type = PosisjonType.Point,
                        Koordinatsystem = new Koordinatsystem() // Kode
                        {
                            Kodeverdi = "",
                            Kodebeskrivelse = ""
                        }
                    },
                    Planbehandlingtype = new Planbehandlingtype() // Kode
                    {
                        Kodeverdi = "",
                        Kodebeskrivelse = ""
                    }
                }
            }
        };
            
        var jsonString = JsonConvert.SerializeObject(finnPlanbehandlingerResultat, new Newtonsoft.Json.Converters.StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");
            
        var jObject = JObject.Parse(jsonString);
            
        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.ResultatFinnPlanbehandlinger);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }
        Assert.True(isValid);
    }
}