using System;
using System.Collections.Generic;
using System.IO;
using KS.Fiks.Plan.Models.V2.felles.NasjonalarealplanidTyper;
using KS.Fiks.Plan.Models.V2.felles.SaksnummerTyper;
using KS.Fiks.Plan.Models.V2.innsyn.AktoererHentTyper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;

namespace KS.Fiks.Plan.Models.V2.Tests.Validation;

public class Tests
{

    [Fact] 
    public void Validate_HentAktoererSchema_Med_Valid_Json()
    {
        var isValid = false;
        var jsonPath = $"payloadValid.json";
            
        var validationSchema = GetJSchema("./../../../../Schema/V2/no.ks.fiks.plan.v2.innsyn.aktoerer.hent.schema.json");
        var json = GetJson(jsonPath);

        try
        {
            isValid = json.IsValid(validationSchema);
        }
        catch (Exception e)
        {
            Console.Out.WriteLine($"{jsonPath} feilet!!");
            Console.Out.WriteLine($"{jsonPath} - Exception message: {e.Message}");
        }
        Assert.True(isValid);
    }
    
    [Fact] 
    public void Validate_HentAktoererSchema_Med_NotValid_Json()
    {
        var isValid = false;
        var jsonPath = $"payloadNotValid.json";
            
        var validationSchema = GetJSchema("./../../../../Schema/V2/no.ks.fiks.plan.v2.innsyn.aktoerer.hent.schema.json");
        var json = GetJson(jsonPath);

        try
        {
            isValid = json.IsValid(validationSchema);
        }
        catch (Exception e)
        {
            isValid = false;
            Console.Out.WriteLine($"{jsonPath} feilet som forventet.");
            Console.Out.WriteLine($"{jsonPath} - Exception message: {e.Message}");
        }
        Assert.False(isValid);
    }
    
    [Fact]
    public void Validate_NasjonalArealplanId()
    {
        var jsonFileReader = File.OpenText("./../../../../Schema/V2/no.ks.fiks.plan.v2.felles.nasjonalarealplanid.schema.json");
        var jsonTextReader = new JsonTextReader(jsonFileReader);
        var validationSchema = JSchema.Load(jsonTextReader);
        AddAdditionalPropertiesFalseToSchemaProperties(validationSchema.Properties);

    }
    
    [Fact]
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
                AdministrativEnhet = new AdministrativEnhet
                {
                    Type = AdministrativEnhetType.Kommunenummer,
                    Nummer = "1234",
                },
                Planidentifikasjon = "tjobing"
            }
        };

        var json = JsonConvert.SerializeObject(hentAktoerer);
        
        JObject person = JObject.Parse(json);
        
    
        Console.Out.WriteLineAsync($"Json serialized: {json}");

        var hentAktoererDeserialized = JsonConvert.DeserializeObject<HentAktoerer>(json);

        Assert.Equal(hentAktoerer.Saksnummer.Saksaar, hentAktoererDeserialized.Saksnummer.Saksaar);
        Assert.Equal(hentAktoerer.Saksnummer.Sakssekvensnummer, hentAktoererDeserialized.Saksnummer.Sakssekvensnummer);
        Assert.Equal(hentAktoerer.NasjonalArealplanId.AdministrativEnhet.Nummer, hentAktoererDeserialized.NasjonalArealplanId.AdministrativEnhet.Nummer);
        Assert.Equal(hentAktoerer.NasjonalArealplanId.AdministrativEnhet.Type, hentAktoererDeserialized.NasjonalArealplanId.AdministrativEnhet.Type);
        Assert.Equal(hentAktoerer.NasjonalArealplanId.Planidentifikasjon, hentAktoererDeserialized.NasjonalArealplanId.Planidentifikasjon);
    }
    
    [Fact]
    public void HentAktoerer_NasjonalArealplanId_OneOf_Not_Valid_Deseialization_Test()
    {
        var jsonPath = $"payloadNotValid.json";
        var json = GetJson(jsonPath).ToString();

        try
        {
            JsonConvert.DeserializeObject<HentAktoerer>(json);
        }
        catch (Exception e)
        {
            Assert.Equal("Unexpected character encountered while parsing value:", e.Message);
            return;
        }
        Assert.Fail();
    }

    [Fact]
    public void HentAktoerer_NasjonalArealplanId_OneOf_Not_Valid_SerializationTest()
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
                AdministrativEnhet = new AdministrativEnhet
                {
                    Type = AdministrativEnhetType.Kommunenummer,
                    Nummer = "4321",
                },
                Planidentifikasjon = "tjobing"
            }
        };

        try
        {
            JsonConvert.SerializeObject(hentAktoerer);
        }
        catch (Exception e)
        {
            Console.Out.WriteLine($"Klarte ikke å serialisere json - Exception message: {e.Message}");
            return;
        }
        Assert.Fail();

        //TODO denne feiler. AdmEnhetConverter må justeres/evt erstattes med noe annet
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