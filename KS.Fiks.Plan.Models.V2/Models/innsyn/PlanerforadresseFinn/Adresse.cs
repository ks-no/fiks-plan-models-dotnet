namespace KS.Fiks.Plan.Models.V2.innsyn.PlanerforadresseFinn {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class Adresse
{
    [Newtonsoft.Json.JsonProperty("adressekode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Adressekode { get; set; }

    [Newtonsoft.Json.JsonProperty("adressenavn", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Adressenavn { get; set; }

    [Newtonsoft.Json.JsonProperty("adressenummer", Required = Newtonsoft.Json.Required.Always)]
    public int Adressenummer { get; set; }

    [Newtonsoft.Json.JsonProperty("adressebokstav", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Adressebokstav { get; set; }

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