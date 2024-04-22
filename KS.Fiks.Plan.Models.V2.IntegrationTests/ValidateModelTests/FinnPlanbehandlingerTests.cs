using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.felles.PlanbehandlingTyper;
using KS.Fiks.Plan.Models.V2.felles.PosisjonTyper;
using KS.Fiks.Plan.Models.V2.felles.SaksnummerTyper;
using KS.Fiks.Plan.Models.V2.innsyn.PlanbehandlingerFinnResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.PlanbehandlingerFinnTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class FinnPlanbehandlingerTests : ModelTestsBase
{
    public FinnPlanbehandlingerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Planbehandlinger()
    {
        var finnPlanbehandlinger = new FinnPlanbehandlinger()
        {
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Type = AdministrativEnhetType.Kommunenummer,
                    Nummer = "0821"
                },
                Planidentifikasjon = "01_27_1988"
            },
            InkluderPlandokumenter = true
        };
        
        var jsonString = ValidateWithSchema(finnPlanbehandlinger, FiksPlanMeldingtypeV2.FinnPlanbehandlinger);
        WriteJsonSampleFile("Requests/FinnPlanbehandlinger", jsonString);
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Planbehandlinger_Resultat()
    {
        var finnPlanbehandlingerResultat = new FinnPlanbehandlingerResultat()
        {
            Planbehandlinger = new List<Planbehandling>() { 
                new Planbehandling()
                {
                    Navn = "",
                    Posisjon = new Posisjon()
                    {
                        Type = PosisjonType.Point,
                        Koordinatsystem = new Koordinatsystem() // Kode
                        {
                            Kodeverdi = "EPSG:3857",
                            Kodebeskrivelse = ""
                        },
                        Koordinater = new List<double>(2)
                        {
                            1.02345,
                            2.33333
                        }
                    },
                    Planbehandlingtype = new Planbehandlingtype() // Kode
                    {
                        Kodeverdi = "1",
                        Kodebeskrivelse = "planstatus"
                    },
                    Dato = new DateTimeOffset(new DateTime(2020, 06, 13)),
                    Saksnummer = new Saksnummer()
                    {
                        Saksaar = 2019,
                        Sakssekvensnummer = 123124
                    }
                }
            }
        };
            
        var jsonString = ValidateWithSchema(finnPlanbehandlingerResultat, FiksPlanMeldingtypeV2.ResultatFinnPlanbehandlinger);
        WriteJsonSampleFile("Responses/FinnPlanbehandlinger", jsonString);
    }
}