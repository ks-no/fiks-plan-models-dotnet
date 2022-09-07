using System;
using System.IO;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;



Generator.Generate(args[0], args[1]);

static class Generator
{
    const string commonNamespace = "KS.Fiks.Plan.Models.V2";
    const string feilmeldingNamespace = "feilmelding";
    const string oppdateringNamespace = "oppdatering";
    const string innsynNamespace = "innsyn";
    const string fellesNamespace = "felles";
    
    public static void Generate(string sourcePath, string outputFolder)
    {
        // Denne genererer klasser, men har tilsynelatende noen problemer med å bli helt korrekt i resultatet for alle schema. Det kan være noe med schemafilene.
        // Filene genereres i bin/Debug/netcoreapp3.1/Models mappen

        //const string outputFolder = "Models";
        //Directory.CreateDirectory(outputFolder);

        var schemaFolder = new DirectoryInfo(sourcePath);
        var schemasToGenerate = schemaFolder
            .GetFiles()
            .Where(file => file.Extension.Equals(".json"))
            .Select(file => Path.Combine(sourcePath, file.Name));

        //var schemaFilenames = Directory.GetFiles(@"./Schema");
        
        foreach (var schemaFilename in schemasToGenerate)
        {
            if(!schemaFilename.Contains("no.ks.fiks.plan.v2.oppdatering.planbehandling.registrer.schema"))
                continue;
            
            Console.WriteLine($"Genererer kode basert på json schema {schemaFilename}");
            var schemaFile =
                JsonSchema.FromFileAsync(schemaFilename).Result;

            var namespacePrefix = "";
            var classFilename = "";
            if (schemaFilename.Contains($".{feilmeldingNamespace}."))
            {
                namespacePrefix = feilmeldingNamespace;
                classFilename = GetClassName(schemaFilename, feilmeldingNamespace);
            } else if (schemaFilename.Contains($".{oppdateringNamespace}."))
            {
                namespacePrefix = oppdateringNamespace;
                classFilename = GetClassName(schemaFilename, oppdateringNamespace);
            } else if (schemaFilename.Contains($".{innsynNamespace}."))
            {
                namespacePrefix = innsynNamespace;
                classFilename = GetClassName(schemaFilename, innsynNamespace);
            } else if (schemaFilename.Contains($".{fellesNamespace}."))
            {
                namespacePrefix = fellesNamespace;
                classFilename = GetClassName(schemaFilename, fellesNamespace);
            }
            else
            {
                throw new NotSupportedException($"Json schema filen {schemaFilename} tilhører ikke noe tidligere kjent namespace. Sjekk om det bør opprettes et nytt eller om denne skal tilhøre en av de eksiterende namespace.");
            }
            
            var generator = new CSharpGenerator(schemaFile)
            {
                Settings =
                {
                    Namespace = $"{commonNamespace}.{namespacePrefix}.{classFilename}",
                    ClassStyle = CSharpClassStyle.Poco,
                    TypeNameGenerator = new MyTypeNameGenerator(),
                }
            };


            var classAsString = generator.GenerateFile();
            var types = generator.GenerateTypes();

            foreach (var codeArtifact in types)
            {
                Console.Out.WriteLine("tjobing");
                Console.Out.WriteLine(codeArtifact.Code);
            }

            //TODO Skrive ut codeartifact til egen fil og droppe de som vi har som felles
            


            //Console.Out.WriteLine($"file: {classAsString}");
            //Directory.CreateDirectory($"./{outputFolder}/Models/{namespacePrefix}/");
            //TODO Hente filnavn fra title i hvert schema i stedet?
            //File.WriteAllText($"./{outputFolder}/Models/{namespacePrefix}/{ToUpper(classFilename)}.cs", classAsString);
        }
    }

    public class MyTypeNameGenerator : ITypeNameGenerator
    {
        public string Generate(JsonSchema schema, string typeNameHint, IEnumerable<string> reservedTypeNames)
        {
            throw new NotImplementedException();
        }
    }

    static string GetClassName(string schemaFilename, string namespaceName)
    {
        return string.Join("",
            schemaFilename.Split($".{namespaceName}.")[1].Replace(".schema.json", "").Split('.')
                .Select(ToUpper));
    }

    static string ToUpper(string input)
    {
        return char.ToUpper(input[0]) + input[1..];
    }
}