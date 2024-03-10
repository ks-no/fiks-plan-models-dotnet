using KS.Fiks.Plan.Models.V2.felles.DispensasjonTyper;
using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.felles.PosisjonTyper;
using KS.Fiks.Plan.Models.V2.felles.SaksnummerTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using KS.Fiks.Plan.Models.V2.oppdatering.DispensasjonRegistrerTyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ModelTests;

public class RegistrerDispensasjonTests : ModelTestsBase
{
    public RegistrerDispensasjonTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Registrer_Dispensasjon()
    {
        // Needed this for the assembly to be loaded
        var registrerDispensasjon = new RegistrerDispensasjon();
        registrerDispensasjon.Dispensasjon = new Dispensasjon()
        {
            Identifikasjon = "1",
            DispensasjonType = new DispensasjonType()
            {
                Kodebeskrivelse = "Forbud",
                Kodeverdi = "111"
            },
            DispensasjonFra = new DispensasjonFra()
            {
                Kodeverdi = "PLAN",
                Kodebeskrivelse = "Arealplaner"
            },
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Type = AdministrativEnhetType.Kommunenummer,
                    Nummer = "1"
                },
                Planidentifikasjon = "Plan-Id"
            },
            Begrunnelse = "Dispensation description",
            Vedtaksdato = new DateTimeOffset(new DateTime(2021, 10, 1)),
            InnvilgetDispensasjon = true,
            Saksnummer = new Saksnummer()
            {
                Saksaar = 2021,
                Sakssekvensnummer = 14
            },
            VarigDispensasjon = true,
            VarighetFra = new DateTimeOffset(new DateTime(2021, 10, 1)),
            VarighetTil = new DateTimeOffset(new DateTime(2029, 10, 1)),
            Vertikalnivaa = new Vertikalnivaa()
            {
                Kodebeskrivelse = "Beskrivelse",
                Kodeverdi = "Test"
            },
            Beskrivelse = "Test",
            Posisjon = new Posisjon()
            {
                Koordinatsystem = new Koordinatsystem()
                {
                    Kodebeskrivelse = "",
                    Kodeverdi = ""
                },
                Koordinater = { 1.1, 2.2 },
                Type = PosisjonType.Point
            }
        };

        var jsonString =
            JsonConvert.SerializeObject(registrerDispensasjon, new Newtonsoft.Json.Converters.StringEnumConverter());
        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.RegistrerDispensasjon);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
}