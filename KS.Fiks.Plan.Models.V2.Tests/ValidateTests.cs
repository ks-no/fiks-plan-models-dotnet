using System;
using System.Collections.Generic;
using System.IO;
using KS.Fiks.Plan.Models.V2.felles;
using KS.Fiks.Plan.Models.V2.innsyn.AktoererHent;
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
    public void Validate_HentAktoererSchema_Med_Valid_Json()
    {
        var jsonPath = $"payloadValid.json";
            
        var validationSchema = GetJSchema("./../../../../Schema/V2/no.ks.fiks.plan.v2.innsyn.aktoerer.hent.schema.json");
        var json = GetJson(jsonPath);

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
    public void Validate_HentAktoererSchema_Med_NotValid_Json()
    {
        var validationFailed = false;
        var jsonPath = $"payloadNotValid.json";
            
        var validationSchema = GetJSchema("./../../../../Schema/V2/no.ks.fiks.plan.v2.innsyn.aktoerer.hent.schema.json");
        var json = GetJson(jsonPath);

        try
        {
            json.Validate(validationSchema);
        }
        catch (Exception e)
        {
            validationFailed = true;
            Console.Out.WriteLine($"{jsonPath} feilet som forventet.");
            Console.Out.WriteLine($"{jsonPath} - Exception message: {e.Message}");
        }
        Assert.IsTrue(validationFailed);
    }
    
    [Test]
    public void Validate_NasjonalArealplanId()
    {
        var jsonFileReader = File.OpenText("./../../../../Schema/V2/no.ks.fiks.plan.v2.felles.nasjonalarealplanid.schema.json");
        var jsonTextReader = new JsonTextReader(jsonFileReader);
        var validationSchema = JSchema.Load(jsonTextReader);
        AddAdditionalPropertiesFalseToSchemaProperties(validationSchema.Properties);

    }
    
    [Test]
    public void HentAktoerer_NasjonalArealplanId_OneOf_Is_Ok_Test()
    {
        var hentAktoerer = new HentAktoerer()
        {
            Saksnummer = new Saksnummer()
            {
                Saksaar = 2021,
                Sakssekvensnummer = 1
            },
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Landskode = "123"
                },
                Planidentifikasjon = "tjobing"
            }
        };

        var json = JsonConvert.SerializeObject(hentAktoerer);
        
        JObject person = JObject.Parse(json);
        
    
        Console.Out.WriteLineAsync($"Json serialized: {json}");

        var hentAktoererDeserialized = JsonConvert.DeserializeObject<HentAktoerer>(json);

        Assert.AreEqual(hentAktoerer.Saksnummer.Saksaar, hentAktoererDeserialized.Saksnummer.Saksaar);
        Assert.AreEqual(hentAktoerer.Saksnummer.Sakssekvensnummer, hentAktoererDeserialized.Saksnummer.Sakssekvensnummer);
        Assert.AreEqual(hentAktoerer.NasjonalArealplanId.AdministrativEnhet.Landskode, hentAktoererDeserialized.NasjonalArealplanId.AdministrativEnhet.Landskode);
        Assert.AreEqual(hentAktoerer.NasjonalArealplanId.Planidentifikasjon, hentAktoererDeserialized.NasjonalArealplanId.Planidentifikasjon);
        Assert.IsNull(hentAktoererDeserialized.NasjonalArealplanId.AdministrativEnhet.Kommunenummer);
        Assert.IsNull(hentAktoererDeserialized.NasjonalArealplanId.AdministrativEnhet.Fylkesnummer);
    }
    
    [Test]
    public void HentAktoerer_NasjonalArealplanId_OneOf_Not_Valid_Test()
    {
        var hentAktoerer = new HentAktoerer()
        {
            Saksnummer = new Saksnummer()
            {
                Saksaar = 2021,
                Sakssekvensnummer = 1
            },
            NasjonalArealplanId = new NasjonalArealplanId()
            {
                AdministrativEnhet = new AdministrativEnhet()
                {
                    Landskode = "123",
                    Fylkesnummer = "2"
                },
                Planidentifikasjon = "tjobing"
            }
        };

        var json = JsonConvert.SerializeObject(hentAktoerer);
    
        Console.Out.WriteLineAsync($"Json serialized: {json}");

        var hentAktoererDeserialized = JsonConvert.DeserializeObject<HentAktoerer>(json);

        Assert.AreEqual(hentAktoerer.Saksnummer.Saksaar, hentAktoererDeserialized.Saksnummer.Saksaar);
        Assert.AreEqual(hentAktoerer.Saksnummer.Sakssekvensnummer, hentAktoererDeserialized.Saksnummer.Sakssekvensnummer);
        Assert.AreEqual(hentAktoerer.NasjonalArealplanId.AdministrativEnhet.Landskode, hentAktoererDeserialized.NasjonalArealplanId.AdministrativEnhet.Landskode);
        Assert.AreEqual(hentAktoerer.NasjonalArealplanId.Planidentifikasjon, hentAktoererDeserialized.NasjonalArealplanId.Planidentifikasjon);
        Assert.IsNull(hentAktoererDeserialized.NasjonalArealplanId.AdministrativEnhet.Kommunenummer);
        Assert.IsNull(hentAktoererDeserialized.NasjonalArealplanId.AdministrativEnhet.Fylkesnummer);
    }
    
    private static JSchema GetJSchema(string schemaPath)
    {
        var resolver = new JSchemaPreloadedResolver();
        var fileReader = File.OpenText("./../../../../Schema/V2/no.ks.fiks.plan.v2.felles.nasjonalarealplanid.schema.json");
        resolver.Add(new Uri("no.ks.fiks.plan.v2.felles.nasjonalarealplanid.schema.json", UriKind.RelativeOrAbsolute), fileReader.ReadToEnd());
        var jsonFileReader = File.OpenText(schemaPath);
        var jsonTextReader = new JsonTextReader(jsonFileReader);
        //var validationSchema = JSchema.Load(new JsonTextReader(validationSchemaReader), resolver);

      /*  var jSchemaReaderSettings = new JSchemaReaderSettings()
        {
            Resolver = resolver,
            BaseUri = new Uri(schemaPath)
        };*/
        var validationSchema = JSchema.Load(jsonTextReader, resolver);
        AddAdditionalPropertiesFalseToSchemaProperties(validationSchema.Properties);
    
    
        return validationSchema;
    }

    private static JObject GetJson(string jsonPath)
    {
        var jsonReader = File.OpenText(jsonPath);
        return JObject.Load(new JsonTextReader(jsonReader));
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