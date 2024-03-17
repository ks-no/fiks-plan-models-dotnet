using KS.Fiks.Plan.Models.V2.felles.DispensasjonTyper;
using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.felles.PosisjonTyper;
using KS.Fiks.Plan.Models.V2.innsyn.DispensasjonerFinnResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.DispensasjonerFinnTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class FinnDispensasjonerTests : ModelTestsBase
{
    public FinnDispensasjonerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Dispensasjoner()
    {
        var finnDispensasjonerResultat = new FinnDispensasjoner()
        {
            Soekekriterier = new List<soekekriterier>()
            {
                new soekekriterier()
                {
                    Felt = soekekriterierFelt.Identifikasjon,
                    Operator = soekekriterierOperator.Equal,
                    Parameterverdier = "1"
                }
            }
        };
        
        var jsonString = JsonConvert.SerializeObject(finnDispensasjonerResultat,
            new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.FinnDispensasjoner);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
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
                    NasjonalArealplanId = new NasjonalArealplanId()
                    {
                        AdministrativEnhet = new AdministrativEnhet()
                        {
                            Type = AdministrativEnhetType.Kommunenummer,
                            Nummer = "1"
                        },
                        Planidentifikasjon = "1"
                    },
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
                            3.3
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
            new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.ResultatFinnDispensasjoner);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
}