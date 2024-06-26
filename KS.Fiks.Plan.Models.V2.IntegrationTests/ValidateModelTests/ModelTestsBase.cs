using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;
using Xunit.Abstractions;

namespace KS.Fiks.Plan.Models.V2.IntegrationTests.ValidateModelTests;

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
    private const string FellesFlateSchema = "no.ks.fiks.plan.v2.felles.flate";
    private const string FellesMidlertidigforbudSchema = "no.ks.fiks.plan.v2.felles.midlertidigforbud";


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
        ResolveFellesSchema(resolver, FellesFlateSchema);
        ResolveFellesSchema(resolver, FellesMidlertidigforbudSchema);
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

    protected string ValidateWithSchema(object jsonObject, string schemaName)
    {
        var jsonString =
            JsonConvert.SerializeObject(jsonObject, new StringEnumConverter());
        var jObject = JObject.Parse(jsonString);

        // Get Schemafile
        var jSchema = GetSchemaFile(schemaName);
        IList<string> validatonErrorMessages;
        var isValid = jObject.IsValid(jSchema, out validatonErrorMessages);
        foreach (var errorMessage in validatonErrorMessages)
        {
            _testOutputHelper.WriteLine($"Errormessage from IsValid: {errorMessage}");
        }

        Assert.True(isValid);
        return jsonString;
    }

    protected void WriteJsonSampleFile(string? sampleName, string jsonString)
    {
        File.WriteAllText($"./../../../../KS.Fiks.Plan.Models.V2/Samples/{sampleName}/payload.json", jsonString);
    }
}