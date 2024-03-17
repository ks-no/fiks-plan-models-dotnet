using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.MidlertidigforbudTyper;
using KS.Fiks.Plan.Models.V2.felles.SaksnummerTyper;
using KS.Fiks.Plan.Models.V2.innsyn.MidlertidigeforbudmottiltakFinnResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.MidlertidigeforbudmottiltakFinnTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using KS.Fiks.Plan.Models.V2.oppdatering.MidlertidigforbudmottiltakRegistrerTyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class RegistrerMidlertidigeForbudMotTiltakTests : ModelTestsBase
{
    public RegistrerMidlertidigeForbudMotTiltakTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Registrer_Midlertidige_Forbud_Mot_Tiltak()
    {
        var finnMidlertidigeForbudMottiltak = new RegistrerMidlertidigForbudMotTiltak()
        {
            ForbudOmraade =
                new MidlertidigForbud()
                {
                    Saksnummer = new Saksnummer()
                    {
                        Saksaar = 2024,
                        Sakssekvensnummer = 1
                    },
                    Omraade = new Flate()
                    {
                        Type = FlateType.Polygon,
                        Koordinatsystem = new Koordinatsystem()
                        {
                            Kodeverdi = "",
                            Kodebeskrivelse = ""
                        },
                        Koordinater = new List<ICollection<double>>(4)
                        {
                            new List<double>() { 2.2, 3.3 },
                            new List<double>() { 2.2, 3.3 },
                            new List<double>() { 2.2, 3.3 },
                            new List<double>() { 2.2, 3.3 },
                        }
                    },
                    Avgjoerelsedato = new DateTimeOffset(DateTime.Now),
                    PblTiltakForbudtype = new PblTiltakForbudtype()
                    {
                        Kodeverdi = "",
                        Kodebeskrivelse = ""
                    },
                    GyldigTilDato = new DateTimeOffset(DateTime.Today.AddYears(10))
                }
        };

        var jsonString = JsonConvert.SerializeObject(finnMidlertidigeForbudMottiltak,
            new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.RegistrerMidlertidigForbudMotTiltak);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
}