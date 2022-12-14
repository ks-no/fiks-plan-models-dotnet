namespace KS.Fiks.Plan.Models.V2.innsyn.MidlertidigforbudResultat {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class Omraade
{
    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public OmraadeType Type { get; set; }

    [Newtonsoft.Json.JsonProperty("coordinates", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<System.Collections.Generic.ICollection<System.Collections.Generic.ICollection<double>>> Coordinates { get; set; } = new System.Collections.ObjectModel.Collection<System.Collections.Generic.ICollection<System.Collections.Generic.ICollection<double>>>();

    [Newtonsoft.Json.JsonProperty("crs", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Crs Crs { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}