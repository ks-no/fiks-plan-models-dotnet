namespace KS.Fiks.Plan.Models.V2.felles
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public class NasjonalArealplanId
    {
        [Newtonsoft.Json.JsonProperty("administrativEnhet", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [Newtonsoft.Json.JsonConverter(typeof(AdmEnhetConverter))]
        public AdministrativEnhet AdministrativEnhet { get; set; }

        [Newtonsoft.Json.JsonProperty("planidentifikasjon", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Planidentifikasjon { get; set; }

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