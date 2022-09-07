using System;
using System.Collections.Generic;
using System.IO;
using KS.Fiks.Plan.Models.V2.felles.Administrativenhet;
using KS.Fiks.Plan.Models.V2.felles.AdministrativEnhet;
using KS.Fiks.Plan.Models.V2.oppdatering.PlanbehandlingRegistrer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }
    
    [Test]
    public void Test1()
    {
        var jsonPath = $"payload.json";
            
        var validationSchema = ValidationSchema(jsonPath, out var json);

        try
        {
            json.Validate(validationSchema);
        }
        catch (Exception e)
        {
            Console.Out.WriteLine($"{jsonPath} feilet!!");
            Console.Out.WriteLine($"{jsonPath} - Exception message: {e.Message}");
            Assert.Fail($"Validering for {jsonPath} feilet");
        }
        Assert.Pass();
    }
    
    [Test]
    public void Test2()
    {
        
        
        var planbehandling = new RegistrerPlanbehandling()
        {
            Planbehandling = new Planbehandling()
            {
                Navn = "navn",
                Dato = new DateTimeOffset(),
                Posisjon = new Posisjon()
                {
                    Coordinates = new List<double>() {1.0, 1.0},
                    
                }
                
            },
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new LandskodeImpl()
                {
                    landskode = "123"
                },
                Planidentifikasjon = "tjobing"
            }
        };

        Console.Out.WriteLineAsync(JsonConvert.SerializeObject(planbehandling));
        
    }
    
    private static JSchema ValidationSchema(string jsonPath, out JObject json)
    {
        var resolver = new JSchemaPreloadedResolver();

        var validationSchemaReader = File.OpenText($"no.ks.fiks.plan.v2.oppdatering.planbehandling.registrer.schema.json");
        var validationSchema = JSchema.Load(new JsonTextReader(validationSchemaReader), resolver);
            
        AddAdditionalPropertiesFalseToSchemaProperties(validationSchema.Properties);

        var jsonReader = File.OpenText(jsonPath);
        json = JObject.Load(new JsonTextReader(jsonReader));
        return validationSchema;
    }
        
    private static void AddAdditionalPropertiesFalseToSchemaProperties(IDictionary<string, JSchema> properties)
    {
        foreach (var item in properties)
        {
            item.Value.AllowAdditionalProperties = false;
            foreach (var itemItem in item.Value.Items)
            {
                AddAdditionalPropertiesFalseToSchemaProperties(itemItem.Properties);

            }
            AddAdditionalPropertiesFalseToSchemaProperties(item.Value.Properties);
        }
    }

    private static bool SchemaExists(string meldingstype)
    {
        return File.Exists(Path.Combine("Schema", $"{meldingstype}.schema.json"));
    }
}