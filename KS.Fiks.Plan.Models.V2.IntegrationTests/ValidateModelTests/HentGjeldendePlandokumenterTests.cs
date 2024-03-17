using KS.Fiks.Plan.Models.V2.felles.DokumentTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.innsyn.GjeldendeplandokumenterHentResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.GjeldendeplandokumenterHentTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class HentGjeldendePlandokumenterTests : ModelTestsBase
{
    public HentGjeldendePlandokumenterTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Gjeldende_Plandokumenter()
    {
        var hentGjeldendePlandokumenter = new HentGjeldendePlandokumenter()
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
            JsonConvert.SerializeObject(hentGjeldendePlandokumenter, new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.HentGjeldendePlandokumenter);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Gjeldende_Plandokumenter_Resultat()
    {
        var hentGjeldendePlandokumenterResultat = new HentGjeldendePlandokumenterResultat()
        {
            Plandokumenter = new List<Dokument>()
            {
                new Dokument()
                {
                    Arkivnavn = "Et arkivnavn",
                    Dokumenttype = new Dokumenttype()
                    {
                        Kodeverdi = "KART",
                        Kodebeskrivelse = "Kart"
                    },
                    Dokumentsdato = new DateTimeOffset(DateTime.Now),
                    Mimetype = "",
                    Tittel = "En tittel",
                    ReferanseDokumentfil = new ReferanseDokumentfil()
                    {
                        Id = "En id",
                        Url = "En url"
                    }
                },
                new Dokument()
                {
                    Arkivnavn = "Et arkivnavn",
                    Dokumenttype = new Dokumenttype()
                    {
                        Kodeverdi = "PLANBESKR",
                        Kodebeskrivelse = "Planbeskrivelse"
                    },
                    Dokumentsdato = new DateTimeOffset(DateTime.Now),
                    Mimetype = "",
                    Tittel = "En tittel",
                    ReferanseDokumentfil = new ReferanseDokumentfil()
                    {
                        Id = "En id",
                        Url = "En url"
                    }
                }
            }
        };

        var jsonString =
            JsonConvert.SerializeObject(hentGjeldendePlandokumenterResultat, new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.ResultatHentGjeldendePlandokumenter);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
}