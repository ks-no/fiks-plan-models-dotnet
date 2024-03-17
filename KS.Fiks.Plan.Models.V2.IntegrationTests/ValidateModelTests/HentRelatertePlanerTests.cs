using KS.Fiks.Plan.Models.V2.felles.ArealplanTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanHentResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.RelaterteplanerHentResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.RelaterteplanerHentTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class HentRelatertePlanerTests : ModelTestsBase
{
    public HentRelatertePlanerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Relaterte_Planer()
    {
        var hentRelatertePlaner = new HentRelatertePlaner()
        {
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Type = AdministrativEnhetType.Kommunenummer,
                    Nummer = "1"
                },
                Planidentifikasjon = "Test"
            },
        };

        var jsonString = JsonConvert.SerializeObject(hentRelatertePlaner, new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");
        Assert.DoesNotContain("vedtaksdato", jsonString);

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.HentRelatertePlaner);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }

    [Fact]
    public void Opprett_Og_Valider_Hent_Relaterte_Planer_Resultat()
    {
        var hentArealplanResultat = new HentRelatertePlanerResultat()
        {
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Type = AdministrativEnhetType.Kommunenummer,
                    Nummer = "1"
                },
                Planidentifikasjon = "Test"
            },
            Planrelasjoner = new List<planrelasjoner>()
            {
                new planrelasjoner()
                {
                    Arealplan = new Arealplan()
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
                    },
                    Planforhold = new Planforhold()
                    {
                        Kodeverdi = "",
                        Kodebeskrivelse = ""
                    }
                }
            }
        };

        var jsonString = JsonConvert.SerializeObject(hentArealplanResultat, new StringEnumConverter());

        _testOutputHelper.WriteLine($"Json:\n{jsonString}");
        Assert.DoesNotContain("vedtaksdato", jsonString);

        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.ResultatHentRelatertePlaner);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
    }
}