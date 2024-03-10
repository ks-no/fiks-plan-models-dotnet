using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ModelTests;

public class ModelTestsBase
{
    protected ITestOutputHelper _testOutputHelper;
    private const string AssemblyManifestResourcePrefix = "KS.Fiks.Plan.Models.V2.Schema.V2.";
    private const string SchemaFileSuffix = ".schema.json";
    private const string FellesDispensasjonSchema = "no.ks.fiks.plan.v2.felles.dispensasjon";
    private const string FellesSaksnummerSchema = "no.ks.fiks.plan.v2.felles.saksnummer";
    private const string FellesDokumentSchema = "no.ks.fiks.plan.v2.felles.dokument";
    private const string FellesNasjonalarealplanidSchema = "no.ks.fiks.plan.v2.felles.nasjonalarealplanid";
    private const string FellesPosisjonSchema = "no.ks.fiks.plan.v2.felles.posisjon";
    private const string FellesArealplanSchema = "no.ks.fiks.plan.v2.felles.arealplan";
    private const string FellesPlanbehandlingSchema = "no.ks.fiks.plan.v2.felles.planbehandling";


    protected JSchema GetSchemaFile(string schemaName)
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
        ResolveFellesSchema(resolver, FellesDokumentSchema);
        ResolveFellesSchema(resolver, FellesNasjonalarealplanidSchema);
        ResolveFellesSchema(resolver, FellesSaksnummerSchema);
        ResolveFellesSchema(resolver, FellesPosisjonSchema);
        ResolveFellesSchema(resolver, FellesDispensasjonSchema);
        ResolveFellesSchema(resolver, FellesArealplanSchema);
        ResolveFellesSchema(resolver, FellesPlanbehandlingSchema);
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
            .Select(a => Assembly.Load(a.FullName))
            .SingleOrDefault(assembly => assembly.GetName().Name == "KS.Fiks.Plan.Models.V2");

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