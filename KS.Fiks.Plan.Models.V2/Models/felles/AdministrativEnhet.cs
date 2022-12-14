namespace KS.Fiks.Plan.Models.V2.felles
{
    #pragma warning disable // Disable all warnings
    
    /* Note! This code is not generated because of the oneOf-rule in the json schemas
     */
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public class AdministrativEnhet
    {
        [Newtonsoft.Json.JsonProperty("kommunenummer", Required = Newtonsoft.Json.Required.AllowNull)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Kommunenummer { get; set; }
        
        [Newtonsoft.Json.JsonProperty("fylkesnummer", Required = Newtonsoft.Json.Required.AllowNull)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Fylkesnummer { get; set; }
        
        [Newtonsoft.Json.JsonProperty("landskode", Required = Newtonsoft.Json.Required.AllowNull)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Landskode { get; set; }

        public bool isOneOfValid()
        {
            if (string.IsNullOrEmpty(Kommunenummer) && string.IsNullOrEmpty(Fylkesnummer) &&
                string.IsNullOrEmpty(Landskode))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(Kommunenummer) &&
                (!string.IsNullOrEmpty(Fylkesnummer) || !string.IsNullOrEmpty(Landskode)))
            {
                return false;
            }
             
            if (!string.IsNullOrEmpty(Fylkesnummer) &&
                (!string.IsNullOrEmpty(Kommunenummer) || !string.IsNullOrEmpty(Landskode)))
            {
                return false;
            }
            
            if (!string.IsNullOrEmpty(Landskode) &&
                (!string.IsNullOrEmpty(Kommunenummer) || !string.IsNullOrEmpty(Fylkesnummer)))
            {
                return false;
            }

            return true;
        }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties =
            new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

    }
}