using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.innsyn.PlanomraaderHentResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.PlanomraaderHentTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class HentPlanomraaderTests : ModelTestsBase
{
    public HentPlanomraaderTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Planomraader()
    {
        var hentPlanomraader = new HentPlanomraader()
        {
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Type = AdministrativEnhetType.Landskode,
                    Nummer = "1"
                },
                Planidentifikasjon = "1"
            }
        };

        var jsonString =
            JsonConvert.SerializeObject(hentPlanomraader, new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.HentPlanomraader);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Planomraader_Resultat()
    {
        var resultat = new HentPlanomraaderResultat()
        {
             Planomraader= new List<planomraader>()
             {
                 new planomraader()
                 {
                     Omraade = new Omraade
                     {
                         YtreAvgrensning = new Flate() {
                             Type = FlateType.Polygon,
                             Koordinatsystem = new Koordinatsystem()
                             {
                                 Kodeverdi = "",
                                 Kodebeskrivelse = ""
                             },
                             Koordinater = new List<ICollection<double>>(4)
                             {
                                 new List<double>() {2.2, 3.3},
                                 new List<double>() {2.2, 3.3},
                                 new List<double>() {2.2, 3.3},
                                 new List<double>() {2.2, 3.3},
                             }
                         },
                         IndreAvgrensninger = new List<Flate>()
                         {
                             new Flate() {
                                 Type = FlateType.Polygon,
                                 Koordinatsystem = new Koordinatsystem()
                                 {
                                     Kodeverdi = "",
                                     Kodebeskrivelse = ""
                                 },
                                 Koordinater = new List<ICollection<double>>(4)
                                 {
                                     new List<double>() {2.2, 3.3},
                                     new List<double>() {2.2, 3.3},
                                     new List<double>() {2.2, 3.3},
                                     new List<double>() {2.2, 3.3},
                                 }
                             }
                         }
                     },
                     Vertikalnivaa = planomraaderVertikalnivaa.På_grunnen_vannoverflate
                 }
             }
        };

        var jsonString =
            JsonConvert.SerializeObject(resultat, new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.ResultatHentPlanomraader);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
}