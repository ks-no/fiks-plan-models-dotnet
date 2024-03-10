using KS.Fiks.Plan.Models.V2.felles.DispensasjonTyper;
using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.PosisjonTyper;
using KS.Fiks.Plan.Models.V2.innsyn.DispensasjonerFinnResultatTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ModelTests;

public class FinnDispensasjonerTests : ModelTestsBase
{
    public FinnDispensasjonerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Dispensasjoner_Resultat()
    {
        var finnDispensasjonerResultat = new FinnDispensasjonerResultat()
        {
            Dispensasjoner = new List<Dispensasjon>()
            {
                new Dispensasjon()
                {
                    Posisjon = new Posisjon()
                    {
                        Type = PosisjonType.Point,
                        Koordinatsystem = new Koordinatsystem() // Kode
                        {
                            Kodeverdi = "",
                            Kodebeskrivelse = ""
                        }
                    },
                    DispensasjonType = new DispensasjonType() // Kode
                    {
                        Kodeverdi = "",
                        Kodebeskrivelse = ""
                    },
                    DispensasjonFra = new DispensasjonFra() // Kode
                    {
                        Kodeverdi = "",
                        Kodebeskrivelse = ""
                    },
                    Vertikalnivaa = new Vertikalnivaa() // Kode
                    {
                        Kodeverdi = "",
                        Kodebeskrivelse = ""
                    }
                }
            }
        };

        var jsonString = JsonConvert.SerializeObject(finnDispensasjonerResultat,
            new Newtonsoft.Json.Converters.StringEnumConverter());

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