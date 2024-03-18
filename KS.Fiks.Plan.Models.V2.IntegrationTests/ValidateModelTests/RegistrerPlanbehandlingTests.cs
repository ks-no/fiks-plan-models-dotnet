using KS.Fiks.Plan.Models.V2.felles.DispensasjonTyper;
using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.felles.PlanbehandlingTyper;
using KS.Fiks.Plan.Models.V2.felles.PosisjonTyper;
using KS.Fiks.Plan.Models.V2.felles.SaksnummerTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using KS.Fiks.Plan.Models.V2.oppdatering.DispensasjonRegistrerKvitteringTyper;
using KS.Fiks.Plan.Models.V2.oppdatering.DispensasjonRegistrerTyper;
using KS.Fiks.Plan.Models.V2.oppdatering.PlanavgrensningRegistrerTyper;
using KS.Fiks.Plan.Models.V2.oppdatering.PlanbehandlingRegistrerTyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class RegistrerPlanbehandlingTests : ModelTestsBase
{
    public RegistrerPlanbehandlingTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Registrer_Planbehandling()
    {
        var registrerPlanavgrensning = new RegistrerPlanbehandling()
        {
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Type = AdministrativEnhetType.Kommunenummer,
                    Nummer = "1"
                },
                Planidentifikasjon = "Plan-Id"
            },
            Planbehandling = new Planbehandling()
            {
                Navn = "",
                Posisjon = new Posisjon()
                {
                    Type = PosisjonType.Point,
                    Koordinatsystem = new Koordinatsystem() // Kode
                    {
                        Kodeverdi = "",
                        Kodebeskrivelse = ""
                    },
                    Koordinater = new List<double>(2)
                    {
                        2.2,
                        2.2
                    }
                },
                Planbehandlingtype = new Planbehandlingtype() // Kode
                {
                    Kodeverdi = "",
                    Kodebeskrivelse = ""
                }
            }
        };

        var jsonString =
            JsonConvert.SerializeObject(registrerPlanavgrensning, new StringEnumConverter());
        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.RegistrerPlanavgrensning);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
}