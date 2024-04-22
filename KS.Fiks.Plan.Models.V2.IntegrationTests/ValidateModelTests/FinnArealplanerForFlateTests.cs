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
                    Kodeverdi = "EPSG:3857",
                    Kodebeskrivelse = ""
                },
                Koordinater = new List<ICollection<double>>(4)
                {
                    new List<double>() {-68282685.41516227, -6465204.835748881},
                    new List<double>() {-89087359.34248951, -60693710.296802774},
                    new List<double>() {54140328.89114547, -74610475.49858013},
                    new List<double>() {-30574113.323342994, 11972045.14759487},
                }
            }
        };
        
        var jsonString = ValidateWithSchema(finnArealplaner, FiksPlanMeldingtypeV2.FinnArealplanerForFlate);
        WriteJsonSampleFile("Requests/FinnArealplanerForFlate", jsonString);
    }
}