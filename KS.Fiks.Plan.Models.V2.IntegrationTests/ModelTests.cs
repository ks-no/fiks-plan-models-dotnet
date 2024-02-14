#nullable enable
using System.Reflection;
using KS.Fiks.Plan.Models.V2.felles.ArealplanTyper;
using KS.Fiks.Plan.Models.V2.felles.DispensasjonTyper;
using KS.Fiks.Plan.Models.V2.felles.DokumentTyper;
using KS.Fiks.Plan.Models.V2.felles.FlateTyper;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.felles.PlanbehandlingTyper;
using KS.Fiks.Plan.Models.V2.felles.PosisjonTyper;
using KS.Fiks.Plan.Models.V2.felles.SaksnummerTyper;
using KS.Fiks.Plan.Models.V2.innsyn.ArealplanHentResultatTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using KS.Fiks.Plan.Models.V2.oppdatering.ArealplanOpprettTyper;
using KS.Fiks.Plan.Models.V2.oppdatering.DispensasjonRegistrerTyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests
{
    public class ModelTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private const string AssemblyManifestResourcePrefix = "KS.Fiks.Plan.Models.V2.Schema.V2.";
        private const string SchemaFileSuffix = ".schema.json";
        private const string FellesDispensasjonSchema = "no.ks.fiks.plan.v2.felles.dispensasjon";
        private const string FellesSaksnummerSchema = "no.ks.fiks.plan.v2.felles.saksnummer";
        private const string FellesDokumentSchema = "no.ks.fiks.plan.v2.felles.dokument";
        private const string FellesNasjonalarealplanidSchema = "no.ks.fiks.plan.v2.felles.nasjonalarealplanid";
        private const string FellesPosisjonSchema = "no.ks.fiks.plan.v2.felles.posisjon";
        private const string FellesArealplanSchema = "no.ks.fiks.plan.v2.felles.arealplan";
        private const string FellesPlanbehandlingSchema = "no.ks.fiks.plan.v2.felles.planbehandling";
        
        public ModelTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        public void Opprett_Og_Valider_Registrer_Dispensasjon()
        {
            // Needed this for the assembly to be loaded
            var registrerDispensasjon = new RegistrerDispensasjon();
            registrerDispensasjon.Dispensasjon = new Dispensasjon()
            {
                Identifikasjon = "1",
                DispensasjonType = new DispensasjonType()
                {
                    Kodebeskrivelse = "Forbud",
                    Kodeverdi = "111"
                },
                DispensasjonFra = new DispensasjonFra()
                {
                    Kodeverdi = "PLAN",
                    Kodebeskrivelse = "Arealplaner"
                },
                NasjonalArealplanId = new NasjonalArealplanId()
                {
                    AdministrativEnhet = new AdministrativEnhet()
                    {
                        Type = AdministrativEnhetType.Kommunenummer,
                        Nummer = "1"
                    },
                    Planidentifikasjon = "Plan-Id"
                },
                Begrunnelse = "Dispensation description",
                Vedtaksdato = new DateTimeOffset(new DateTime(2021, 10, 1)),
                InnvilgetDispensasjon = true,
                Saksnummer = new Saksnummer()
                {
                    Saksaar = 2021,
                    Sakssekvensnummer = 14
                },
                VarigDispensasjon = true,
                VarighetFra = new DateTimeOffset(new DateTime(2021, 10, 1)),
                VarighetTil = new DateTimeOffset(new DateTime(2029, 10, 1)),
                Vertikalnivaa = new Vertikalnivaa()
                {
                    Kodebeskrivelse = "Beskrivelse",
                    Kodeverdi = "Test"
                },
                Beskrivelse = "Test",
                Posisjon = new Posisjon()
                {
                    Koordinatsystem = new Koordinatsystem()
                    {
                        Kodebeskrivelse = "",
                        Kodeverdi = ""
                    },
                    Koordinater = {1.1, 2.2},
                    Type = PosisjonType.Point
                }
            };

            var jsonString = JsonConvert.SerializeObject(registrerDispensasjon, new Newtonsoft.Json.Converters.StringEnumConverter());
            var jObject = JObject.Parse(jsonString);
            
            // Get Schemafile
            var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.RegistrerDispensasjon);
            IList<string> validatonErrorMessages;
            var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
            foreach (var errorMessage in validatonErrorMessages)
            {
                _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
            }
            Assert.True(isValid);
        }

        [Fact]
        public void Opprett_Og_Valider_Opprett_Arealplan()
        {
            // Needed this for the assembly to be loaded
            var opprettArealplan = new OpprettArealplan()
            {
                Plannavn = "Test",
                Plantype = new Plantype()
                {
                    Kodebeskrivelse = "",
                    Kodeverdi = ""
                },
                Planstatus = new Planstatus()
                {
                    Kodebeskrivelse = "",
                    Kodeverdi = ""
                },
                Lovreferanse = new Lovreferanse()
                {
                    Kodeverdi = "",
                    Kodebeskrivelse = ""
                },
                Saksnummer = new Saksnummer()
                {
                    Saksaar = 2024,
                    Sakssekvensnummer = 1
                }
            };
            
            var jsonString = JsonConvert.SerializeObject(opprettArealplan, new Newtonsoft.Json.Converters.StringEnumConverter());
            var jObject = JObject.Parse(jsonString);
            
            // Get Schemafile
            var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.OpprettArealplan);
            IList<string> validatonErrorMessages;
            var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
            foreach (var errorMessage in validatonErrorMessages)
            {
                _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
            }
            Assert.True(isValid);
        }
        
        [Fact]
        public void Opprett_Og_Valider_Hent_Arealplan_Resultat()
        {
            // Needed this for the assembly to be loaded
            var hentArealplanResultat = new HentArealplanResultat()
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
                        Planidentifikasjon = "Test"
                    },
                    Plantype = new Plantype()
                    {
                        Kodebeskrivelse = "",
                        Kodeverdi = ""
                    },
                    Plannavn = "Test"
                }
            };
            
            var jsonString = JsonConvert.SerializeObject(hentArealplanResultat, new Newtonsoft.Json.Converters.StringEnumConverter());

            _testOutputHelper.WriteLine($"Json:\n{jsonString}");
            Assert.DoesNotContain("vedtaksdato", jsonString);

            var jObject = JObject.Parse(jsonString);
            
            // Get Schemafile
            var jSchema = GetSchemaFile(FiksPlanMeldingtypeV2.ResultatHentArealplan);
            IList<string> validatonErrorMessages;
            var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
            foreach (var errorMessage in validatonErrorMessages)
            {
                _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
            }
            Assert.True(isValid);
        }

        private JSchema GetSchemaFile(string schemaName)
        {
            var resolver = new JSchemaPreloadedResolver();

            ResolveFellesSchemas(resolver);

            var mainSchemaAsStream = GetSchemaAsStream(schemaName);
            
            var streamReader = new StreamReader(mainSchemaAsStream);
            var jsonTextReader = new JsonTextReader(streamReader);
            return JSchema.Load(jsonTextReader, resolver);
        }

        private void ResolveFellesSchemas(JSchemaPreloadedResolver resolver)
        {
            ResolveFellesSchema(resolver,FellesDokumentSchema);
            ResolveFellesSchema(resolver,FellesNasjonalarealplanidSchema);
            ResolveFellesSchema(resolver,FellesSaksnummerSchema);
            ResolveFellesSchema(resolver,FellesPosisjonSchema);
            ResolveFellesSchema(resolver,FellesDispensasjonSchema);
            ResolveFellesSchema(resolver,FellesArealplanSchema);
            ResolveFellesSchema(resolver,FellesPlanbehandlingSchema);
        }
        
        private void ResolveFellesSchema(JSchemaPreloadedResolver resolver, string schemaname)
        {
            var stream = GetSchemaAsStream(schemaname);
            var streamReader = new StreamReader(stream);
            var jsonText = streamReader.ReadToEnd();

            resolver.Add(new Uri($"{schemaname}{SchemaFileSuffix}", UriKind.RelativeOrAbsolute), jsonText);
        }

        private Stream GetSchemaAsStream(string schemaName)
        {
            var fiksPlanModelsAssembly = Assembly
                .GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Select(a => Assembly.Load(a.FullName)).SingleOrDefault(assembly => assembly.GetName().Name == "KS.Fiks.Plan.Models.V2");
            
            var schemaStream =
                fiksPlanModelsAssembly.GetManifestResourceStream(
                    $"{AssemblyManifestResourcePrefix}{schemaName}{SchemaFileSuffix}");

            if (schemaStream == null)
            {
                _testOutputHelper.WriteLine($"Could not find schemafile in assembly for {schemaName}");
            }

            Assert.NotNull(schemaStream);
            return schemaStream;
        }
    }
}