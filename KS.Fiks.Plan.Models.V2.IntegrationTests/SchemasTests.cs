#nullable enable
using System.Reflection;
using KS.Fiks.Plan.Models.V2.felles.DispensasjonTyper;
using KS.Fiks.Plan.Models.V2.Meldingstyper;
using KS.Fiks.Plan.Models.V2.oppdatering.DispensasjonRegistrerTyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests
{
    public class TestCasesTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private const string AssemblyManifestResourcePrefix = "KS.Fiks.Plan.Models.V2.Schema.V2.";
        private const string AssemblyManifestResourceSuffix = ".schema.json";
        public TestCasesTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        public void FiksPlan_Schemas_Are_Included_In_Assembly()
        {
            // Needed this for the assembly to be loaded
            var testFoo = new RegistrerDispensasjon();
            testFoo.Dispensasjon = new Dispensasjon();
            
            var referencedAssemblies = Assembly
                .GetExecutingAssembly()
                .GetReferencedAssemblies();
            
            var fiksPlanModelsAssembly = Assembly
                .GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Select(a => Assembly.Load(a.FullName)).SingleOrDefault(assembly => assembly.GetName().Name == "KS.Fiks.Plan.Models.V2");

            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.RegistrerDispensasjon);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.RegistrerPlanavgrensning);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.RegistrerPlanbehandling);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.RegistrerPlanomraade);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatFinnArealplaner);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatFinnDispensasjoner);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatFinnPlanbehandlinger);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatHentAktoerer);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatHentArealplan);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatHentKodeliste);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatHentPlanomraader);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatHentGjeldendePlanbestemmelser);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatHentRelatertePlaner);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatSjekkMidlertidigForbud);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.ResultatHentBboxForPlan);
            TestSchemaFileIsIncludedInAssembly(fiksPlanModelsAssembly, FiksPlanMeldingtypeV2.MottatOppdaterDispensasjon);
          
        }

        private void TestSchemaFileIsIncludedInAssembly(Assembly fiksPlanModelsAssembly, string schemaName)
        {
            var schemaStream =
                fiksPlanModelsAssembly.GetManifestResourceStream(
                    $"{AssemblyManifestResourcePrefix}{schemaName}{AssemblyManifestResourceSuffix}");

            if (schemaStream == null)
            {
                _testOutputHelper.WriteLine($"Could not find schemafile in assembly for {schemaName}");
            }

            Assert.NotNull(schemaStream);
            
            var streamReader = new StreamReader(schemaStream);
            var jsonReader = new JsonTextReader(streamReader);
            var serializer = new JsonSerializer();
            var schema = serializer.Deserialize(jsonReader);
            Assert.NotNull(schema);
        }

        private static JObject GetJson(string jsonPath)
        {
            var jsonReader = File.OpenText(jsonPath);
            return JObject.Load(new JsonTextReader(jsonReader));
        }

    }
}