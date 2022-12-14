using System;
using Newtonsoft.Json;

namespace KS.Fiks.Plan.Models.V2.felles {
    
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
    internal class AdmEnhetConverter : Newtonsoft.Json.Converters.CustomCreationConverter<AdministrativEnhet>
    {
        public AdmEnhetConverter()
        {
            //TODO
        }

        public override AdministrativEnhet Create(Type objectType)
        {
            var administrativEnhet = new AdministrativEnhet();

            return administrativEnhet;
        }
        
        public override void WriteJson(JsonWriter writer, object? administrativEnhetObject, JsonSerializer serializer)
        {
            if (administrativEnhetObject is AdministrativEnhet == false)
            {
                throw new NotSupportedException("Object not an AdministrativEnhet.");
            }

            var admEnh = (AdministrativEnhet) administrativEnhetObject;
            if (admEnh.isOneOfValid())
            {
                throw new ArgumentException(
                    "AdministrativEnhet object have more than one property set and violates the oneOf rule");
            }
        }
    }
}