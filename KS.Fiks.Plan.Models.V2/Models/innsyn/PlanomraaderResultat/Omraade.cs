namespace KS.Fiks.Plan.Models.V2.innsyn.PlanomraaderResultat {
#pragma warning disable // Disable all warnings

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.7.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class Omraade
{
    [Newtonsoft.Json.JsonProperty("koordinatsystem", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Koordinatsystem { get; set; }

    [Newtonsoft.Json.JsonProperty("ytreAvgrensning", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string YtreAvgrensning { get; set; }

    [Newtonsoft.Json.JsonProperty("vertikallag", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Vertikallag { get; set; }



    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
}