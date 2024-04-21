using KS.Fiks.Plan.Models.V2.felles.DokumentTyper;
using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.felles.PlanbehandlingTyper;
using KS.Fiks.Plan.Models.V2.felles.PosisjonTyper;
using KS.Fiks.Plan.Models.V2.felles.SaksnummerTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using KS.Fiks.Plan.Models.V2.oppdatering.PlanbehandlingRegistrerTyper;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

public class RegistrerPlanbehandlingTests : ModelTestsBase
{
    public RegistrerPlanbehandlingTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Opprett_Og_Valider_Registrer_Planbehandling()
    {
        var registrerPlanbehandling = new RegistrerPlanbehandling()
        {
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Type = AdministrativEnhetType.Kommunenummer,
                    Nummer = "1"
                },
                Planidentifikasjon = "Plan-Id"
            },
            Planbehandling = new Planbehandling()
            {
                Navn = "",
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
                        2.2
                    }
                },
                Planbehandlingtype = new Planbehandlingtype() // Kode
                {
                    Kodeverdi = "",
                    Kodebeskrivelse = ""
                }
            }
        };

        ValidateWithSchema(registrerPlanbehandling, FiksPlanMeldingtypeV2.RegistrerPlanbehandling);
    }

    [Fact]
    public void Besluttet_Offentlig_Ettersyn_Registrer_Planbehandling()
    {
        var registrerPlanbehandling2 = new RegistrerPlanbehandling()
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
            Planbehandling = new Planbehandling()
            {
                Navn = "Navn på registrering",
                Saksnummer = new Saksnummer()
                {
                    Saksaar = 2020,
                    Sakssekvensnummer = 1234
                },
                Planbehandlingtype = new Planbehandlingtype()
                {
                    Kodeverdi = "11",
                    Kodebeskrivelse = "Besluttet offentlig ettersyn"
                }
            }
        };

        registrerPlanbehandling2.Planbehandling.Plandokumenter = new List<Dokument>();
        registrerPlanbehandling2.Planbehandling.Plandokumenter.Add(
            new Dokument()
            {
                Tittel = "Vedtak",
                ReferanseDokumentfil = new ReferanseDokumentfil()
                {
                    Id = "vedtak.pdf", // Dette er for dokumenter som er på vei inn, og vil være navnet på filen slik den heter i ASIC pakken som payload
                    Url = "https://en-url-til-der-filen-ligger/vedtak.pdf" // Dette er for dokumenter som blir hentet fra planregister
                },
                Dokumenttype = new Dokumenttype()
                {
                    Kodeverdi = "VEDTAK",
                    Kodebeskrivelse = "Vedtak"
                }
            }
        );

        var jsonString = ValidateWithSchema(registrerPlanbehandling2, FiksPlanMeldingtypeV2.RegistrerPlanbehandling);
        WriteJsonSampleFile("BesluttetOffentligEttersyn", jsonString);
    }
}