using KS.Fiks.Plan.Models.V2.felles.ArealplanTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanerFinnResultatTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanerFinnTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class FinnArealplanerTests : ModelTestsBase
{
    public FinnArealplanerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Finn_Arealplaner()
    {
        var finnArealplaner = new FinnArealplaner()
        {
            Soekekriterier = new List<soekekriterier>()
            {
                new soekekriterier()
                {
                    Felt = soekekriterierFelt.NasjonalArealplanId_planidentifikasjon,
                    Operator = soekekriterierOperator.Equal,
                    Parameterverdier = "09062018-2"
                }
            }
        };
        
        var jsonString = ValidateWithSchema(finnArealplaner, FiksPlanMeldingtypeV2.FinnArealplaner);
        WriteJsonSampleFile("Requests/FinnArealplaner", jsonString);
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
                            Nummer = "0821",
                        },
                        Planidentifikasjon = "09062018-2",
                    },
                    Plannavn = "plannavn",
                    Planstatus = new Planstatus()
                    {
                        Kodeverdi = "1",
                        Kodebeskrivelse = "Planstatus"
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
        
        var jsonString = ValidateWithSchema(finnArealplanerResultat, FiksPlanMeldingtypeV2.ResultatFinnArealplaner);
        WriteJsonSampleFile("Responses/FinnArealplaner", jsonString);
    }
}