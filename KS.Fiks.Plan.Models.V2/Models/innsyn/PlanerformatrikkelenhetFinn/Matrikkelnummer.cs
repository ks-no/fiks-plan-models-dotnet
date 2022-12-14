namespace KS.Fiks.Plan.Models.V2.innsyn.PlanerformatrikkelenhetFinn {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class Matrikkelnummer
{
    [Newtonsoft.Json.JsonProperty("kommunenummer", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Kommunenummer { get; set; }

    [Newtonsoft.Json.JsonProperty("gaardsnummer", Required = Newtonsoft.Json.Required.Always)]
    public int Gaardsnummer { get; set; }

    [Newtonsoft.Json.JsonProperty("bruksnummer", Required = Newtonsoft.Json.Required.Always)]
    public int Bruksnummer { get; set; }

    [Newtonsoft.Json.JsonProperty("festenummer", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int Festenummer { get; set; }

    [Newtonsoft.Json.JsonProperty("seksjonsnummer", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int Seksjonsnummer { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}