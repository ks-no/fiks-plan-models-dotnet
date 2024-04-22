using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.MidlertidigforbudTyper;
using KS.Fiks.Plan.Models.V2.felles.SaksnummerTyper;
using KS.Fiks.Plan.Models.V2.innsyn.MidlertidigeforbudmottiltakFinnResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.MidlertidigeforbudmottiltakFinnTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class FinnMidlertidigeForbudMotTiltakTests : ModelTestsBase
{
    public FinnMidlertidigeForbudMotTiltakTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Midlertidige_Forbud_Mot_Tiltak()
    {
        var finnMidlertidigeForbudMottiltak = new FinnMidlertidigeForbudMottiltak()
        {
            Flate = new Flate()
            {
                Type = FlateType.Polygon,
                Koordinatsystem = new Koordinatsystem()
                {
                    Kodeverdi = "EPSG:3857",
                    Kodebeskrivelse = ""
                },
                Koordinater = new List<ICollection<double>>(4)
                {
                    new List<double>() { 2.2, 3.3 },
                    new List<double>() { 2.2, 3.3 },
                    new List<double>() { 2.2, 3.3 },
                    new List<double>() { 2.2, 3.3 },
                }
            }
        };
        var jsonString = ValidateWithSchema(finnMidlertidigeForbudMottiltak, FiksPlanMeldingtypeV2.FinnMidlertidigForbudMotTiltak);
        WriteJsonSampleFile("Requests/FinnMidlertidigForbud", jsonString);
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Midlertidige_Forbud_Mot_Tiltak_Resultat()
    {
        var resultat = new FinnMidlertidigeForbudMotTiltakResultat()
        {
            MidlertidigeForbud = new List<MidlertidigForbud>()
            {
                new MidlertidigForbud()
                {
                    Saksnummer = new Saksnummer()
                    {
                        Saksaar = 2020,
                        Sakssekvensnummer = 1
                    },
                    Omraade = new Flate()
                    {
                        Type = FlateType.Polygon,
                        Koordinatsystem = new Koordinatsystem()
                        {
                            Kodeverdi = "EPSG:3857",
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
                    Avgjoerelsedato = new DateTimeOffset(new DateTime(2021, 1, 15)),
                    PblTiltakForbudtype = new PblTiltakForbudtype()
                    {
                        Kodeverdi = "",
                        Kodebeskrivelse = ""
                    },
                    GyldigTilDato = new DateTimeOffset(new DateTime(2030, 1, 1))
                }
            }
        };

        var jsonString = ValidateWithSchema(resultat, FiksPlanMeldingtypeV2.ResultatFinnMidlertidigForbud);
        WriteJsonSampleFile("Responses/FinnMidlertidigForbud", jsonString);
    }
}