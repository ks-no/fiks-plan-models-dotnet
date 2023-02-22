using System;
using System.IO;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

Generator.Generate(args[0], args[1]);

static class Generator
{
    private const string commonNamespace = "KS.Fiks.Plan.Models.V2";
    private const string feilmeldingSubNamespace = "feilmelding";
    private const string oppdateringSubNamespace = "oppdatering";
    private const string innsynSubNamespace = "innsyn";
    private const string fellesSubNamespace = "felles";
    private const string fellesNamespace = $"{commonNamespace}.{fellesSubNamespace}";
    
    private static readonly string[] fellesTyper = { "NasjonalArealplanId", "AdministrativEnhet", "AdministrativEnhetType" };
    private static readonly string fellesGeneratedSubNamespace = "Nasjonalarealplanid";

    public static void Generate(string sourcePath, string outputFolder)
    {
        var schemaFolder = new DirectoryInfo(sourcePath);
        var schemasToGenerate = schemaFolder
            .GetFiles()
            .Where(file => file.Extension.Equals(".json"))
            .Select(file => Path.Combine(sourcePath, file.Name));

        
        foreach (var schemaFilename in schemasToGenerate)
        {
            Console.WriteLine($"Genererer kode basert på json schema {schemaFilename}");
            
            var schemaFile =
                JsonSchema.FromFileAsync(schemaFilename).Result;

            var namespacePrefix = "";
            var classFilename = "";
            if (schemaFilename.Contains($".{feilmeldingSubNamespace}."))
            {
                namespacePrefix = feilmeldingSubNamespace;
                classFilename = GetClassName(schemaFilename, feilmeldingSubNamespace);
            } else if (schemaFilename.Contains($".{oppdateringSubNamespace}."))
            {
                namespacePrefix = oppdateringSubNamespace;
                classFilename = GetClassName(schemaFilename, oppdateringSubNamespace);
            } else if (schemaFilename.Contains($".{innsynSubNamespace}."))
            {
                namespacePrefix = innsynSubNamespace;
                classFilename = GetClassName(schemaFilename, innsynSubNamespace);
            } else if (schemaFilename.Contains($".{fellesSubNamespace}."))
            {
                namespacePrefix = fellesSubNamespace;
                classFilename = GetClassName(schemaFilename, fellesSubNamespace);
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

            Directory.CreateDirectory($"./{outputFolder}/Models/{namespacePrefix}/{classFilename}/");

            // Need to do this in order to get the types. Do not remove!
            var classAsString = generator.GenerateFile(); 
            
            var types = generator.GenerateTypes();

            var usingCode = "";
            foreach (var codeArtifact in types)
            {
                Console.Out.WriteLine($"Typename: {codeArtifact.TypeName}");
                
                // Legg på using hvis det er en fellestype
                if (!schemaFilename.Contains(".felles.") && fellesTyper.Contains(codeArtifact.TypeName))
                {
                    usingCode += $"using {fellesNamespace}.{fellesGeneratedSubNamespace};\n\n";    
                }
            }

            foreach (var codeArtifact in types)
            {
                var code = "";

                // Skip fellestyper og bruk using i stedet
                if (!schemaFilename.Contains(".felles.") && fellesTyper.Contains(codeArtifact.TypeName))
                {
                    Console.Out.WriteLine($"Skipping {codeArtifact.TypeName}");
                    continue;
                }

                code = $"{usingCode}" +
                           $"namespace KS.Fiks.Plan.Models.V2.{namespacePrefix}.{classFilename} {{\n" +
                           "#pragma warning disable // Disable all warnings\n\n" +
                           $"{codeArtifact.Code.Replace(" partial ", " ")}\n" +
                           "}";
                
                File.WriteAllText($"./{outputFolder}/Models/{namespacePrefix}/{classFilename}/{ToUpper(codeArtifact.TypeName)}.cs", code);
            }
        }
    }

    public class MyTypeNameGenerator : ITypeNameGenerator
    {
        public string Generate(JsonSchema schema, string typeNameHint, IEnumerable<string> reservedTypeNames)
        {
            //TODO fikse denne slik at namegenerator funker med ref skjema. Nå ble det feil mtp at den kaller feltet for Nasjonalarealplanid
            // Console.Out.WriteLine($"typeNameHint {typeNameHint}");
            // Console.Out.WriteLine($"title {schema.Title}");

            return !string.IsNullOrEmpty(schema.Title) ? schema.Title : typeNameHint;
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