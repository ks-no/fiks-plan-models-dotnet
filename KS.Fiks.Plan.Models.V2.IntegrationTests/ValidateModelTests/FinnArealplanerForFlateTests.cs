using KS.Fiks.Plan.Models.V2.felles.ArealplanTyper;
using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanerFinnForAdresseTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanerFinnForFlateTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanerFinnResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanerFinnTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class FinnArealplanerForFlateTests : ModelTestsBase
{
    public FinnArealplanerForFlateTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Arealplaner_For_Flate()
    {
        var finnArealplaner = new FinnArealplanerForFlate()
        {
            Flate = new Flate()
            {
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
        };
        
        var jsonString = JsonConvert.SerializeObject(finnArealplaner,
            new Newtonsoft.Json.Converters.StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.FinnArealplanerForFlate);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
    
    [Fact]
    public void Opprett_Og_Valider_Finn_Arealplaner_Resultat()
    {
        var finnArealplanerResultat = new FinnArealplanerResultat()
        {
            Arealplaner = new List<Arealplan>()
            {
                new Arealplan()
                {
                    NasjonalArealplanId = new NasjonalArealplanId()
                    {
                        AdministrativEnhet = new AdministrativEnhet()
                        {
                            Type = AdministrativEnhetType.Kommunenummer,
                            Nummer = "1"
                        },
                        Planidentifikasjon = "",
                    },
                    Plannavn = "",
                    Planstatus = new Planstatus()
                    {
                        Kodeverdi = "2",
                        Kodebeskrivelse = "Planforslag"
                    },
                    Plantype = new Plantype() // Kode
                    {
                        Kodeverdi = "21",
                        Kodebeskrivelse = "Kommunedelplan"
                    },
                    PlandokumentasjonOppdatert = false,
                    ForslagstillerType = new ForslagstillerType()
                    {
                        Kodeverdi = "2",
                        Kodebeskrivelse = "privat"
                    },
                    UbehandletKlage = false,
                    AlternativFinnes = true,
                }
            }
        };
        
        var jsonString = JsonConvert.SerializeObject(finnArealplanerResultat,
            new Newtonsoft.Json.Converters.StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.ResultatFinnArealplaner);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
}